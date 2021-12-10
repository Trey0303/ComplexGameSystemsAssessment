#pragma once
#include <atomic>
#include "task.h"
#include <mutex>

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

class taskQueue {
    task** tasks;               //array of tasks
    size_t taskCapacityMax;        //tracks total capacity of the array of tasks
    std::atomic<size_t> head;   //controls where the latest task is
    std::atomic<size_t> tail;   //controls where the oldest task is

    std::mutex queueAccess;     //prevent accidentally two threads from popping/retrieving the same task 
                                //at the same time


public:
    // constructs the task queue with a given capacity
    taskQueue(size_t taskCapacity);
    // destroys the task queue
    ~taskQueue();

    // pops a task off and returns it, if any. if none, returns nullptr
    task* pop();
    // pushes a task into the queue
    void push(task* t);

    // returns true when the queue is empty, otherwise false
    bool isEmpty() const;
    // returns true when the queue is full, otherwise false
    bool isFull() const;
};