#pragma once
#include <atomic>
#include "task.h"

class incrementTask : public task {
    // declare (but doesn't define) a static `val` member variable
    static std::atomic<int> val;

public:

    // task action
    void execute()//Every time we queue this task, the value of val should increase by one when it is executed.
    {
        ++val;
    }

    // static variable management
    static int getVal()
    {
        return val;
    }

    static void resetVal()
    {
        val = 0;
    }
};