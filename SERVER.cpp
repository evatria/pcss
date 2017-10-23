//TCP SERVER source file

#include "SERVER.h"


using namespace std;

void main()
{
	//main Locals
	long SUCCESSFUL;
	WSAData WinSockData;
	WORD DLLVERSION; //Word are objects of a data size that our processor naturally handles (16 or 32-bit)
	
	
	int counter=0;
	int a;
	
	string CONVERTER;
	string IntToString;
	char MESSAGE[200];
	char MESSAGEANSWER[1];
	
	

	//WORDS = objects of a data size that a processor naturally handles (such as 16 or 32-bit)
	DLLVERSION = MAKEWORD(2, 1); //macro to create WORD value by concatenating(Means link serveral object together) its arguments

	//Start Winsock DLL
	SUCCESSFUL = WSAStartup(DLLVERSION, &WinSockData); //WSAStartup starts the winsock application interface

	//Create Socket Structure
	SOCKADDR_IN ADDRESS; //Instantiate a SOCKADDR_IN object and name ADRESS
	int AddressSize = sizeof(ADDRESS); //Store Adress size in an int 

	//Create Sockets
	SOCKET sock_LISTEN; //Listen for incomming connection
	SOCKET sock_CONNECTION;//activate if connection found

	//socket Arguments: AF_INET = internet domain (not Unix doman),
	//SOCK_STREAM = connection oriented TCP (not SOCK_DGRAM(UDP))
	sock_CONNECTION = socket(AF_INET, SOCK_STREAM, NULL);
	ADDRESS.sin_addr.s_addr = inet_addr("127.0.0.1"); //Set IP, this number must be converted
	ADDRESS.sin_family = AF_INET;
	ADDRESS.sin_port = htons(444); //port, htons method to convert the type to a network type

	sock_LISTEN = socket(AF_INET, SOCK_STREAM, NULL);
	bind(sock_LISTEN, (SOCKADDR*)&ADDRESS, sizeof(ADDRESS)); //Bind command bind a socket to an adress, we bind the sock_LISTEN to our IP Adress
	listen(sock_LISTEN, SOMAXCONN); //LISTEN without limits. First argument is the socket we set to listen and SOMAXCONN is the maximum number of connections a system will allow.

	//If connection found:

	for (;;) //Infinite foor loop will loop forever...
	{
		cout << "\n\tSERVER: Waiting for incoming connection...";
		
		if(sock_CONNECTION= accept(sock_LISTEN, (SOCKADDR*)&ADDRESS, &AddressSize))
		{
		cout << "\n\tA connection was found!" << endl;

		
		
		SUCCESSFUL = send(sock_CONNECTION, "Welcome! You have connected to the Server!", 46, NULL);

		
		
		//SUCCESSFUL = recv(sock_CONNECTION, MESSAGE, 46, NULL); //RECEIVED MESSAGE FROM CLIENT
		
	
	
		
		
		
		
		}

	}

}