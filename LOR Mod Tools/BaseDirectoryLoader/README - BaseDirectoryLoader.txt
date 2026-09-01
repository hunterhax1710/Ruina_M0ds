THIS DLL IS PART OF >>>CYA'S TOOLBOX<<<. IF YOU'RE LOOKING TO INCLUDE IT IN YOUR MOD, GET THE NEWEST VERSION FROM THE MAIN UPLOAD.

This plugin allows the default files specified in StageModInfo to be loaded according to directory paths instead of file paths.
For example, if the card path is set to Data\CardInfo, and Data\CardInfo is a directory containing multiple files,
for each of these files an attempt will be made to load it as card xml.
Additionally, this plugin also provides improved logging of errors that happen during default file loading
(including the file path), and also automatically performs duplicate id checks and logs the specific ids.

IMPORTANT: this plugin requires 1FrameworkPriorityInjector/1FrameworkPriorityLoader to work correctly!