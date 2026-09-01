THIS DLL IS PART OF >>>CYA'S TOOLBOX<<<. IF YOU'RE LOOKING TO INCLUDE IT IN YOUR MOD, GET THE NEWEST VERSION FROM THE MAIN UPLOAD.

1FrameworkPriorityInjector (1FPI) is a portable priority mod installer, distributed as a 1FrameworkLoader plugin.
Upon passing mod initialization, it extracts all necessary files from inside its own DLL and installs a mod named 1Framework Priority Loader (1FPL).
That mod contains nothing but Harmony, Harmony dependencies, 00HarmonyPreloader and 1FrameworkLoader;in addition, 1FPI pushes 1FPL to the top of the mod loading order.
This ensures that 1Framework assemblies will be loaded ahead of all other assemblies.