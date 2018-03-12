# libmongo
Unreal Engine ThirdParty Plugin with MongoDB drivers

## Quick Start

* Git clone this package into your `Plugins` directory
* Edit your project `Build.cs` file by adding:

  * *`"libmongo"`* in *`PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore","libmongo" });`*

Use mongo **c** driver by including the required headers:

* `#include "mongoc.h"`
* `#include "bson.h"`
