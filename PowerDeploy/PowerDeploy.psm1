######################################################################
##
## PowerDeploy
##
## by tobias zürcher
##
######################################################################

$SCRIPT:projectRootDir = $null
$SCRIPT:packages = $null
$SCRIPT:projectId = "moviedemo"
$SCRIPT:rootDir = (Split-Path -parent $MyInvocation.MyCommand.path)
$SCRIPT:toolsDir = Join-Path $SCRIPT:rootDir "tools"

$script:pdeploy = @{}
$pdeploy.version = "0.1.0" # contains the current version of PowerDeploy

# todo: $path can be also ./ or relative -> handle this correctly! (not just strings)
function Initialize-PowerDeploy([string]$path = (Split-Path -parent $MyInvocation.MyCommand.path))
{
    $SCRIPT:projectRootDir = $path
    $packages = ([xml](Get-Content (Join-Path $projectRootDir "configuration\neutralpackages.xml"))).neutralpackages
    
    $pdeploy.context = new-object system.collections.stack # holds onto the current state of all variables
    $pdeploy.context.push(@{
        "project" = ([xml] (Get-Content (Join-Path $projectRootDir "configuration/project/common.xml"))).project
        "packages" = $packages.package;
        "paths" = @{
                tools = Join-Path $rootDir "tools";
                project = $path;
                deploymentUnits = Join-Path $projectRootDir "deployment/deploymentUnits";
                deploymentUnitConfigs = Join-Path $projectRootDir "deployment/deploymentUnitConfigs";
                projectConfigFile = Join-Path $projectRootDir "configuration/project/common.xml";
                scripts = Join-Path $rootDir "scripts";
            };
        "environment" = "neutral";
        "deploymentUnits" = @{};
    })
    
    Parse-DeploymentUnits
    
    Set-Alias sz "$($pdeploy.context.peek().paths.tools)\7Zip\7za.exe"
    
    # todo: code von psake "ausleihen"... 
    $env:path = "C:\Windows\Microsoft.NET\Framework64\v4.0.30319" + ";$env:path"
}

function Get-PowerDeployContext()
{
    return $pdeploy.context.peek()
}

function Configure-Environment([string]$environment = "NEUTRAL", [string]$targetPath = $SCRIPT:projectRootDir, [boolean]$deleteTemplates = $false)
{   
    Write-Host "Configuring environment for" $environment.ToUpper() " in $targetPath" -ForegroundColor "DarkCyan"
   
    foreach($template in Get-ChildItem -Path $targetPath -Filter "*.template.*" -Recurse)
    {
        Transform-Template $template.Fullname $environment
        
        if ($deleteTemplates -eq $true)
        {
            Remove-Item $template.Fullname -Force
        }
    }
}

function Prepare-DeploymentUnit([string]$deploymentUnit, [string]$environment) # todo: error handling if one of them is null/empty/not-existing/whatever...
{
    $context = Get-PowerDeployContext
    
    # remove target folder
    $destinationFolder = Join-Path (Join-Path $context.paths.deploymentUnits $deploymentUnit) $environment.ToUpper()       
    
    if ([IO.Directory]::Exists($destinationFolder)) 
    {
        Remove-Item $destinationFolder -Recurse -Force
    }
    
    New-Item -path $destinationFolder -type directory | Out-Null
    
    foreach ($unit in $context.deploymentUnits[$deploymentUnit])
    {
        $foundUnit = Get-ChildItem $context.paths.deploymentUnits -Filter $unit.path
      
        # todo: first check if all ok and then go further with processing
        # otherwise there could be some half transformed deploymentUnits    
        if ($foundUnit -eq $null)
        {
            Write-Host "No neutral package found for $($unit.path)! Please build the neutral package first." -ForegroundColor "Red"
        }
        else
        {
            $workDir = (Join-Path (Join-Path $env:TEMP PowerDeploy) (createUniqueDir))
    
            Set-Alias sz "$($pdeploy.context.peek().paths.tools)\7Zip\7za.exe"        
            sz x -y "-o$($workDir)" $foundUnit.Fullname | Out-Null
            
            $packagePath = Join-Path $workDir "package.template.xml"
            $packageType = xmlPeek $packagePath "package/@type"
            $packageId = xmlPeek $packagePath "package/@id"
            $packageVersion = xmlPeek $packagePath "package/@version"
            
            Write-Host "Preparing $packageId with type $packageType" -ForegroundColor yellow
            
            Invoke-Expression -Command "$(Join-Path $($context).paths.scripts prepare.$packageType.ps1) $workDir -Disassemble -Verbose"
            
            Configure-Environment $environment $workDir -deleteTemplates $true
            
            Invoke-Expression -Command "$(Join-Path $($context).paths.scripts prepare.$packageType.ps1) $workDir -Reassemble -Verbose"
            
            Copy-Item "$workDir\" "$destinationFolder\$($packageId)_$($packageVersion)\" -Recurse
        }
    }
}

# creates an almost unique folder :) i like to have the date in the folder name for traceability while debugging...
# this can be refactored to just a guid as soon things gets more stable 
function createUniqueDir()
{
    return '{0}___{1}' -f (Get-Date -Format yyyy-MM-dd_HH.mm.ss), [guid]::NewGuid().ToString().Substring(6)
}

function Invoke-Deploy([string]$deploymentUnit, [string]$environment)
{
    # todo: deployment...
}

