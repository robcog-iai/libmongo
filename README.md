# libmongo
Unreal Engine ThirdParty Module of MongoDB
## Quick Start
* Git clone this package into your project source directory
* Edit your project Build.cs file.
  * add *`"libbson"`* in *`PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore","libbson" });`*
* Regenerate Visual studio project file.

Then you can easily use mongo c driver by including following head file:
* `#include "bson.h"`
