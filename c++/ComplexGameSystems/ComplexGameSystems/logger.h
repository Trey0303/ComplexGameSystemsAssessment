#pragma once
#include <iostream>
#include <thread>
#include <vector>
#include <mutex>
#include "logger.h"
#include <fstream>
#include <iostream>
using namespace std;

void loggerWriteToFile(string messages[], int printCount);