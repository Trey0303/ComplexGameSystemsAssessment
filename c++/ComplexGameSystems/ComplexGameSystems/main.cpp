#include <iostream>
#include <thread>
#include <vector>
#include <mutex>
#include "logger.h"
#include <fstream>
#include <iostream>
#include <cassert>
using namespace std;

#include "CircularQueue.h"

#include "incrementTask.h"


    //A container to store the created threads
//stores any added message
string messages[100];
//ends thread when set to false
bool keepRunning = true;
//keeps track of things that the thread needs to work on
int messageCount = 0;
int printCount = 0;
int maxValue = 100;

const int TASK_CAPACITY = 100;

void print()
{
    //A standard interface or abstract class for the threads to use in doing work.
    while (true) {
        if (printCount < messageCount) {//has something to do
            //static std::mutex loggerLock;
            //std::lock_guard<std::mutex> guard(loggerLock);
            
            //print to command window
            cout << messages[printCount] << " (" << printCount << ") " << std::endl;//update printCount to equal messageCount

            //save on text file
            loggerWriteToFile(messages, printCount);

            //ofstream myFile;
            //myFile.open("myTextFile.txt", ios::app);//ios::app is was allows more lines of text to be added to text file
            //myFile << messages[printCount] << " " << printCount << std::endl;
            //myFile.close();
            
            ++printCount;
        }
        else if (!keepRunning) {//nothing left to do
            return;//exit while loop

        }
        else {//idle
            std::this_thread::sleep_for(std::chrono::duration<float>(1.0f));//wait for a number of seconds

        }


    }
}

void publish(tCircularQueue<string>& queue)
{
    int count = 0;
    while (count <= maxValue) {
        if (queue.push(std::string("abc"))) {
            static std::mutex Lock;
            std::lock_guard<std::mutex> guard(Lock);
            std::cout << "push" << count << std::endl;
            count++;
        }
    }
}

void consume(tCircularQueue<string>& queue) {
    int count = 0;
    while (count <= maxValue) {
        if (queue.pop()) {
            static std::mutex Lock;
            std::lock_guard<std::mutex> guard(Lock);
            std::cout << "pop" << count << std::endl;
            count++;
        }
    }
}

void doWork(taskQueue* queue);

int main()
{
    //create empty text file
    ofstream myFile;
    myFile.open("myTextFile.txt");
    myFile << "";
    myFile.close();
    
    //A way to create threads and hold them in an idle state.
    std::thread printThread(print);
    
    messages[messageCount] = "Hello";
    messageCount++;

    messages[messageCount] = "World";
    messageCount++;

    messages[messageCount] = "3rd line of text";
    messageCount++;

    //kill thread
    keepRunning = false;
    printThread.join();

    //
    // multi-threaded implementation
    //

    //circular queue

    //create a string circluar queue
    tCircularQueue<string> circQueue;
    //tCircularQueue<string> circQueueCopy;
    
    //create threads for to keep track of read and write index
    std::thread publisher(publish, std::ref(circQueue));
    std::thread consumer(consume, std::ref(circQueue));
    //std::thread copyPublisher;

    //circQueueCopy = circQueue;

    publisher.join();
    consumer.join();
    //copyPublisher.join();

    //
    // multi-threaded implementation
    //

    //
    // global task queue implementation
    //

    // spawn as many threads as our hardware will support (minus 1 for the OS)
    size_t threadCount = std::thread::hardware_concurrency() - 1;

    // create an array of threads
    std::thread** threads = new std::thread * [threadCount];

    // populate the task queue
    taskQueue tasks(TASK_CAPACITY);//create a taskqueue array
    for (size_t i = 0; i < TASK_CAPACITY; ++i)//until task queue capacity reached
    {
        tasks.push(new incrementTask());//add a new task to taskqueue
    }

    // spin up threads to do the work
    for (size_t i = 0; i < threadCount; ++i)
    {
        threads[i] = new std::thread(doWork, &tasks);
    }

    // wait for everything to finish
    for (size_t i = 0; i < threadCount; ++i)
    {
        threads[i]->join();
    }

    int finalValue = incrementTask::getVal();
    //assert(finalValue == TASK_CAPACITY);

    //
    // global task queue implementation
    //

    return 0;
}

void doWork(taskQueue* queue)
{
    task* currentTask = queue->pop();
    while (currentTask != nullptr)
    {
        currentTask->execute();
        delete currentTask;
        currentTask = queue->pop();
    }
}