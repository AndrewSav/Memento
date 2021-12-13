$ErrorActionPreference = "Stop"
$global:ProgressPreference = 'SilentlyContinue'

$targetFramework = "net6.0-windows"

$targetFolder = Join-Path $PSScriptRoot Build
$debugBin = Join-Path $PSScriptRoot "bin\Debug\$targetFramework"
$debugBinRuntimes = Join-Path $PSScriptRoot "bin\Debug\$targetFramework\runtimes"

$releasePublish = Join-Path $PSScriptRoot "bin\Release\$targetFramework\win-x64\publish"

$warp = Join-Path $PSScriptRoot Tools\warp.exe
$editbin = Join-Path $PSScriptRoot Tools\editbin.exe
$rh = Join-Path $PSScriptRoot Tools\rh.exe
$project = Join-Path $PSScriptRoot Memento.csproj

$icon = Join-Path $PSScriptRoot Resources\Main.ico

$version = ([xml](Get-Content $project)).Project.PropertyGroup[0].Version

$tempExe = Join-Path $targetFolder Memento.exe

$targetZip = Join-Path $targetFolder "Memento.$version.zip"
$targetSelfContainedZip = Join-Path $targetFolder "MementoSelfContained.$version.zip"

if (Test-Path $tempExe) {
  Remove-Item $tempExe -Force
}

mkdir $targetFolder -force | Out-Null

dotnet build
if (Test-Path $debugBinRuntimes) {
  Remove-Item $debugBinRuntimes -Recurse -Force
}
& $warp -i $debugBin -a windows-x64 -e Memento.exe -o $tempExe
& $editbin /subsystem:windows $tempExe
Start-Process $rh "-open", $tempExe, "-save", $tempExe, "-action", "addskip", "-res", $icon, "-mask", "ICONGROUP,MAINICON," -Wait

dotnet publish -c Release --self-contained -r win-x64 -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true
Compress-Archive "$releasePublish/*" $targetSelfContainedZip -Force

Compress-Archive $tempExe $targetZip -Force
Remove-Item $tempExe

