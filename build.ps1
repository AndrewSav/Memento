$ErrorActionPreference = "Stop"
$global:ProgressPreference = 'SilentlyContinue'
$env:DOTNET_CLI_TELEMETRY_OPTOUT="1"

$targetFramework = "net8.0-windows7.0"

$targetFolder = Join-Path $PSScriptRoot Build
$debugBin = Join-Path $PSScriptRoot "bin\Debug\$targetFramework"
$debugBinRuntimes = Join-Path $PSScriptRoot "bin\Debug\$targetFramework\runtimes"

$releasePublish = Join-Path $PSScriptRoot "bin\Release\$targetFramework\win-x64\publish"
$releasePublishNsc = Join-Path $PSScriptRoot "bin\Release\$targetFramework\win-x64\publish_nsc"

$project = Join-Path $PSScriptRoot Memento.csproj
$version = ([xml](Get-Content $project)).Project.PropertyGroup[0].Version

$targetZip = Join-Path $targetFolder "Memento.$version.zip"
$targetSelfContainedZip = Join-Path $targetFolder "MementoSelfContained.$version.zip"

mkdir $targetFolder -force | Out-Null

dotnet publish -c Release --self-contained -r win-x64 -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true
Compress-Archive "$releasePublish/*" $targetSelfContainedZip -Force

dotnet publish Memento.csproj -o $releasePublishNsc -c Release --self-contained false -r win-x64 -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true
Compress-Archive "$releasePublishNsc/*" $targetZip -Force
