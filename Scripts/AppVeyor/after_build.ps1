# create nuget package of project
$version = $env:APPVEYOR_BUILD_VERSION
$configration = $env:CONFIGURATION
$nuspec = (Resolve-Path ".\Source\WbTstr\WbTstr.nuspec").ToString()

nuget pack $nuspec -version $version -properties Configuration=$configration