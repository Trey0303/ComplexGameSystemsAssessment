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

	bool full() const;				  // return true if we can't push any more elements
    bool empty() const;               // returns true if there are no unpopped elements
    size_t size() const;              // returns the current number of elements pushed
    size_t capacity() const;          // returns the maximum number of elements that can be pushed

private:
    T* arr;                                // pointer to the underlying array
    static const size_t RAW_CAPACITY = 16;  // capacity of the raw array
                                            //  - note that actual capacity will always be RAW_CAPACITY-1
                                            //  - this is ideally a power of two

    //size_t arrSize = 0;
	//int count = 0;

    std::atomic<size_t> readIndex;    // the first index to read from (aka front)
    std::atomic<size_t> writeIndex;   // the next index to write to (aka back)
};


template<typename T>
tCircularQueue<T>::tCircularQueue()//initaializes array
{
	arr = new T[capacity()];
	//arrSize = 0;

	readIndex = 0;
	writeIndex = 0;
}

//template<typename T>
//tCircularQueue<T>::tCircularQueue(const tCircularQueue& other)// copy constructor
//{
//	T* arrCopy = new T[other.arrSize];
//}
//
//template<typename T>
//tCircularQueue<T>& tCircularQueue<T>::operator =(const tCircularQueue& other) { // copy assignment operator
//
//	//delete old arr data
//	while (readIndex != nullptr) {
//		pop();
//		
//	}
//	readIndex = 0;
//	writeIndex = 0;
//
//	//overwrite with other data
//	if (other.readIndex != nullptr) {
//		for (int i = 0; i < other.arrSize; i++) {
//			//	//copy all that is stored inside other array
//			arr[i] = other[i];
//			arrSize = other.arrSize;
//		}
//	}
//
//	return *this;
//}

// cleans up any dynamically allocated data
template<typename T>
tCircularQueue<T>::~tCircularQueue()//delete array
{
	delete[] arr;
}


// returns true if it write a value to at the write index, otherwise false
template<typename T>
bool tCircularQueue<T>::push(const T& val)
{
	if (full()) {//if write index was to increase would it end up on the same position as readIndex
		return false;
	}
	else {//push val at the back of arr
		int curIndex = writeIndex;//gets last index
		int nextIndex = curIndex + 1;//get pointer to next index
		arr[curIndex] = val;//val set as new last index
		writeIndex = nextIndex;//set curIndex pointer to next index position

		if (writeIndex >= RAW_CAPACITY) {
			writeIndex = 0;
		}
		
		return true;
	}
}

// returns true if it pops the value at the read index, otherwise false
template<typename T>
bool tCircularQueue<T>::pop()
{
	if (empty()) {//if empty
		return false;
	}
	//delete front value
	else {
		int curIndex = readIndex;//get current front index
		int nextIndex = ++curIndex;
		readIndex = nextIndex;//set next index as new current front index
		return true;
	}

}

// retrieves the value at the front (read index)
template<typename T>
const T& tCircularQueue<T>::front() const
{
	return arr[readIndex];

}

template<typename T>
bool tCircularQueue<T>::full() const
{
	int nextIndex = writeIndex + 1;
	if (nextIndex >= RAW_CAPACITY) {//if writeIndex at end of arr
		nextIndex = 0;//circle back to 0
	}

	if (nextIndex == readIndex) {
		return true;
	}

	return false;
}

// returns true if there are no unpopped elements
template<typename T>
bool tCircularQueue<T>::empty() const
{
	if (readIndex == writeIndex) {//empty
		return true;
	}
	else {//not empty
		return false;
	}
	
}

// returns the current number of elements pushed
template<typename T>
size_t tCircularQueue<T>::size() const
{
	return writeIndex;
}

// returns the maximum number of elements that can be pushed
template<typename T>
size_t tCircularQueue<T>::capacity() const
{
	return RAW_CAPACITY;
}
