#include "incrementTask.h"

// declares and defines (thus allocating memory for) the `val` static member variable
std::atomic<int> incrementTask::val = 0;
