// Copyright 2018, Institute for Artificial Intelligence - University of Bremen
// Author: Andrei Haidu (http://haidu.eu)
// Author: Guan Jianyu

#include "libmongo.h"
#include "Core.h"
#include "ModuleManager.h"
//#include "IPluginManager.h"

#define LOCTEXT_NAMESPACE "FlibmongoModule"

void FlibmongoModule::StartupModule()
{
	// This code will execute after your module is loaded into memory; the exact timing is specified in the .uplugin file per-module
	
//	// Get the base directory of this plugin
//	FString BaseDir = IPluginManager::Get().FindPlugin("libmongo")->GetBaseDir();
//
//	// Add on the relative location of the third party dll and load it
//	FString MongoCLibraryPath;
//	FString MongoCXXLibraryPath;
//#if PLATFORM_WINDOWS
//	MongoCLibraryPath = FPaths::Combine(*BaseDir, TEXT("Binaries/ThirdParty/libmongoc-1.0.dll"));
//	MongoCXXLibraryPath = FPaths::Combine(*BaseDir, TEXT("Binaries/ThirdParty/mongocxx.dll"));
//#endif // PLATFORM_WINDOWS
//
//	// TODO see if dynamic loading of libraries is needed
//	//LibraryHandle = !MongoCLibraryPath.IsEmpty() ? FPlatformProcess::GetDllHandle(*MongoCLibraryPath) : nullptr;
//	//LibraryHandle = !MongoCXXLibraryPath.IsEmpty() ? FPlatformProcess::GetDllHandle(*MongoCXXLibraryPath) : nullptr;
//
//	if (LibraryHandle)
//	{
//		// Call the test function in the third party library that opens a message box
//	}
//	else
//	{
//		//FMessageDialog::Open(EAppMsgType::Ok, LOCTEXT("ThirdPartyLibraryError", "Failed to load example third party library"));
//	}
}

void FlibmongoModule::ShutdownModule()
{
	// This function may be called during shutdown to clean up your module.  For modules that support dynamic reloading,
	// we call this function before unloading the module.
	
	//// Free the dll handle
	//FPlatformProcess::FreeDllHandle(LibraryHandle);
	//LibraryHandle = nullptr;
}

#undef LOCTEXT_NAMESPACE
	
IMPLEMENT_MODULE(FlibmongoModule, libmongo)