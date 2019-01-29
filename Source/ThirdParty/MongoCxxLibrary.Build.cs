// Fill out your copyright notice in the Description page of Project Settings.

using System.IO;
using UnrealBuildTool;

public class MongoCxxLibrary : ModuleRules
{
	public MongoCxxLibrary(ReadOnlyTargetRules Target) : base(Target)
	{
		Type = ModuleType.External;

		if (Target.Platform == UnrealTargetPlatform.Win64)
		{
			// .h
			PublicIncludePaths.Add(Path.Combine(ModuleDirectory, "mongo-c-driver", "include", "libbson-1.0"));
			PublicIncludePaths.Add(Path.Combine(ModuleDirectory, "mongo-c-driver", "include", "libmongoc-1.0"));
			PublicIncludePaths.Add(Path.Combine(ModuleDirectory, "mongo-cxx-driver", "include", "bsoncxx", "v_noabi"));
			PublicIncludePaths.Add(Path.Combine(ModuleDirectory, "mongo-cxx-driver", "include", "mongocxx", "v_noabi"));
			PublicIncludePaths.Add(Path.Combine(ModuleDirectory, "boost_1_69_0"));

			// Add the import library directory paths
			// .lib
			PublicLibraryPaths.Add(Path.Combine(ModuleDirectory, "mongo-c-driver", "lib"));
			PublicLibraryPaths.Add(Path.Combine(ModuleDirectory, "mongo-cxx-driver", "lib"));
			// .dll
			PublicLibraryPaths.Add(Path.Combine(ModuleDirectory, "mongo-c-driver", "bin"));
			PublicLibraryPaths.Add(Path.Combine(ModuleDirectory, "mongo-cxx-driver", "bin"));

			PublicAdditionalLibraries.Add("bson-1.0.lib");
			PublicAdditionalLibraries.Add("mongoc-1.0.lib");
			PublicAdditionalLibraries.Add("bsoncxx.lib");
			PublicAdditionalLibraries.Add("mongocxx.lib");

			// Delay-load the DLL, so we can load it from the right place first
			PublicDelayLoadDLLs.Add("libbson-1.0.dll");
			PublicDelayLoadDLLs.Add("libmongoc-1.0.dll");
			PublicDelayLoadDLLs.Add("bsoncxx.dll");
			PublicDelayLoadDLLs.Add("mongocxx.dll");

			RuntimeDependencies.Add("libbson-1.0.dll");
			RuntimeDependencies.Add("libmongoc-1.0.dll");
			RuntimeDependencies.Add("bsoncxx.dll");
			RuntimeDependencies.Add("mongocxx.dll");
		}
	}
}
