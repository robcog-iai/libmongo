// Copyright 2019, Institute for Artificial Intelligence - University of Bremen
// Author: Andrei Haidu (http://haidu.eu)
// Author: Guan Jianyu

#pragma once

#include "CoreMinimal.h"
#include "ModuleManager.h"

class FlibmongoModule : public IModuleInterface
{
public:

	/** IModuleInterface implementation */
	virtual void StartupModule() override;
	virtual void ShutdownModule() override;
	
	private:
	// Loads the PublicDelayLoadDLLs from the given paths
	TArray<FString> DllPaths;
	TArray<void*> DllHandles;
};