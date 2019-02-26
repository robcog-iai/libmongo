// Copyright 2019, Institute for Artificial Intelligence - University of Bremen
// Author: Andrei Haidu (http://haidu.eu)

using UnrealBuildTool;
using System;
using System.IO;

public class MongoCxx : ModuleRules
{
	private string BinariesPath
	{
		get { return Path.GetFullPath(Path.Combine(ModuleDirectory, "../../Binaries/")); }
	}

	private void CopyToBinaries(string SourceFilePath, ReadOnlyTargetRules Target)
	{
		string Filename = Path.GetFileName(SourceFilePath);
		string BinariesPlatformPath = Path.Combine(BinariesPath, Target.Platform.ToString());

		//System.Console.WriteLine("Copying {0} to {1}", SourceFilePath, BinariesPlatformPath);

		if (!Directory.Exists(BinariesPlatformPath))
		{
			Directory.CreateDirectory(BinariesPlatformPath);
		}

		if (!File.Exists(Path.Combine(BinariesPlatformPath, Filename)))
		{
			File.Copy(SourceFilePath, Path.Combine(BinariesPlatformPath, Filename), true);
		}
	}

	public MongoCxx(ReadOnlyTargetRules Target) : base(Target)
	{
		// We are just setting up paths for pre-compiled binaries.
		Type = ModuleType.External;

		bEnableUndefinedIdentifierWarnings = false;
		bEnableExceptions = true;
		//bUseRTTI = true;

		PublicDependencyModuleNames.Add("MongoC");

		if (Target.Platform == UnrealTargetPlatform.Win64)
		{
			// .h
			string HeadersDir = ModuleDirectory + "/mongo-cxx-driver/include/";
			string BoostDir = ModuleDirectory + "/boost_1_69_0/";
			PublicIncludePaths.Add(Path.Combine(HeadersDir, "bsoncxx", "v_noabi"));
			PublicIncludePaths.Add(Path.Combine(HeadersDir, "mongocxx", "v_noabi"));
			PublicIncludePaths.Add(BoostDir);

			// .lib
			string LibsDir = ModuleDirectory + "/mongo-cxx-driver/lib/";
			PublicLibraryPaths.Add(LibsDir);
			PublicAdditionalLibraries.Add("bsoncxx.lib");
			PublicAdditionalLibraries.Add("mongocxx.lib");

			// .dll
			string BinDir = ModuleDirectory + "/mongo-cxx-driver/bin/";
			//RuntimeDependencies.Add(Path.Combine(BinDir, "bsoncxx.dll"));
			//RuntimeDependencies.Add(Path.Combine(BinDir, "mongocxx.dll"));

			CopyToBinaries(Path.Combine(BinDir, "bsoncxx.dll"), Target);
			CopyToBinaries(Path.Combine(BinDir, "mongocxx.dll"), Target);
		}
	}
}
