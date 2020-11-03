# Memento

![Main UI](Images/main01.png)

This is a simple tool for save scumming, written in an evening. Build on Windows 10 with .NET Core 3.1

## Support

It is not tested very well and it would probably fail horribly in any deviation form ideal scenario, for example, path permissions are not checked, so if a file or folder is inaccessible the program will crash. If it deposits a file named `unhandled-*.log ` in the same folder where the executable file is, providing it to me may help to track down the problem. I'll try to fix major issues as they are found, if/when I have time.

## Usage

Usage is straight forward:

- Create a new profile for a game
- Specify the game save folder and the game executable and a few options
- Select "Start watching" for the program to start monitoring the save folder and making copies whenever there is a change
- Or press "Backup" / "Restore" to backup / restore as a one off.

That's about it. The program does not prune old saves, so if unchecked, it can get out of control soon - please do it manually

Please make sure that when you are restoring, the game is not running, most games are not programmed to withstand save changes on the fly.

## Installation

Download latest version from [Releases](https://github.com/AndrewSav/Memento/releases). There are two version .NET Core self-contained, which is supposed to run without dependencies, and a smaller one that relies on .NET Core SDK/runtime present on your PC. 

Unzip the archive and put the content to a folder and run.

## Building

You can build in VS2019. You can use `build.ps1` to build the Release with .Net core SDK. Look at `global.json` to find out which SDK version you need installed.

## Change Log

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
