// Copyright 2017-2019, Institute for Artificial Intelligence - University of Bremen
// Author: Andrei Haidu (http://haidu.eu), Guan Jianyu

using UnrealBuildTool;


public class libmongo : ModuleRules
{
	public libmongo(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicIncludePaths.AddRange(
			new string[] {
			}
		);
		
		PrivateIncludePaths.AddRange(
			new string[] {
			}
		);
			
		
		PublicDependencyModuleNames.AddRange(
			new string[]{
			}
		);
		
		PrivateDependencyModuleNames.AddRange(
		new string[]
		{
			"Core",
			"Projects", // FPlatformProcess::GetDllHandle
		}
		);
	}
}
