# Memento

![Main UI](Images/main01.png)

This is a simple tool for save scumming, initial version written in an evening. Build it on Windows 10 with .NET Core 5.0

## Support

The program does not attempt to recover in case if unexpected scenario, for example, path permissions are not checked, so if a file or folder is inaccessible the program will crash. 
If it deposits a file named `unhandled-*.log ` in the same folder where the executable file is, providing it to me may help to track down the problem. I'll try to fix major issues as they are found, if/when I have time.

## Usage

Usage is straight forward:

- Create a new profile for a game
- Specify the game save folder and the game executable and a few options (below)
- Select "Start watching" for the program to start monitoring the save folder and making copies whenever there is no changes for 5 seconds after the last change
- Or press "Backup" / "Restore" to backup / restore as a one off
- Right-clicking on a save will allow to rename or delete it
- Clean up old backups by clicking "Open Backups Folder" and browsing the folder structure, it's pretty self-explanatory

That's about it. The program does not prune old saves, so if unchecked, it can get out of control soon - please do it manually

Please make sure that when you are restoring, the game is not running, most games are not programmed to withstand save changes on the fly.

## Options

- **Kill/restart game during restore** - If checked, when you press "Restore", Memento will attempt to kill the game process, do the file restoration and re-launch the game process again
- **Do not warn when restoring** - In most cases trying to restore while the game is running won't produce desired results, so Memento warns you in this situation. If checked, the warning is not generated
- **Clean up save folder before restoring** - Usually during restore process the game save back up is simply copied over the saves folder. This will leave any files that was there before restoring and is not part of the backup intact. Most of the time this does not matter. In rare case the game may behave differently in the presence of a file it does not expect. Check this options to delete the save folder completely before restoring, so after restoring it exactly matches the backup
- **Backup before restoring** - If checked, when you press "Restore" Memento also does a back up before it does the restore
- **Backup on start watching** - If checked, when you press "Start Watching" Memento takes a backup immediatelly, even before a first change detected
- **Write log** - If checked Memento will write a debug log in a file. Press "Open Backups Folder" to see the log file
- **Show number of files backed up** - See Advanced Filtering below

## Advanced Filtering

You can click "Configure advanced filtering" when editing a game profile. You can configure the following settings there:

**Backup Filter** - Specify a .net [Regular Expressions](https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference) to select files to backup. The regular expression are matched against file paths relative to the Backup Folder. For example, if you only want to backup file `save` at the top level of the Backup folder, specify `^save$` here. If you want all the files with `.sav` extension, regardless of subfolder `.sav$` will work, etc. Leave this field empty to copy all files in the Backup Folder recursively.

When the Backup Filter option is specified, a couple of options above behave differently:

- *Clean up save folder before restoring* - instead of removing the entire backup subfolder, only the files matching the Backup Filter are removed.
- *Show number of files backed up* - this option can only be enabled if Backup Filter is specified. When enabled, after each backup a message will be displayed in the main Memento window, specifying the number of files included in the last backup. This can be helpful to see at a glance that your regular expression backups what you want. Of course, you can always press "Backup", "Open Backups Folder" and drill down to see what exactly was backed up.

**Watch Filter** - Can be used to fine tune a bit when the change detection is triggered. Unfortunately the syntax of this filter does not allow regex, just basic operating system wildcards: `*` and `?`. See [filter](https://docs.microsoft.com/en-us/dotnet/api/system.io.filesystemwatcher.filter) for more details. While it will not be always possible to watch only those files that belongs to the Backup Filter, specifying this still could be useful to cut down on the number of unwanted backups when files that we do not want to backup are changed in the Saves Folder.

## Installation

Download latest version from [Releases](https://github.com/AndrewSav/Memento/releases). There are two version .NET Core self-contained, which is supposed to run without dependencies, and a smaller one that relies on .NET Core SDK/runtime present on your PC. 

Unzip the archive and put the content to a folder and run.

## Building

You can build in VS2019. You can use `build.ps1` to build the Release with .Net core SDK. Look at `global.json` to find out which SDK version you need installed.

## Change Log

* 1.2.0 (unreleased)

  * Added an confirmation dialog when deleting a backup

* 1.1.0

  * Upgraded to .net SDK 5.0.400
  * When "Kill/restart game during restore" is enambled attemt to wait for process to finish after killing it
  * Now "Kill/restart game during restore" option actually attempt to restart the game after restore
  * Updated dependencies
  * Added an option for File Watcher [filter](https://docs.microsoft.com/en-us/dotnet/api/system.io.filesystemwatcher.filter)
  * Added an option to filter which files to backup using [Regular Expressions](https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference)
  * Minor code clean up
  * Fixed an issue Where "Delete" backup would not delete the parent folders if it's the last backup we are deleting in the parent folder, which interfered with Radion Buttons display logic causing some backups not to be displayed

* 1.0.6

  * Upgraded to .net 5
  * Upgraded dependencies

* 1.0.5

  * Fixed to work with the new Windows Forms Designer for .NET Core
  * Minor fix in the build script
  * Added "Deleting old save before restoring" option (use with care, if used on Windows build before 1903, it can cause intermittent deletion lock issues)
  * Updated dependencies

* 1.0.4

  * Added ability to rename saves
  * Added ability to delete saves from the application itself
  * Fixed a bug, when after renaming a profile, the application did not know how to find old saves
  * A minor fix for MetroFramework

* 1.0.3

  * Removed maximise button on the Edit form
  * Moved up Edit form button to align better with the drop down
  * Fixed version link not working
  * Updated .net core sdk to the lastest
  * Worked around a race condition in the build script, that caused a missing icon in the executable

* 1.0.2

  * Ported to .Net Core. 
  * Fixed an issue with [Use Unicode UTF-8 for worldwide language support](https://stackoverflow.com/questions/56419639/what-does-beta-use-unicode-utf-8-for-worldwide-language-support-actually-do) option.
  

## Attributions

* Icon made by [bqlqn](https://www.flaticon.com/authors/bqlqn) from [www.flaticon.com](https://www.flaticon.com)
* MetroFramework - https://thielj.github.io/MetroFramework/
* Newtonsoft Json.NET - https://www.newtonsoft.com/json
* Serilog - https://serilog.net/
* Serilog.Sinks.File -  https://github.com/serilog/serilog-sinks-file
* ReactiveX - http://reactivex.io/
