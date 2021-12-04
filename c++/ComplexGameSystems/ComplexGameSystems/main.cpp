#include <iostream>
#include <thread>
#include <vector>
#include <mutex>
#include "logger.h"
#include <fstream>
#include <iostream>
using namespace std;

#include "CircularQueue.h"

    //A container to store the created threads
//stores any added message
string messages[100];
//ends thread when set to false
bool keepRunning = true;
//keeps track of things that the thread needs to work on
int messageCount = 0;
int printCount = 0;
int maxValue = 100;

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

    tCircularQueue<string> circQueue;
    
    std::thread publisher(publish, std::ref(circQueue));
    std::thread consumer(publish, std::ref(circQueue));

    publisher.join();
    consumer.join();

    return 0;
}