# Memento

![Main UI](Images/main01.png)

This is a simple tool for save scumming, written in an evening. .Net Framefwork 4.8 is required.

It is not tested very well and it would probably fail horribly in any deviation form ideal scenario, for example, path permissions are not checked, so if a file or folder is inaccessible the program will crash.

Usage is straight forward:

- Create a new profile for a game
- Specify the game save folder and the game executable and a few options
- Select "Start watching" for the program to start monitoring the save folder and making copies whenever there is a change
- Or press "Backup" / "Restore" to backup / restore as a one off.

That's about it. The program does not prune old saves, so if unchecked, it can get out of control soon - please do it manually

Please make sure that when you are restoring, the game is not running, most games are not programmed to withstand save changes on the fly.

Icon made by [bqlqn](https://www.flaticon.com/authors/bqlqn) from [www.flaticon.com](https://www.flaticon.com)
