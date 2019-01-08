# libmongo

* Unreal Engine ThirdParty Plugin with MongoDB drivers

* Supported engine version: **UE 4.21**

## Quick Start

* Git clone this package into your `Plugins` directory
* Edit your project `Build.cs` file by adding:

  * *`"libmongo"`* in *`PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore","libmongo" });`*

Use the **c** library by including the required headers:

* `#include "mongoc.h"`
* `#include "bson.h"`

Use the **c++** library by including the required headers:

* `#include <bsoncxx/builder/stream/document.hpp>`
* `#include <bsoncxx/json.hpp>`
* `#include <mongocxx/client.hpp>`
* `#include <mongocxx/instance.hpp>`
* `..`





