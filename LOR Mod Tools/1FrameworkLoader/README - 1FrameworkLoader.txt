THIS DLL IS PART OF >>>CYA'S TOOLBOX<<<. IF YOU'RE LOOKING TO INCLUDE IT IN YOUR MOD, GET THE NEWEST VERSION FROM THE MAIN UPLOAD.

1FrameworkLoader is a versioning utility for reusable DLLs.
Upon being loaded by the game's loader, it checks all mods for the presence of Assemblies\1FrameworkAssemblies subfolder.
All DLLs from such subfolders are then loaded (with DLLs with the same name being loaded in decreasing version order, skipping identical assemblies),
and then all DLLs that have been loaded in such way are initialized (and their types properly loaded into the game).
This ensures that unsigned assemblies will be loaded as their newest version, and signed assemblies as all existing versions.