// Copyright 2019, Institute for Artificial Intelligence - University of Bremen
// Author: Andrei Haidu (http://haidu.eu)
// Author: Guan Jianyu

using UnrealBuildTool;
using System;
using System.IO;

public class libmongo : ModuleRules
{
	private string ThirdPartyPath
	{
		get { return Path.Combine(ModuleDirectory, "../ThirdParty"); }
	}
	
	private string BinariesPath
	{
		get { return Path.GetFullPath(Path.Combine(ModuleDirectory, "../../Binaries/")); }
	}

	
	public libmongo(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;

		bEnableUndefinedIdentifierWarnings = false;
		bEnableExceptions = true;

		string MongoCPath = Path.Combine(ThirdPartyPath, "mongo-c-driver");
		string MongoCXXPath = Path.Combine(ThirdPartyPath, "mongo-cxx-driver");
		string BoostPath = Path.Combine(ThirdPartyPath, "boost_1_69_0");

		PublicIncludePaths.AddRange(
		new string[] {
			// ... add public include paths required here ...
		}
		);
				
		
		PrivateIncludePaths.AddRange(
		new string[] {
			// ... add other private include paths required here ...
		}
		);
			
		
		PublicDependencyModuleNames.AddRange(
		new string[]
		{
			"Core",
			//"Projects", // for IPluginManager
			// ... add other public dependencies that you statically link with here ...
		}
		);
			
		
		PrivateDependencyModuleNames.AddRange(
		new string[]
		{
			// ... add private dependencies that you statically link with here ...	
		}
		);
		
		
		DynamicallyLoadedModuleNames.AddRange(
		new string[]
		{
			// ... add any modules that your module loads dynamically here ...
		}
		);

		if (Target.Platform == UnrealTargetPlatform.Win64)
		{
			// .lib
			PublicAdditionalLibraries.Add(Path.Combine(MongoCPath, "lib", "bson-static-1.0.lib"));
			PublicAdditionalLibraries.Add(Path.Combine(MongoCPath, "lib", "mongoc-static-1.0.lib"));
			PublicAdditionalLibraries.Add(Path.Combine(MongoCXXPath, "lib", "bsoncxx-static.lib"));
			PublicAdditionalLibraries.Add(Path.Combine(MongoCXXPath, "lib", "mongocxx-static.lib"));
			PublicAdditionalLibraries.Add(Path.Combine(MongoCPath, "lib", "bson-1.0.lib"));
			PublicAdditionalLibraries.Add(Path.Combine(MongoCPath, "lib", "mongoc-1.0.lib"));
			PublicAdditionalLibraries.Add(Path.Combine(MongoCXXPath, "lib", "bsoncxx.lib"));
			PublicAdditionalLibraries.Add(Path.Combine(MongoCXXPath, "lib", "mongocxx.lib"));

			// .h
			PublicIncludePaths.Add(Path.Combine(MongoCPath, "include", "libbson-1.0"));
			PublicIncludePaths.Add(Path.Combine(MongoCPath, "include", "libmongoc-1.0"));
			PublicIncludePaths.Add(Path.Combine(MongoCXXPath, "include", "bsoncxx", "v_noabi"));
			PublicIncludePaths.Add(Path.Combine(MongoCXXPath, "include", "mongocxx", "v_noabi"));
			PublicIncludePaths.Add(Path.Combine(BoostPath));
		}
	}
}
