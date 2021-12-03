// basic file operations
#include <iostream>
#include <fstream>
using namespace std;

#include <iostream>
#include <thread>
#include <vector>
#include <mutex>

void loggerWriteToFile(string messages[], int printCount) {
    static std::mutex loggerLock;
    std::lock_guard<std::mutex> guard(loggerLock);

    ofstream myFile;
    myFile.open("myTextFile.txt", ios::app);//ios::app is was allows more lines of text to be added to text file
    myFile << messages[printCount] << " (" << printCount << ") " << std::endl;
    myFile.close();

    //myFile << "Write text in this file. " << "File " << i << "\n";
    //myFile << "This is my second sentence.\n";
    //myFile << "Good bye world!\n";
    myFile.close();
}