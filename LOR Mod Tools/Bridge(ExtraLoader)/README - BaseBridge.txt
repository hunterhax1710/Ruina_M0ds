THIS DLL IS PART OF >>>CYA'S TOOLBOX<<<. IF YOU'RE LOOKING TO INCLUDE IT IN YOUR MOD, GET THE NEWEST VERSION FROM THE MAIN UPLOAD.

The primary function of this plugin is to "bridge" the gap between different ways of supporting more compatible and less conflict-prone identifiers (which in most cases means LorId).
This interoperability is facilitated by allowing other assemblies to register their own ways of producing keys for values (and looking up values by keys).

Secondary functions of this plugin involve automatically handling saving of custom gifts (battle symbols) integrated with it, 
in a manner that does not corrupt save data if mods are disabled, but also is natively compatible with different save files
and persists if a mod is temporarily disabled (although a way to remove the gift from the safe save is also available if needed);

as well as handling the generation of custom passive innertypes integrated with it (to avoid resolution order conflicts).