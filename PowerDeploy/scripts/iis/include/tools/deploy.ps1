[CmdletBinding()]
Param(
    [Parameter()] [string] $backup_package = '',
    [switch] $Deploy,
    [switch] $Backup,
    [switch] $Help,
    [switch] $Restore,
    [switch] $UpdateExisting
)

$ErrorActionPreference = "Stop"

# package is one folder up... wtf!!! isn't there an easier way to do that?
$work_dir = resolve-path "$(Split-Path -parent $MyInvocation.MyCommand.path)/.."

Push-Location $work_dir

function Backup()
{
	Write-Host "Create backup for $package_appserver/$package_virtualdir"

	# WHAT THE FUCK, LOOK AT THOSE `! this IS ridiculous!
	$Host.UI.RawUI.ForegroundColor = "DarkGray"

	# because of the bug mentioned in the link below, we have to make a workaround to create backup
	# http://connect.microsoft.com/PowerShell/feedback/details/376207/executing-commands-which-require-quotes-and-variables-is-practically-impossible#
#	.\tools\MsDeploy\x64\msdeploy.exe -source:"contentPath='$package_website/$package_virtualdir'" -dest:"package='backup_$(Get-Date -Format yyyy-MM-dd_HH-mm-ss).zip'" -verb:sync

	CreateBackup ("$package_website/$package_virtualdir") "backup_$(Get-Date -Format yyyy-MM-dd_HH-mm-ss).zip"
	$Host.UI.RawUI.ForegroundColor = "Gray"

	Write-Host
}

# call command line tools which require quotes -> impossible (i didn't get it working for backup, this is a workaround)
function CreateBackup([string]$content_path, [string]$package_name) {
    cmd.exe /C $("tools\MsDeploy\x64\msdeploy.exe -verb:sync -source:contentPath=`"{0}`" -dest:package=`"{1}`"" -f $content_path, $package_name)
}

function Restore()
{
	cls

	if ($backup_package -eq '')
	{
		Write-Host "Following backups available:"
		Write-Host 

		Get-ChildItem -filter backup_* | Format-table Name -HideTableHeaders

		Write-Host "Usage example: " -nonewline
		Write-Host "  package -Restore backup_2000-01-12_13:37.zip" -f Red
		Write-Host
	}
	else
	{
		Write-Host "Restoring package $backup_package"
		Write-Host 

		# remove optional .\ in front of filename (just if the juster pressed Format-table)
		DoDeploy (Get-Item $backup_package).Fullname
	}
}

function DoDeploy([string] $package = "package.zip")
{
	Write-Host "Deploying iis package to web site $package_website into virtual directory $package_virtualdir"

	Import-Module .\tools\PowerDeploy.Extensions.dll -DisableNameChecking

	# todo get-architecture
	$Host.UI.RawUI.ForegroundColor = "DarkGray"
	.\tools\MsDeploy\x64\msdeploy.exe -source:package="$package" -dest:"auto,includeAcls='False',computerName='$package_appserver',authType='NTLM'" -verb:sync -disableLink:ContentExtension -disableLink:CertificateExtension -allowUntrusted
 	$Host.UI.RawUI.ForegroundColor = "Gray"

	Write-Host

	Create-AppPool -Name $package_apppoolname -ServerName $package_appserver -WAMUserName $package_username -WAMUserPass -package_password
	Assign-AppPool -ServerName $package_appserver -ApplicationPoolName $package_apppoolname -VirtualDirectory $package_virtualdir -WebsiteName $package_website

	Remove-Module PowerDeploy.Extensions

	Write-Host "Done! have fun!"
}

function ShowHelp()
{
	Write-Host "  - Deploy	 Deploys $package_name to $package_appserver$package_virtualdir"
	Write-Host "  - Backup	 Backups the currently deployed $package_name on $package_appserver."
	Write-Host "  - Restore	 Restores a previously created backup."
	Write-Host "  - Help 	 Shows help information."
	Write-Host
}

function xmlPeek($filePath, $xpath)
{ 
    [xml] $fileXml = Get-Content $filePath 
    $found = $fileXml.SelectSingleNode($xpath)

    if ($found.GetType().Name -eq 'XmlAttribute') { return $found.Value }

    return $found.InnerText
} 

function Write-Welcome
{
	Write-Host ""
	Write-Host ""
	Write-Host "Welcome to your power deploy shell!"
	Write-Host ""
	Write-Host "  Package: " -nonewline
	Write-Host $package_name v$package_version -ForegroundColor Red -nonewline
	Write-Host ""
	Write-Host ("   targeting {0}" -f $package_env.ToUpper())
	Write-Host "" 
	Write-Host ""

	#Set-Alias deploy DeployAlias -Scope Global
}


$work_dir = resolve-path "$(Split-Path -parent $MyInvocation.MyCommand.path)/.."

$package_xml         = Join-Path $work_dir "package.xml"

$package_name 		 = xmlPeek $package_xml "/package/@id"
$package_version     = xmlPeek $package_xml "/package/@version"
$package_env         = xmlPeek $package_xml "/package/@environment"
$package_appserver   = xmlPeek $package_xml "/package/appserver"
$package_username    = xmlPeek $package_xml "/package/username"
$package_password    = xmlPeek $package_xml "/package/password"
$package_apppoolname = xmlPeek $package_xml "/package/apppoolname"
$package_virtualdir  = xmlPeek $package_xml "/package/virtualdir"
$package_website     = xmlPeek $package_xml "/package/website"

if ($Deploy -eq $false -and $Backup -eq $false -and $Restore -eq $false)
{
	$Help = $true
}

if ($Help)
{
	Write-Welcome
	ShowHelp
}

if ($Backup) { Backup }
if ($Restore) { Restore }
if ($Deploy) 
{
	Backup
	DoDeploy
}

Pop-Location