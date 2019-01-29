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
	
	private void CopyToBinaries(string Filepath, ReadOnlyTargetRules Target)
	{
		string Filename = Path.GetFileName(Filepath);

		string BinariesPlatformPath = Path.Combine(BinariesPath, Target.Platform.ToString());
		if (!Directory.Exists(BinariesPlatformPath))
		{
			Directory.CreateDirectory(BinariesPlatformPath);
		}

		if (!File.Exists(Path.Combine(BinariesPlatformPath, Filename)))
		{
			File.Copy(Filepath, Path.Combine(BinariesPlatformPath, Filename), true);
		}
	}
	
	public libmongo(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		
		// Use this if the module does not implement a IModuleInterface
		//Type = ModuleType.External;

		bEnableUndefinedIdentifierWarnings = false;
		bEnableExceptions = true;

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
			"Projects", // FPlatformProcess::GetDllHandle
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

		string MongoCDir = Path.Combine(ThirdPartyPath, "mongo-c-driver");
		string MongoCXXDir = Path.Combine(ThirdPartyPath, "mongo-cxx-driver");
		string BoostDir = Path.Combine(ThirdPartyPath, "boost_1_69_0");

		if (Target.Platform == UnrealTargetPlatform.Win64)
		{
			// .h
			PublicIncludePaths.Add(Path.Combine(MongoCDir, "include", "libbson-1.0"));
			PublicIncludePaths.Add(Path.Combine(MongoCDir, "include", "libmongoc-1.0"));
			PublicIncludePaths.Add(Path.Combine(MongoCXXDir, "include", "bsoncxx", "v_noabi"));
			PublicIncludePaths.Add(Path.Combine(MongoCXXDir, "include", "mongocxx", "v_noabi"));
			PublicIncludePaths.Add(Path.Combine(BoostDir));

			// .lib
			PublicAdditionalLibraries.Add(Path.Combine(MongoCDir, "lib", "bson-1.0.lib"));
			PublicAdditionalLibraries.Add(Path.Combine(MongoCDir, "lib", "mongoc-1.0.lib"));
			PublicAdditionalLibraries.Add(Path.Combine(MongoCXXDir, "lib", "bsoncxx.lib"));
			PublicAdditionalLibraries.Add(Path.Combine(MongoCXXDir, "lib", "mongocxx.lib"));

			//// List of delay load DLLs - typically used for External (third party) modules
			//// see (FPlatformProcess::GetDllHandle(Path)) for loading
			//PublicDelayLoadDLLs.Add(Path.Combine(MongoCDir, "bin", "libbson-1.0.dll"));
			//PublicDelayLoadDLLs.Add(Path.Combine(MongoCDir, "bin", "libmongoc-1.0.dll"));
			//PublicDelayLoadDLLs.Add(Path.Combine(MongoCXXDir, "bin", "bsoncxx.dll"));
			//PublicDelayLoadDLLs.Add(Path.Combine(MongoCXXDir, "bin", "mongocxx.dll"));

			// Copy dll's to plugin /Binaries
			CopyToBinaries(Path.Combine(MongoCDir, "bin", "libbson-1.0.dll"), Target);
			CopyToBinaries(Path.Combine(MongoCDir, "bin", "libmongoc-1.0.dll"), Target);
			CopyToBinaries(Path.Combine(MongoCXXDir, "bin", "bsoncxx.dll"), Target);
			CopyToBinaries(Path.Combine(MongoCXXDir, "bin", "mongocxx.dll"), Target);

			//// List of files which this module depends on at runtime. These files will be staged along with the target.
			//RuntimeDependencies.Add(Path.Combine(MongoCDir, "bin", "libbson-1.0.dll"));
			//RuntimeDependencies.Add(Path.Combine(MongoCDir, "bin", "libmongoc-1.0.dll"));
			//RuntimeDependencies.Add(Path.Combine(MongoCXXDir, "bin", "bsoncxx.dll"));
			//RuntimeDependencies.Add(Path.Combine(MongoCXXDir, "bin", "mongocxx.dll"));

		}
	}
}
