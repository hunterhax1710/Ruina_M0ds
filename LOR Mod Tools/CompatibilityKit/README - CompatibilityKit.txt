THIS DLL IS PART OF >>>CYA'S TOOLBOX<<<. IF YOU'RE LOOKING TO INCLUDE IT IN YOUR MOD, GET THE NEWEST VERSION FROM THE MAIN UPLOAD.

IMPORTANT USAGE NOTE! ==> This DLL needs to be placed into the Assemblies folder to work properly! <== IMPORTANT! EVEN IF YOUR MOD USES BASEMOD FOR WORKSHOP OR ANOTHER LOADER, PUT IT INTO ASSEMBLIES STILL!

A collection of performance and compatibility enhancements for some third-party mods.

Distorted Rudolph:
- Improves compatibility of "can act while staggered" effect implementation.
- Improves compatibility of "can store up to 30 Charge" effect implementation.
- Improves compatibility with custom languages (using English as default).
- Improves performance when loading attack effects.



Some notes on general compatibility considerations:

Harmony prefixes that always skip original methods ("return false") are EXTREMELY BAD FOR COMPATIBILITY IN 99% OF CASES. 
Conditional skipping prefixes (that SOMETIMES return false) can be okay, but only if you actually want NONE of the original method to run.
If you want to change one line inside a method - learn what transpilers are.

For transpilers, less means better (read: more compatible with other transpilers).
When inserting new code, do NOT write out complex algorithms in pure Opcodes, instead Ldarg/Ldloc some variables and Call a static helper method that encapsulates it (see IsRudolphRearing for an example).
When searching for a place to insert or modify code, try to formulate the shortest possible condition that characterizes that place; this way, changes done by other transpilers will be less likely to "break" your entry point.
Consider adding a log output for the case your transpiler fails to find some of its entry points, and output other transpilers for the same method (GetPatchInfo().Transpilers).


The max stack transpilers are given higher priority if they raise the max and lower priority if they lower the max, so that the effect of the latter happens after the former.
If something could either raise or lower the max depending on some other factors, it'd be split into two patches to represent this effect.

The keywordId patches that affect the name/desc are given priority equal to (Priority.Normal - newmax) as prefixes for max-raising changes, and (Priority.Normal + newmax) as postfixes for max-lowering changes.
This makes them resolve in the correct order - returning the description with the lowest lowered max if there is one, and otherwise the description with the highest raised max (if multiple such effects apply at the same time).