THIS DLL IS PART OF >>>CYA'S TOOLBOX<<<.
IF YOU'RE LOOKING TO INCLUDE IT IN YOUR MOD,
GET THE NEWEST VERSION FROM THE MAIN UPLOAD.

A convenient utility to clean up pre-game mod loading logs, mostly aimed
at removing "assembly already exists" warnings (but arbitrary conditions 
for a log line to be removed are also supported).
If possible, uses Harmony patching to optimize log cleaning (by only doing it
once before the logs are displayed, instead of every time CleanUp is called).