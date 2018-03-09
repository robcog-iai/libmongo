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
        get { return Path.Combine(ModuleDirectory, "../ThirdParty/"); }
    }
	
	private void CopyToBinaries(string Filepath, ReadOnlyTargetRules Target)
    {
        string BinariesDir = Path.Combine(ModulePath, "../../Binaries", Target.Platform.ToString());
        string Filename = Path.GetFileName(Filepath);

        // Create the Binaries directory if it does not exist
		if (!Directory.Exists(BinariesDir))	{
			Directory.CreateDirectory(BinariesDir);
		}	
            
		// Check if files exist, if not copy it
        if (!File.Exists(Path.Combine(BinariesDir, Filename))) {
			File.Copy(Filepath, Path.Combine(BinariesDir, Filename), true);
		}
            
    }
	
	public libmongo(ReadOnlyTargetRules Target) : base(Target)
	{
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
				// ... add other public dependencies that you statically link with here ...
			}
			);
			
		
		//PrivateDependencyModuleNames.AddRange(
		//	new string[]
		//	{
		//		"CoreUObject",
		//		"Engine",
		//		"Slate",
		//		"SlateCore",
		//		// ... add private dependencies that you statically link with here ...	
		//	}
		//	);
		
		
		//DynamicallyLoadedModuleNames.AddRange(
		//	new string[]
		//	{
		//		// ... add any modules that your module loads dynamically here ...
		//	}
		//	);
			
		if (Target.Platform == UnrealTargetPlatform.Win64)
        {
            PublicAdditionalLibraries.Add(Path.Combine(MongoPath, "lib", "bson-1.0.lib"));
            PublicIncludePaths.Add(Path.Combine(MongoPath, "include", "libbson-1.0"));
            CopyToBinaries(Path.Combine(MongoPath, "bin", "libbson-1.0.dll"), Target);


            PublicAdditionalLibraries.Add(Path.Combine(MongoPath, "lib", "mongoc-1.0.lib"));
            PublicIncludePaths.Add(Path.Combine(MongoPath, "include", "libmongoc-1.0"));
            CopyToBinaries(Path.Combine(MongoPath, "bin", "libmongoc-1.0.dll"), Target);
        }
	}
}
