// Copyright 2018, Institute for Artificial Intelligence - University of Bremen
// Author: Andrei Haidu (http://haidu.eu)
// Author: Guan Jianyu

using UnrealBuildTool;
using System;
using System.IO;

public class libmongo : ModuleRules
{
	private string ModulePath
	{
		get { return ModuleDirectory; }
	}
	
	private string ThirdPartyPath
	{
		get { return Path.Combine(ModulePath, "../ThirdParty"); }
	}
	
	private string BinariesPath
	{
		get { return Path.GetFullPath(Path.Combine(ModulePath, "../../Binaries/")); }
	}
	
	private void CopyToBinaries(string Filepath, ReadOnlyTargetRules Target)
	{
		string Filename = Path.GetFileName(Filepath);
		//string ThirdPartyBinaryPath = Path.Combine(BinariesPath, "ThirdParty");

		string BinariesPlatformPath = Path.Combine(BinariesPath, Target.Platform.ToString());
		if (!Directory.Exists(BinariesPlatformPath))
			Directory.CreateDirectory(BinariesPlatformPath);

		if (!File.Exists(Path.Combine(BinariesPlatformPath, Filename)))
			File.Copy(Filepath, Path.Combine(BinariesPlatformPath, Filename), true);
	}
	
	public libmongo(ReadOnlyTargetRules Target) : base(Target)
	{
		//// Module importing only ThirdParty assets
		//Type = ModuleType.External;

		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		
		string MongoPath = Path.Combine(ThirdPartyPath, "mongo-c-driver");

		PublicIncludePaths.AddRange(
		new string[] {
			"libmongo/Public"
			// ... add public include paths required here ...
		}
		);
				
		
		PrivateIncludePaths.AddRange(
		new string[] {
			"libmongo/Private",
			// ... add other private include paths required here ...
		}
		);
			
		
		PublicDependencyModuleNames.AddRange(
		new string[]
		{
			"Core",
			"Projects", // for IPluginManager
			// ... add other public dependencies that you statically link with here ...
		}
		);
			
		
		PrivateDependencyModuleNames.AddRange(
		new string[]
		{
			//"CoreUObject",
			//"Engine",
			//"Slate",
			//"SlateCore",
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
			PublicAdditionalLibraries.Add(Path.Combine(MongoPath, "lib", "bson-1.0.lib"));
			PublicIncludePaths.Add(Path.Combine(MongoPath, "include", "libbson-1.0"));
			CopyToBinaries(Path.Combine(MongoPath, "bin", "libbson-1.0.dll"), Target);


			PublicAdditionalLibraries.Add(Path.Combine(MongoPath, "lib", "mongoc-1.0.lib"));
			PublicIncludePaths.Add(Path.Combine(MongoPath, "include", "libmongoc-1.0"));
			CopyToBinaries(Path.Combine(MongoPath, "bin", "libmongoc-1.0.dll"), Target);

			PublicDefinitions.Add("WITH_MONGO=1");
		}
	}
}
