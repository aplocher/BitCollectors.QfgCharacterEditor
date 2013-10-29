param($installPath, $toolsPath, $package, $project)

# Save project if any unsaved changes are pending
$project.Save()

# Get project directory
$projectDirectory = [System.IO.Path]::GetDirectoryName($project.FullName)

# Load project XML
$projectXml = [xml](get-content $project.FullName)

# Get project namespace
$nameSpace = $projectXml.project.xmlns
[System.Xml.XmlNamespaceManager] $nameSpaceManager = $projectXml.nametable
$nameSpaceManager.AddNamespace('mvc3', $nameSpace)

$assemblyBindingNameSpace = "urn:schemas-microsoft-com:asm.v1"

$nameSpaceManager.AddNamespace('rootConfig', $assemblyBindingNameSpace)

# Iterate through each web.config and make necessary changes
$projectXml.DocumentElement.SelectNodes("//mvc3:Content[contains(translate(@Include,'WEBCONFIG','webconfig'),'web.config')]", $nameSpaceManager) | ForEach-Object { $config = $projectDirectory + "\" + $_.Include;$configContent = [System.IO.File]::ReadAllText($config);$configContent = $configContent.Replace('System.Web.Mvc, Version=3.0.0.0','System.Web.Mvc, Version=4.0.0.0');$configContent = $configContent.Replace('System.Web.WebPages, Version=1.0.0.0','System.Web.WebPages, Version=2.0.0.0');$configContent = $configContent.Replace('System.Web.Helpers, Version=1.0.0.0','System.Web.Helpers, Version=2.0.0.0');$configContent = $configContent.Replace('System.Web.WebPages.Razor, Version=1.0.0.0','System.Web.WebPages.Razor, Version=2.0.0.0');[System.IO.File]::WriteAllText($config, $configContent);}

$rootConfigPath = $projectDirectory + "\web.config"
$rootConfig = [xml](get-content $rootConfigPath)

# Changing root web.config webpages version
$rootConfig.DocumentElement.SelectNodes("/configuration/appSettings/add[@value='1.0.0.0' and @key='webpages:Version']") | ForEach-Object { $_.ParentNode.RemoveChild($_); }

# Removing old assembly binding information
$rootConfig.DocumentElement.SelectNodes("/configuration/runtime/rootConfig:assemblyBinding/rootConfig:dependentAssembly[rootConfig:bindingRedirect/@oldVersion='1.0.0.0-2.0.0.0']", $nameSpaceManager) | ForEach-Object { $_.ParentNode.RemoveChild($_); }

[System.Xml.XmlNode] $assemblyBinding = $rootConfig.DocumentElement.SelectSingleNode("/configuration/runtime/rootConfig:assemblyBinding", $nameSpaceManager)

# Adding System.Web.Helpers assembly binding information
    [System.Xml.XmlNode] $dependentAssembly = $rootConfig.CreateElement("dependentAssembly", $assemblyBindingNameSpace)
    [System.Xml.XmlNode] $assemblyIdentity = $rootConfig.CreateElement("assemblyIdentity", $assemblyBindingNameSpace)
    [System.Xml.XmlAttribute] $attribute = $rootConfig.CreateAttribute("name")
    $attribute.Value = "System.Web.Helpers";
    $assemblyIdentity.Attributes.Append($attribute);
    
    $attribute = $rootConfig.CreateAttribute("publicKeyToken")
    $attribute.Value = "31bf3856ad364e35";
    $assemblyIdentity.Attributes.Append($attribute);
    $dependentAssembly.AppendChild($assemblyIdentity);
    
    [System.Xml.XmlNode] $bindingRedirect = $rootConfig.CreateElement("bindingRedirect", $assemblyBindingNameSpace)
    $attribute = $rootConfig.CreateAttribute("oldVersion")
    $attribute.Value = "1.0.0.0";
    $bindingRedirect.Attributes.Append($attribute);
    
    $attribute = $rootConfig.CreateAttribute("newVersion")
    $attribute.Value = "2.0.0.0";
    $bindingRedirect.Attributes.Append($attribute);
    $dependentAssembly.AppendChild($bindingRedirect);
    
    $assemblyBinding.AppendChild($dependentAssembly);
    
# Adding System.Web.Mvc assembly binding information
    $dependentAssembly = $rootConfig.CreateElement("dependentAssembly", $assemblyBindingNameSpace)
    $assemblyIdentity = $rootConfig.CreateElement("assemblyIdentity", $assemblyBindingNameSpace)
    $attribute = $rootConfig.CreateAttribute("name")
    $attribute.Value = "System.Web.Mvc";
    $assemblyIdentity.Attributes.Append($attribute);
    
    $attribute = $rootConfig.CreateAttribute("publicKeyToken")
    $attribute.Value = "31bf3856ad364e35";
    $assemblyIdentity.Attributes.Append($attribute);
    $dependentAssembly.AppendChild($assemblyIdentity);
    
    $bindingRedirect = $rootConfig.CreateElement("bindingRedirect", $assemblyBindingNameSpace)
    $attribute = $rootConfig.CreateAttribute("oldVersion")
    $attribute.Value = "1.0.0.0-3.0.0.0";
    $bindingRedirect.Attributes.Append($attribute);
    
    $attribute = $rootConfig.CreateAttribute("newVersion")
    $attribute.Value = "4.0.0.0";
    $bindingRedirect.Attributes.Append($attribute);
    $dependentAssembly.AppendChild($bindingRedirect);
    
    $assemblyBinding.AppendChild($dependentAssembly);

# Adding System.Web.WebPages assembly binding information
    $dependentAssembly = $rootConfig.CreateElement("dependentAssembly", $assemblyBindingNameSpace)
    $assemblyIdentity = $rootConfig.CreateElement("assemblyIdentity", $assemblyBindingNameSpace)
    $attribute = $rootConfig.CreateAttribute("name")
    $attribute.Value = "System.Web.WebPages";
    $assemblyIdentity.Attributes.Append($attribute);
    
    $attribute = $rootConfig.CreateAttribute("publicKeyToken")
    $attribute.Value = "31bf3856ad364e35";
    $assemblyIdentity.Attributes.Append($attribute);
    $dependentAssembly.AppendChild($assemblyIdentity);
    
    $bindingRedirect = $rootConfig.CreateElement("bindingRedirect", $assemblyBindingNameSpace)
    $attribute = $rootConfig.CreateAttribute("oldVersion")
    $attribute.Value = "1.0.0.0";
    $bindingRedirect.Attributes.Append($attribute);
    
    $attribute = $rootConfig.CreateAttribute("newVersion")
    $attribute.Value = "2.0.0.0";
    $bindingRedirect.Attributes.Append($attribute);
    $dependentAssembly.AppendChild($bindingRedirect);
    
    $assemblyBinding.AppendChild($dependentAssembly);

$rootConfig.Save($rootConfigPath)

# Change project type MVC 3 to MVC 4
$configContent = [System.IO.File]::ReadAllText($project.FullName);
$configContent = $configContent.Replace('E53F8FEA-EAE0-44A6-8774-FFD645390401','E3E379DF-F4C6-4180-9B81-6769533ABE47');
[System.IO.File]::WriteAllText($project.FullName, $configContent);