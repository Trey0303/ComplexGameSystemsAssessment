#include "multithreaded.h"

void multithreaded_application::tick()
{
	//Graphics processing thread
	m_input.execute();
	m_game_logic.execute();
	m_physics.execute();
	m_pathfinding.execute();

	//Logic processing thread
}

multithreaded_application::multithreaded_application()
{
	m_renderThread = std::thread([&] {
		while (true) {
			//Must be called before rendering can occur!
			m_culling.execute();

			//rendering
			m_renderer.execute();
		}


	});
}