# check if this is the better format-string...
function Format-String([string]$string, [hashtable]$replacements)
{
    $currentIndex = 0
    $replacementList = @()

    foreach($key in $replacements.Keys)
    {
        $inputPattern = '\${' + $key + '}'
        $replacementPattern = '{${1}' + $currentIndex + '${2}}'
        $string = $string -replace $inputPattern, $replacementPattern
        $replacementList += $replacements[$key]
        
        write-host $inputPattern $replacementPattern

        $currentIndex++
    }
    
    return $string -f $replacementList
}
    

# todo: case insensitive! (-> test it, maybe it works already)
function Transform-Template([string]$templateFile, [string]$environment)
{
    $targetFile = $templateFile -replace ".template.", "."
    
    # we don't need to remove read only flag, Force flag of Set-Content does the job
    #Set-ItemProperty $targetFile -name IsReadOnly -value $false
    
    $content = Get-Content $templateFile | Out-String
    
    $replacePattern = ("{0}\implementation\source\" -f $projectRootDir) -replace "\\", "\\"
    
    Write-Verbose "transforming $($templateFile -replace $replacePattern) to $($targetFile -replace $replacePattern)"
    
    if ($environment -eq "NEUTRAL")
    {
        $content | Set-Content $targetFile -Force
    }
    else
    {
        Replace-Placeholders $content $environment | Set-Content $targetFile -Force
    }
}  

function Replace-Placeholders($templateText, [string]$environment)
{
    $properties = Get-Properties("local")
    
    $missingProperties = @()

    $MatchEvaluator = 
    {  
      param($match)
    
      $templateParaName = $match -replace "{", "" -replace "}", "" -replace "\$" # todo use $Match 
      
      if (@($properties | where { $_.name -eq $templateParaName}).Count -eq 0)
      {
        $missingProperties += $templateParaName
      }
      
      return $match.Result(($properties | where { $_.name -eq $templateParaName }).wert)
    }
    
    $result = [regex]::replace($templateText, "\$\{[^\}]*\}", $MatchEvaluator)
    
    if ($missingProperties.Count -gt 0)
    {
        Write-Host "  Missing $($missingProperties.Count) properties" -ForegroundColor "Red"
        $missingProperties | ForEach-Object { write-host "    -> $_" }
    }
    
    return $result
}

# TODO: common xml!
function Get-Properties($environment)
{
    $context = Get-PowerDeployContext

    return ([xml](Get-Content "C:\git\PowerDeploy\PowerDeploy\environments\$($context.project.id)\$environment.xml")).environment.property
}

function List-Packages()
{
    Write-Output $pdeploy.context.peek().packages
}

function Parse-DeploymentUnits()
{
    $context = $pdeploy.context.peek()

    $result = @{}
    
    # iterate over all deploymentUnit configs and parse them
    foreach($file in Get-ChildItem $context.paths.deploymentUnitConfigs)
    {
        $units = ([xml](get-content $file.Fullname)).deploymentunits.deploymentUnit
    
        $result[$file.BaseName] = $units
    }
    
    $context.deploymentUnits = $result;
}

function Invoke-Build([string]$type)
{
    $context = Get-PowerDeployContext
    
    foreach ($package in $context.packages | where { $_.type -eq $type })
    {
        $projectFile = Join-Path (Join-Path $projectRootDir "/implementation/source/") $package.source
        Invoke-Expression -Command "$(Join-Path $($context).paths.scripts build.$type.ps1) $projectFile $($package.id) $($package.configPrefix) -Build -Package"
    }
}

function Open-ProjectDir()
{
    $context = Get-PowerDeployContext    
    Invoke-Item $context.paths.project
}

function xmlPeek($filePath, $xpath)
{ 
    [xml] $fileXml = Get-Content $filePath 
    $found = $fileXml.SelectSingleNode($xpath)

    if ($found.GetType().Name -eq 'XmlAttribute') { return $found.Value }

    return $found.InnerText
} 

function xmlPoke($file, $xpath, $value)
{ 
    $filePath = $file.FullName 

    [xml] $fileXml = Get-Content $filePath 
    $node = $fileXml.SelectSingleNode($xpath) 
    
    if ($node)
    { 
        $node.Value = $value 

        $fileXml.Save($filePath)  
    } 
}

function Exec
{
    [CmdletBinding()]
    param(
        [Parameter(Position=0,Mandatory=1)][scriptblock]$cmd,
        [Parameter(Position=1,Mandatory=0)][string]$errorMessage = ("Error in {0}" -f $cmd)
    )
    & $cmd
    if ($lastexitcode -ne 0) {
        throw ("Exec: " + $errorMessage)
    }
}

function Task
{
    [CmdletBinding()]  
    param(
        [Parameter(Position=0,Mandatory=1)][string]$name = $null,
        [Parameter(Position=1,Mandatory=0)][scriptblock]$action = $null,
        [Parameter(Position=9,Mandatory=0)][string]$description = $null,
        [Parameter(Position=10,Mandatory=0)][string]$alias = $null
    )

    
}

Export-ModuleMember -Function Initialize-PowerDeploy, Configure-Environment, List-Packages, Get-Properties, Replace-Text, Invoke-Build, Get-PowerDeployContext, Prepare-DeploymentUnit, xmlpeek, xmlpoke, Exec, Format-String, Replace-Placeholders, Open-ProjectDir