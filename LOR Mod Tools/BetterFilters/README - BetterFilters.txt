THIS DLL IS PART OF >>>CYA'S TOOLBOX<<<. IF YOU'RE LOOKING TO INCLUDE IT IN YOUR MOD, GET THE NEWEST VERSION FROM THE MAIN UPLOAD.

This plugin allows adding your own searchable rarities, keywords and abilities to combat page filters.
PLEASE NOTE: creating custom rarities themselves is NOT within the scope of this tool! It only allows adding them to the search filter, but you'll need to handle creating them yourself (or use another tool).
Additionally, it adds a filter by mod source, a filter by range, expands the filter by dice count and adds some configurable options.

To register new entries for filters, use EnumExtenderV2 (10EnumExtender.dll) or an equivalent to inject them into UI enums.
You will also need to add the corresponding text strings for the game to load.
I suggest using Localization Manager, which is simple, robust, and will not break if the game is ever updated (or modded) to include more localizations (as Lobotomy Corporation has repeatedly been).

EnumExtenderV2 mini-guide:
To check for an existing value corresponding to a given string name, use EnumExtender.TryGetValueOf<TEnum>(string name, out TEnum value).
If the name does not have a corresponding value yet, you can quickly find a free unnamed value with EnumExtender.TryFindUnnamedValue<TEnum>(default(TEnum), null, false, out TEnum freeValue), 
and then use that value to add the name with EnumExtender.TryAddName<TEnum>(string name, TEnum value).

To add a custom rarity to filters, inject its name/value into the Rarity enum, its name into the RarityFilterDetails enum, and add a localization string with the id "ui_rarity_{name.ToLower()}". 
(For example, "Special" becomes "ui_rarity_special")
To add a custom ability keyword to filters, inject its name into the AbilityFilterDetails enum, and add a localization string with the id "ui_ability_{name.ToLower() (without _keyword if present)}". 
(For example, "RecoverBreak_Keyword" becomes "ui_ability_recoverbreak")
To add a custom normal keyword to filters, do the same as for the abilities, but with B/buf instead of A/ability.