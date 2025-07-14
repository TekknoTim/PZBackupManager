PZ Backup Manager Changelog:
[v0.6.0] - [14.07.2025] - [Debug & ScriptHook Enhancements]
 1. - Added: Debug Logger: Prints out debug information to a file. Can be enabled by changing "DebugLog" to true, in the config.json.
 2. - Added: Folder & File Shortcuts, to open directories or files directly from the "About Window"
 3. - Added: A "trick" to enable experimental features within the app. (Double click the racoons nose on the "About Window" picture.)
 4. - Added: A new ScriptHook Command (command=o), to unminimize and show up the manager, when minimized or added to taskbar. (Must be connected to the Mod min version 0.7)
 5. - Added: The Scripthook now prints the backupfolder name to the ini file as well. (Will be used in the mods statistics feature)
 6. - Changed: Moved the Data Cleaner to the settings drop down menu.
 7. - Added: Experimental: A lot of experimental stuff which isn't finished yet, and will only be accessable when experimental features are enabled.
	  More info's about that are coming in the next update.

[v0.0.62] - [15.05.2025] - [Windows loading issue fixes]
 1. - Fixed: Errors when using & closing either the ScriptHookWindow or BackupDataCleanerWindow.
 2. - Fixed: The backup done confirmation messagebox was showing the wrong number of the new backup.
 3. - Added: A hidden method, to reload the main window, which is done by clicking the main headline label (Top left Headline)
 
[v0.0.61] - [14.05.2025] - [Fonts not loading hotfix]
 1. - Fixed: Fonts should now load properly.

[v0.0.6] - [12.05.2025] - [BugFixing & Cosmetic Adjustments] - [LATEST]
 1. - Fixed: If the PZBaMaScriptHook.ini contains just a single line, updating with savegame validation fails.
 2. - Added: A fontloader class, to load embedded fonts, to make loading them possible on all windows systems.
 3. - Added: Licenses for the fonts & this application as well. (License added: MIT_License -> "LICENSE.md")
 4. - Fixed: The MainWindow and Cleanup Window headlines font should now load on systems, that don't have them installed.

[v0.0.5] - [10.05.2025] - [CleanUp Tools & Basic StatusLog Overhaul] - [Unpublished/Skipped]

 1. - Added: A new form, which can be opened, by pressing the "CLEANUP" button on the MainWindow.
 2. - Added: A function to search the backup directory for unlisted backup directories.
 3. - Added: A function to search the backup directory for broken or missing json data files.
 4. - Added: A function to automatically search the backup directory for unlisted folders, broken or missing json data files & deleting them afterwards.
 5. - Changed: The font type of the listboxes to a monospace font, to make the text appiering more pretty.
 6. - Added: AutoCleanUpHelper file, to explain, how the backup manager works & what it is even for.

[v0.0.4] - [23.04.2025] - [ScriptHook overhaul, Versioning & More] - [Unpublished/Skipped]

[IMPORTANT] - [For the newest workshop mod to work, this version is from now on the minimum requirement!] - [IMPORTANT]
 1. - Changed: They way, the script hook is communicating with the workshop mod. 
 2. - Changed: Autodeletion will now adjust to the number of already existing backups, if the user
			 don't want to delete the extant.
 3. - Added: A version file, for both programs to notice the user about updates. 
 4. - Added: Savegame validation. Can be enabled in the mods option menu.
			 Checks if the correct savegame is selected when doing an update via the workshop mod
 5. - Added: Automatic savegame selection. If the wrong savegame is selected,
			 you can switch to the correct one by pressing a UI button ingame.
 6. - Added: The changelog will be shown after an update or fresh installation once.
 7. - Fixed: The app verion. Last updates version were wrong & will be adjusted to the right one with this update.
 8. - Fixed: Some "File not exist" issues.

[v0.0.3] - [09.04.2025] - [More UI Cleanup & Autodelete Update] - [LAST RELEASE]

 1. - Added: Toolbar menu at the top of the main window.
 2. - Changed : Removed the both checkboxes and moved them into the "General" toolbar tab, which can be found under "Settings".
 3. - Added: A check,  if the program is already running, to prevent the start of multiple instances.
 4. - Added: An about window to show app informations like version, author & GitHub link.
 5. - Added: an about page option to the toolbarMenu.
 6. - Added: a feature (Autodelete), which allows to keep a chosen amount of backups.
 7. - Added: a toolbar option, to access the Autodelete feature setup panel.

 Experimental:
 1. - Added: an option to compress backups to zip.
 2. - Added: an option to compress backups automatic after each backup.
 3. - Info: Made all experimental options inaccessable for normal users by disabling all at app start.
           (Can be reenabled by changing following property to "true", in the config.json -> [ExperimentalFeatures])

[v0.0.2] - [31.03.2025] - [Small UI Cleanup & Taskbar Operation Update]

1. - Changed: Replaced following buttons: "Delete All, Delete, Rename" with a Context Menu, which can be accessed via a right click on a backup.
2. - Added: The possibility to select & delete multiple backups as well as all of them.
3. - Added: A process window with progressbars, if more than one deletion is requested.
4. - Changed: the way, backups are getting deleted, if more than 1 was selected. Now each backup will be deleted, one after another, with a button, to cancel the process, before the following backups will get deleted as well.
5. - Added: A notification icon inc. checkbox (to disable) in the ScriptHook window, which will hide the complete app after minimizing & add a notification icon with context menu to the taskbar.
6. - Fixed: Too much to remember. Alot, but probably added many more bugs! :P

[v0.0.1] - [27.03.2025] - [Initial release]

1. - The initial release of the program