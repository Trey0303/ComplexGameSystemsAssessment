
/* @brief Application launch point for single threaded game loop
    with imposter tasks.
*/
//#include "single_threaded_application.h"
#include "multithreaded.h"

int main()
{
	multithreaded_application application;
    while (true)
    {
		application.tick();
    }
    return 0;
}


