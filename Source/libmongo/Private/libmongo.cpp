// Copyright 2017-2019, Institute for Artificial Intelligence - University of Bremen
// Author: Andrei Haidu (http://haidu.eu)
// Author: Guan Jianyu

#include "libmongo.h"
#include "Core.h"
#include "ModuleManager.h"
#include "IPluginManager.h"

#define LOCTEXT_NAMESPACE "FlibmongoModule"

void FlibmongoModule::StartupModule()
{
	// This code will execute after your module is loaded into memory; the exact timing is specified in the .uplugin file per-module
	
	// Get the base directory of this plugin
	FString BaseDir = IPluginManager::Get().FindPlugin("libmongo")->GetBaseDir();

	// Add on the relative location of the third party dll and load it
#if PLATFORM_WINDOWS
	//DllPaths.Add(FPaths::Combine(*BaseDir, TEXT("Source/ThirdParty/mongo-c-driver/bin/libmongoc-1.0.dll")));
	//DllPaths.Add(FPaths::Combine(*BaseDir, TEXT("Source/ThirdParty/mongo-c-driver/bin/libbson-1.0.dll")));
	//DllPaths.Add(FPaths::Combine(*BaseDir, TEXT("Source/ThirdParty/mongo-cxx-driver/bin/mongocxx.dll")));
	//DllPaths.Add(FPaths::Combine(*BaseDir, TEXT("Source/ThirdParty/mongo-cxx-driver/bin/bsoncxx.dll")));
#endif // PLATFORM_WINDOWS

	// Load the dlls
	for (const auto& Path : DllPaths)
	{
		void* DllHandle = FPlatformProcess::GetDllHandle(*Path);
		//if (DllHandle)
		//{
		//	UE_LOG(LogTemp, Warning, TEXT("%s::%d %s successfully loaded"), TEXT(__FUNCTION__), __LINE__, *Path);
		//}
		//else
		//{
		//	UE_LOG(LogTemp, Error, TEXT("%s::%d %s could not be loaded"), TEXT(__FUNCTION__), __LINE__, *Path);
		//}
	}
}

void FlibmongoModule::ShutdownModule()
{
	// This function may be called during shutdown to clean up your module.  For modules that support dynamic reloading,
	// we call this function before unloading the module.
	
	// Free all the dll handles
	for (void* Handle : DllHandles)
	{
		check(Handle != nullptr);
		FPlatformProcess::FreeDllHandle(Handle);
		Handle = nullptr;
	}
}

IMPLEMENT_MODULE(FlibmongoModule, libmongo)

#undef LOCTEXT_NAMESPACE