[CmdletBinding()]
Param(
    [Parameter(Mandatory = $true, Position = 1)]
    [string]$projectFile,
    
    [Parameter(Mandatory = $true, Position = 2)]
    [string]$packageId,
    
    [Parameter(Mandatory = $true, Position = 3)]
    [string]$configPrefix,
    
    [switch]$Build,
    [switch]$Package
)

$workDir = (Join-Path (Join-Path $env:TEMP PowerDeploy) (Get-Date -Format yyyy-MM-dd_HH.mm.ss))

function DoBuild()
{
    Write-Host "Building $projectFile"
    exec { msbuild $projectFile /p:Configuration=Release /p:RunCodeAnalysis=false /p:OutputPath=$workDir/out /verbosity:minimal /t:Rebuild }
}

function Package()
{
#    set-alias sz "$($context.paths.tools)\7Zip\7za.exe"
    
    AddPackageParameters 

    # todo: this script shouldn't know anything about those paths...
    sz a -tzip (Join-Path $powerdeploy.paths.project "deployment/deploymentUnits/$($packageId)_1.0.0.0.zip") "$workDir/*" | Out-Null
    
    # Remove-Item $outputDir -Recurse
}

function AddPackageParameters()
{    
    $file = Join-Path $workDir "package.template.xml"
        
    $xml = New-Object System.Xml.XmlTextWriter($file, $null)
    $xml.Formatting = "Indented"
    $xml.Indentation = 4
    
    $xml.WriteStartDocument()
    $xml.WriteStartElement("package")
    $xml.WriteAttributeString("type", "xcopy")
    $xml.WriteAttributeString("id", $packageId)
    $xml.WriteAttributeString("version", "1.3.3.7")
    $xml.WriteAttributeString("environment", "TODO: parseblae env + subenv") # `${env + subenv}
    
    # pass to each individual impl:
    $xml.WriteElementString("droplocation", "`${$($configPrefix)_DropLocation}")
    $xml.WriteEndElement()
    $xml.WriteEndDocument()
    
    $xml.Flush()
    $xml.Close()
}

if ($Build -eq $null -and $Package -eq $null) { Write-Host "wrong usage of this script. maybe you should have a look at the source code :)" }

if ($Build)
{
    DoBuild
}

if ($Package)
{
    Package
}
