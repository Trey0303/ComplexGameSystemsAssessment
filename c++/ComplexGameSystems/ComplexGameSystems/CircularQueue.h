#pragma once
using namespace std;
#include <iostream>
#include <thread>
#include <vector>
#include <mutex>
#include <atomic>


// let T represent the type of object stored in the queue
template <typename T>
class tCircularQueue
{
public:
    tCircularQueue();                 // dynamically allocates the array

    tCircularQueue(const tCircularQueue& other);            // copy constructor

    tCircularQueue& operator =(const tCircularQueue& other); // copy assignment operator

    ~tCircularQueue();                                    // cleans up any dynamically allocated data

    bool push(const T& val);          // returns true if it write a value to at the write index, otherwise false
    bool pop();                       // returns true if it pops the value at the read index, otherwise false

    const T& front() const;           // retrieves the value at the front (read index)

    bool empty() const;               // returns true if there are no unpopped elements
    size_t size() const;              // returns the current number of elements pushed
    size_t capacity() const;          // returns the maximum number of elements that can be pushed

private:
    T* arr;                                // pointer to the underlying array
    static const size_t RAW_CAPACITY = 16;  // capacity of the raw array
                                            //  - note that actual capacity will always be RAW_CAPACITY-1
                                            //  - this is ideally a power of two

    size_t arrSize = 0;

    std::atomic<size_t> readIndex;    // the first index to read from (aka front)
    std::atomic<size_t> writeIndex;   // the next index to write to (aka back)
};


