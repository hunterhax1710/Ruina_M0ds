THIS DLL IS PART OF >>>CYA'S TOOLBOX<<<. IF YOU'RE LOOKING TO INCLUDE IT IN YOUR MOD, GET THE NEWEST VERSION FROM THE MAIN UPLOAD.

Allows the player to manually change the secondary target dice of Mass Attacks and other multi-target pages (like Tanya's Beatdown).
Also makes it so switching redirects onto a Mass Attack or multi-target page does not re-randomise its secondary targets.

To enter subtargeting mode, click twice on a controllable Speed Die with a slotted Mass Attack or multi-target page. To exit, click it again, or right-click to go back to normal targeting mode. 
While in subtargeting mode, click on a secondary target character's Speed Die to set it as the new secondary target.
Note: if the page is already targeting more than one Speed Die of the same character, the closest subtarget to the left of clicked Speed Die (or the rightmost subtarget if none are to the left) will be the one changed.

By default, this allows redirecting subtargets of pages that would normally have them (i.e. pages of FarArea or FarAreaEach range with One, Team or All affection, or pages of any other non-Instance range with TeamNear affection).
This can be customized by calling DisableMassTargetingFor or EnableMassTargetingFor (note: enabling has priority over disabling!).
Additionally, subtargets can be set to not retarget into blocked dice with SetRespectBlockDice (this is mostly intended for compatibility with RespectfulTargeting, but can be used freely).