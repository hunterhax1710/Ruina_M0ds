THIS DLL IS PART OF >>>CYA'S TOOLBOX<<<. IF YOU'RE LOOKING TO INCLUDE IT IN YOUR MOD, GET THE NEWEST VERSION FROM THE MAIN UPLOAD.

Adds a tutorial panel for the Special range of Combat Pages, and handles displaying it when needed. 
Also handles displaying Ranged/Counter tutorial panels if enemies use such pages before Full-Stop/Puppets respectively.

Additionally, includes the following fixes formerly present in SpecialRangeFix (which is now DEPRECATED):
Fixes the Special vs. Melee range priority to be more consistent (by eliminating a rare case of Melee pages being able to take priority over Special pages 
if the former happens to already be in very close proximity of its target at the time of next clash determination).
Fixes an oversight in the start-of-scene page sorting that could result in the left-to-right order being violated.

Known incompatibilities for the latter fixes:
Distorted Rudolph (due to entirely replacing the stage phase where the priority sorting takes place) (fixed by Compatibility Kit)