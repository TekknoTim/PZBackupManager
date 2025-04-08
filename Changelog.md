PZ Backup Manager Changelog:

[v0.0.3] - [09.04.2025] - [More UI Cleanup & Autodelete Update]

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