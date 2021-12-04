#include "CircularQueue.h"

template<typename T>
tCircularQueue<T>::tCircularQueue()//initaializes array
{
	arr = new T[capacity()];
	arrSize = 0;
	capacity() = RAW_CAPACITY;
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
		size()++;
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
		int curIndex = front();//get current front index
		int nextIndex = curIndex++;
		delete curIndex;//remove current front index
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
