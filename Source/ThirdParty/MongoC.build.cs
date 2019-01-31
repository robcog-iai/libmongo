// Copyright 2019, Institute for Artificial Intelligence - University of Bremen
// Author: Andrei Haidu (http://haidu.eu)

using UnrealBuildTool;
using System;
using System.IO;

public class MongoC : ModuleRules
{
	public MongoC(ReadOnlyTargetRules Target) : base(Target)
	{
		// We are just setting up paths for pre-compiled binaries.
		Type = ModuleType.External;

		bEnableUndefinedIdentifierWarnings = false;
		bEnableExceptions = true;
		//bUseRTTI = true;


		if (Target.Platform == UnrealTargetPlatform.Win64)
		{
			// .h
			string HeadersDir = ModuleDirectory + "/mongo-c-driver/include/";
			PublicIncludePaths.Add(Path.Combine(HeadersDir, "libbson-1.0"));
			PublicIncludePaths.Add(Path.Combine(HeadersDir, "libmongoc-1.0"));

			// .lib
			string LibsDir = ModuleDirectory + "/mongo-c-driver/lib/";
			PublicLibraryPaths.Add(LibsDir);
			PublicAdditionalLibraries.Add("bson-1.0.lib");
			PublicAdditionalLibraries.Add("mongoc-1.0.lib");

			// .dll
			string BinDir = ModuleDirectory + "/mongo-c-driver/bin/";
			RuntimeDependencies.Add(Path.Combine(BinDir, "libbson-1.0.dll"));
			RuntimeDependencies.Add(Path.Combine(BinDir, "libmongoc-1.0.dll"));
		}
	}
}
