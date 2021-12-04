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


template<typename T>
tCircularQueue<T>::tCircularQueue()//initaializes array
{
	arr = new T[capacity()];
	arrSize = 0;
}

//template<typename T>
//tCircularQueue<T>::tCircularQueue(const tCircularQueue& other)// copy constructor
//{
//	T* arrCopy = new T[capacity()];
//}
//
//template<typename T>
//tCircularQueue<T>& tCircularQueue<T>::operator =(const tCircularQueue& other) { // copy assignment operator
//	T* arrtemp = new T[capacity()];
//
//	arrtemp.capacity() = other.capacity();
//	arrtemp.arrSize = other.arrSize;
//	
//	for (int i = 0; i < other.arrSize; i++) {
//		//copy all that is stored inside other array
//	}
//
//	return *this;
//}

template<typename T>
tCircularQueue<T>::~tCircularQueue()//delete array
{
	delete[] arr;
}

template<typename T>
bool tCircularQueue<T>::push(const T& val)
{

	//if size of array is greater than capacity of array
	if (size() >= capacity()) {
		return false;

	}
	else {//push val at the back of arr
		int curIndex = size();//gets last index
		int nextIndex = curIndex++;//get pointer to next index
		arr[curIndex] = val;//val set as new last index
		curIndex = nextIndex;//set curIndex pointer to next index position
		arrSize++;
		return true;
	}

}

template<typename T>
bool tCircularQueue<T>::pop()
{
	if (empty()) {//if empty
		return false;
	}
	//delete front value
	else {
		int curIndex = arr.front();//get current front index
		int nextIndex = curIndex++;
		curIndex = nextIndex;//set next index as new current front index
		return true;
	}

}

template<typename T>
const T& tCircularQueue<T>::front() const
{
	return readIndex = arr[0];

}

template<typename T>
bool tCircularQueue<T>::empty() const
{
	if (size() > 1) {//array not empty
		return false;

	}
	else {
		return true;
	}

}

template<typename T>
size_t tCircularQueue<T>::size() const
{
	return arrSize;
}

template<typename T>
size_t tCircularQueue<T>::capacity() const
{
	return RAW_CAPACITY;
}
