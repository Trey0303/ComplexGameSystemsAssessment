#pragma once
#include "base_application.h"

class multithreaded_application : public base_application {
public:
	void tick() override;

	multithreaded_application();

private:

	//logic thread
	// main thread will be used for this

	//graphics thread
	std::thread m_renderThread;
};







