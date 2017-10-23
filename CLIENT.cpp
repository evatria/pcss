//TCP CLIENT source file

#include "CLIENT.h"

using namespace std;

void main()
{
	//Locals
	long SUCCESSFUL;
	WSAData WinSockData;
	WORD DLLVersion;
	DLLVersion = MAKEWORD(2, 1);
	SUCCESSFUL = WSAStartup(DLLVersion, &WinSockData);
	int count = 0;


	string RESPONSE; // These a instances of the type string
	string CONVERTER; // in C++ you have to do a lot of convertions with strings because some functions can only handle certain types of strings
	string CONVERTER01;
	char MESSAGE[200]; // this is a simpler string (a collection of characters). //Must be large enough to accomedate the largest amount of data sent from the server
	char MESSAGEANSWER[200];
	
	SOCKADDR_IN ADDRESS;

	SOCKET sock;
	sock = socket(AF_INET, SOCK_STREAM, NULL); // TCP based connection = AF_INET

	ADDRESS.sin_addr.s_addr = inet_addr("127.0.0.1"); //Local IP, the IP adress is converted into a format that can be used in Networking
	ADDRESS.sin_family = AF_INET;
	ADDRESS.sin_port = htons(444); // Have to use htons method to convert it to network style

	cout << "\n\tCLIENT: Do you want to connect to this SERVER? (Y/N)";
	cin >> RESPONSE;

	RESPONSE[0] = tolower(RESPONSE[0]); // Convert first letter to lower case and only this so if you type YES it takes Y = y

	if (RESPONSE == "n")
	{
		cout << "\n\tOK. Quitting instead.";
	}
	else if (RESPONSE == "y")
	{
		connect(sock, (SOCKADDR*)&ADDRESS, sizeof(ADDRESS));

		SUCCESSFUL = recv(sock, MESSAGE, sizeof(MESSAGE), NULL); //WE assign the received data into the variable Successfull //MESSAGE 1

		CONVERTER = MESSAGE; //The overloaded assignment operator allows us to convert Message (the simple string) into CONVERTER a more complex string.

		cout << '	' << CONVERTER;

		CONVERTER = "0";
		//////////////////////////////////////////////////////////////////////////////////
	}
		
	
	cout << "\n\n\t";
	system("PAUSE");
	exit(1);
}