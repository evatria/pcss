//TCP Server header file
//Note: you need to add "Ws2_32.lib" to the LINKER setting. Like this:
#pragma comment(lib,"Ws2_32.lib")


//STD console header files
#include <sdkddkver.h>
#include <conio.h>
#include <stdio.h>
#include <stdlib.h>

//SOCKET header files
#include<WinSock2.h>
#include<Windows.h>
#include<iostream>
#include <iomanip>
#include <locale>
#include <sstream>
#include <string>
#include <thread>
#include <WS2tcpip.h> //A header files that includes many of the winsock headerfiles and functions
#define SCK_VERSION2 0x0202
