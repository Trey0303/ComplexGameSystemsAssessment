#include "incrementTask.h"

// declares and defines (thus allocating memory for) the `val` static member variable
std::atomic<int> incrementTask::val = 0;

taskQueue::taskQueue(size_t taskCapacity)
{
	task** temp = new task*[taskCapacity];
	tasks = temp;

	head = 0;
	tail = 0;

	taskCapacityMax = taskCapacity;
}

taskQueue::~taskQueue()
{
	//delete task queue
	delete[] tasks;
}

task* taskQueue::pop()
{
	queueAccess.lock();
	if (isEmpty()) {
		//nothing left to return
		return nullptr;
	}
	else {

		int curIndex = head;
		int nextIndex = curIndex + 1;
		head = nextIndex;
		
		return tasks[head];

	}
	queueAccess.unlock();
}

void taskQueue::push(task* t)
{
	queueAccess.lock();
	if (!isFull()) {
		int curIndex = tail;
		int nextIndex = curIndex + 1;
		tasks[curIndex] = t;//place task into tasks array
		tail = nextIndex;//move tail over to the next available index
	}
	queueAccess.unlock();
}

bool taskQueue::isEmpty() const
{
	if (head == tail) {
		return true;
	}
	else {
		return false;

	}
}

bool taskQueue::isFull() const
{
	if (tail >= taskCapacityMax) {
		return true;
	} 
	else{
		return false;

	}
}
