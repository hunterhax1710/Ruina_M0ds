THIS DLL IS PART OF >>>CYA'S TOOLBOX<<<. IF YOU'RE LOOKING TO INCLUDE IT IN YOUR MOD, GET THE NEWEST VERSION FROM THE MAIN UPLOAD.

Contains various tweaks to the targeting system, making it respect some conditions that are exposed but overlooked by the base game.

- Makes the targeting functions (in autoplay and in secondary targets of mass attacks) properly obey restrictions on targetable speed dice (CheckBlockDice).
- In turn, makes the aforementioned restrictions obey statuses that remove untargetability (NonTargetableRemoved).
- Makes units be properly recognized as untargetable if all their speed dice are untargetable.
- Fixes autoplay breaking as soon as one of player units fails to find a target.
- Fixes player units only autotargeting the first speed die of enemies with a "last speed die is untargetable" passive.
- Fixes autoplay (both on player and enemy sides) ignoring IsOnlyAllyUnit and IsValidTarget of selected combat pages.