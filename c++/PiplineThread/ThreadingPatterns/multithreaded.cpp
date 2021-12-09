#include "multithreaded.h"

void multithreaded_application::tick()
{
	//Logic processing thread
	m_input.execute();
	m_game_logic.execute();
	m_physics.execute();
	//m_pathfinding.execute();
	

	//also need to place lock around update render execute
	m_waiting_to_write = true;
	m_render_data_mutex.lock();

	m_waiting_to_write = false;
	m_update_render_data.execute();

	m_render_data_mutex.unlock();

}

multithreaded_application::multithreaded_application() : m_waiting_to_write(false)
{
	//Graphics processing thread
	m_renderThread = std::thread([&] {
		while (true) {
			if (!m_waiting_to_write) {
				//lock to prevent graphics thread from executing the same time while update render system is executing
				m_render_data_mutex.lock();

				//Must be called before rendering can occur!
				m_culling.execute();

				//rendering
				m_renderer.execute();

				//unlocks when threads turn is done executing
				m_render_data_mutex.unlock();

			}


			
		}


	});

	m_pathfindingThread = std::thread([&] {
		while (true) {
			if (!m_waiting_to_write) {
				m_pathfinding_mutex.lock();

				m_pathfinding.execute();

				m_pathfinding_mutex.unlock();
			}
		}

	});
}
