//TCP CLIENT header file

//Must include "Ws2_32.lib".
#pragma once //run once..
#pragma comment(lib,"Ws2_32.lib") //Winsock 2 lib.
#define _WINSOCK_DEPRECATED_NO_WARNINGS //Some of the winsock functions are outdate :(

//Standard HEADER files
#include <sdkddkver.h> //Google it
#include <WinSock2.h> //Standard winsock lib
#include<Windows.h> //Windows funciton
#include<iostream>
#include <string> //To use string functions
#include <cstdlib> //To use exit(0) call.
#define SCK_VERSION2 0x0202
