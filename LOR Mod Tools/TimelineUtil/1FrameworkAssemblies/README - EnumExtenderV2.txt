THIS DLL IS PART OF >>>CYA'S TOOLBOX<<<.
IF YOU'RE LOOKING TO INCLUDE IT IN YOUR MOD,
GET THE NEWEST VERSION FROM THE MAIN UPLOAD.

A utility for working with name/value pairs cached within enum types.

C# enums are not limited to their listed values. It is possible to explicitly
cast ints to enums with "(Enumtype)intvalue". However, doing so invites
compatibility issues, as this gives different mods no way of knowing which
non-standard values are used by others.
Thus, EnumExtenderV2 injects names/values into the internal cache stored
within the enum type. These added values can then be read from that cache
by EnumExtenderV2 or any similar tools. As a bonus, these values thus become
recognizable by most enum name/value methods like Parse, IsDefined or ToString.

NOTE 1: names of different enum values CANNOT coincide.
If you need to add a value for use by a specific mod, ensure that the name will
be unique to that mod (for example, by prefixing it like MODNAME_ENUMNAME).
Additionally, custom enum names need to conform to the same standards as ones
normally defined in C# code (for compatibility reasons).
Also, AVOID using TryAddName on fixed values (i.e. not values obtained from
TryFindUnnamedValue or ensured to be unnamed otherwise), as that can defeat
the entire compatibility effort.

NOTE 2: AS OF VERSION 2.1.0, enum names and values added by EnumExtenderV2
CANNOT be directly recognized by standard XML serialization tools. The latter
use dynamically generated assemblies based on reflection, not internal caches,
and therefore cannot be fooled as easily.
Additionally, as standard XML files of each mod are loaded BEFORE DLL files,
it would be impossible for a mod to inject custom values before its regular
XMLs are loaded, and custom XMLs can be deserialized in a custom way already.