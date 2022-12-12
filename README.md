# Delete-RDP-files-Script

Hello! 

This program will delete all specified files in a folder with certian names or extensions.

Please see config.json to edit which folder to delete from (to change to YOUR downloads folder C:/Users/{YOUR USER NAME}/Downloads.
Please see config.json to edit which types of files to delete. (default is *.rdp which will delete all files ending with .rdp)

=======RECCOMENDED=======
This program can be run automatically on a schedule with Window's Task Scheduler.

1) In order to do this, hit "start" and search Task Scheduler. (if it is not in search, check control panel)
2) Hit "create task" on the left of the window.
3) Enter name of task
4) Navigate to "Triggers" and set the time interval in which to run the task. ( I have it run everyday at 6pm.)
5) Navigate to "Actions" and enter the following:
  Action: Start a Program
  Program/Script: SELECT FOLDER WHERE "Downloads Cleaner.exe" is located
  Ok:
6) wait for program to run based on the time interval you set :D
