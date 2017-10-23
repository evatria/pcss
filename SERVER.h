//TCP Server header file
//Note: you need to add "Ws2_32.lib" to the LINKER setting. Like this:
#pragma comment(lib,"Ws2_32.lib")
#define _WINSOCK_DEPRECATED_NO_WARNINGS

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

#define SCK_VERSION2 0x0202
