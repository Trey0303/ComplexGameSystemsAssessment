#pragma once
#include "base_application.h"
#include <mutex>
#include <atomic>

class multithreaded_application : public base_application {
public:
	void tick() override;

	multithreaded_application();

private:
	//graphics thread
	std::thread m_renderThread;           //creates a thread for handling graphics

	std::mutex m_render_data_mutex;       //mutex lock for locking/unlocking threads to prevent overlap

	std::atomic<bool> m_waiting_to_write; //helps give priority to game logic to prevent from getting stuck


	//pathfinding
	std::thread m_pathfindingThread;

	std::mutex m_pathfinding_mutex;


};







