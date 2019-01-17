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
	
	//private:
	///** Handle to the test dll we will load */
	//void* LibraryHandle;
};