# libmongo
Unreal Engine ThirdParty Module of MongoDB
## Quick Start
* Git clone this package into your `Plugins` directory
* Edit your project Build.cs file:

  * add *`"libmongo"`* in *`PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore","libmongo" });`*

Use mongo c driver by including the required headers:

* `#include "mongoc.h"`
* `#include "bson.h"`
