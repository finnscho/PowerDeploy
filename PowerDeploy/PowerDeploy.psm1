######################################################################
##
## PowerDeploy
##
## by tobias zürcher
##
######################################################################

$root_dir = (Split-Path -parent $MyInvocation.MyCommand.path)

$script:powerdeploy = @{
	version = "0.1.0";
	project = $null;
	packages = @{};
	paths = @{
                tools = Join-Path $root_dir "tools";
                project = $null;
                root_dir = $root_dir
                deployment_units = $null;
                deployment_unit_configs = $null;
                project_config_file = $null;
                scripts = Join-Path $root_dir "scripts";
                environments = Join-Path $root_dir "environments"
            };
    deployment_units = @{};
}

# include all .ps1 files from modules folder...
Resolve-Path $root_dir\module\*.ps1 | 
    ? { -not ($_.ProviderPath.Contains(".Tests.")) } |
    % { . $_.ProviderPath }

# ... and export them
Export-ModuleMember -Function Initialize-PowerDeploy, Configure-Environment, List-Packages, Get-Properties, Replace-Text, Invoke-Build, Prepare-DeploymentUnit, xmlpeek, xmlpoke, exec, Fromat-String, Replace-Placeholders, Open-ProjectDir, createUniqueDir -Variable powerdeploy
