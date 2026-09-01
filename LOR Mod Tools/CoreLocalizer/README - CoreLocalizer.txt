THIS DLL IS PART OF >>>CYA'S TOOLBOX<<<. IF YOU'RE LOOKING TO INCLUDE IT IN YOUR MOD, GET THE NEWEST VERSION FROM THE MAIN UPLOAD.

A localization tool to add custom languages into the game easier.
USAGE NOTE: this is made for localizing the BASE GAME! For localizing MODDED CONTENT the recommended tool is Localization Manager.
This tool is configured through XML files named CoreLocalizeInfo.xml, which should be located in the mod's root (NOT in Assemblies!).
An annotated example of such a config file (named CoreLocalizeInfoExample.xml) is provided with this dll (if it's not, refer to the disclaimer at the top).
Additionally, some normally non-localizable text elements can be replaced with custom text; refer to _UITexts_CoreLoc (in your mod it should be named LANG_UITexts_CoreLoc, placed next to LANG_UITexts).
NOTE: one combat dialogue file (EN_CombatDialog_The Blue Reverberation) is MISSING from the English localization in the base game! It is included in this folder for ease of access (note that the localized version will, again, need to be prefixed with your language code instead of EN, and placed in the corresponding subfolder of BattleDialogues).

Supported resource replacements/paths (square brackets NOT INCLUDED IN PATHS, they're just there to indicate what coding elements the naming scheme corresponds to):
	Typical sprites (located in the resource folder):
		Story backgrounds: BgSprites\[dlgEffect.bg.src].png
		Story characters: StoryCharacters\[name]\[sprite].png
		Combat pages: BattleCards\[Artwork].png
		Status effect icons: BufIcons\[keywordIconId].png
		Reception icons and similar (IconSet): StoryIcons\[iconSet.type]\icon.png and StoryIcons\[iconSet.type]\iconGlow.png
	Special sprites (located in the resource folder\SpecialSprites):
		Title screen subtitle: TitleLogoSubText.png
		Title screen subtitle (postgame version): RuinTitleUI_SubTitle.png
		End of reception splash screens: Victory.png and Defeat.png
		Sephirah named frames (for the library "tower view"): Malkut.png, Yesod.png, Netzach.png, Tiphereth.png, Geburah.png, Chesed.png, Binah.png, Hokma.png, KetherL.png and KetherR.png
		Silent Orchestra movement splash texts: OrchestraMovement[1-5].png
		The final credits segment: AndYou.png