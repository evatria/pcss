//TCP CLIENT source file
#include "CLIENT.h"
using namespace std;

//Variables declared at the top in catagories:

//NETWORKING VARIABLES:
long SUCCESSFUL; //Contains the information we gain from sending and receiving data
WSAData WinSockData; //The WSAData object is only used once, when we call the WSAStartup function, it tells the computer to start using sockets
WORD DLLVersion; //Word are objects of a data size that our processor naturally handles (16 or 32-bit)
string CONVERTER; // in C++ you have to do a lot of convertions with strings because some functions can only handle certain types of strings
SOCKADDR_IN ADDRESS; //This object contains information about the socket, for example and ipadress or a port number
SOCKET sock; //This is the socket we use on this side... There is one at each side client and server, this side is called sock
char MESSAGE[200]; // this is a simpler string (a collection of characters). //Must be large enough to accomedate the largest amount of data sent from the server

//Pre lobby user interaction
string RESPONSE; // These a instances of the type string

char WEAPONCHOICE;
string rockChosen;
string paperChosen;
string scissorChosen;

//LOBBY VARRIABLES
int LOBBYCHOICE;
bool valid; //to make switch case run again
bool gameisCreated=true;

//Functions declared here before main
void createGame(){
	strcpy_s(MESSAGE, "Server Create me a Game");
	SUCCESSFUL = send(sock, MESSAGE, sizeof(MESSAGE), NULL);
	gameisCreated = true;
	cout << "Game was created" << endl;
}

void weaponChoice() { //Menu to choose weapon
	cout << "Please choose your weapon!" << endl;
	
	do { //do while loop to make switch case run again if choice is not valid
		cout << "\n\nYou choose by pressing a character, followed by ENTER:\n\nR: Rock\nP: Paper\nS: Scissor\n...";

		cin >> WEAPONCHOICE; //Get input from user about what they want to do

		switch (WEAPONCHOICE) {
		case 'r':
		case 'R':
			cout << "You chose rock"<< endl;
			strcpy_s(MESSAGE, "You chose rock");
			SUCCESSFUL = send(sock, MESSAGE, sizeof(MESSAGE), NULL);

			SUCCESSFUL = recv(sock, MESSAGE, sizeof(MESSAGE), NULL); //WE assign the received data into the variable Successfull. In this case the server sends us information if it is connected correctly. First parameter is the server socket, second is the data (A char array), third is the size of the data send and last is a flag a way you send this data, usually set to 0.
			CONVERTER = MESSAGE; //The overloaded assignment operator allows us to convert Message (the simple string) into CONVERTER a more complex string.
			cout << '	' << CONVERTER;

			valid = false;
			break;
		case 'p':
		case 'P':
			cout << "You chose paper"<< endl;
			strcpy_s(MESSAGE, "You chose paper");
			SUCCESSFUL = send(sock, MESSAGE, sizeof(MESSAGE), NULL);

			SUCCESSFUL = recv(sock, MESSAGE, sizeof(MESSAGE), NULL); //WE assign the received data into the variable Successfull. In this case the server sends us information if it is connected correctly. First parameter is the server socket, second is the data (A char array), third is the size of the data send and last is a flag a way you send this data, usually set to 0.
			CONVERTER = MESSAGE; //The overloaded assignment operator allows us to convert Message (the simple string) into CONVERTER a more complex string.
			cout << '	' << CONVERTER;

			valid = false;
			break;
		case 's':
		case 'S':
			cout << "You chose scissor"<< endl;
			strcpy_s(MESSAGE, "You chose scissor");
			SUCCESSFUL = send(sock, MESSAGE, sizeof(MESSAGE), NULL);

			SUCCESSFUL = recv(sock, MESSAGE, sizeof(MESSAGE), NULL); //WE assign the received data into the variable Successfull. In this case the server sends us information if it is connected correctly. First parameter is the server socket, second is the data (A char array), third is the size of the data send and last is a flag a way you send this data, usually set to 0.
			CONVERTER = MESSAGE; //The overloaded assignment operator allows us to convert Message (the simple string) into CONVERTER a more complex string.
			cout << '	' << CONVERTER;

			valid = false;
			break;
		default:
			cout << "Please choose 'R', 'P' or 'S'";
			valid = true;
			break;
		}
	} while (valid);
}

void joinGame() {
	if (gameisCreated) {
		strcpy_s(MESSAGE, "Server join a game");
		SUCCESSFUL = send(sock, MESSAGE, sizeof(MESSAGE), NULL);
		cout << "You have joined a game" << endl;
		weaponChoice();
	}
	/*else {
		cout << "No game has been created yet - a game will now be created for you" << endl;
		createGame();
	}*/
}


void menu() { //The Lobby
	//while (true) {
		cout << "\n\tCLIENT:\n\nHello, welcome to ROCK-PAPER-SCISSOR.";
		do { //do while loop to make switch case run again if choice is not valid
			cout << "\n\nThis is the lobby. Choose what you want to do(You choose by pressing a number, followed by ENTER):\n\n1: Create new game\n2: Join game\n3: Leave game\n...";

			cin >> LOBBYCHOICE; //Get input from user about what they want to do

			switch (LOBBYCHOICE) {
			case 1:
				createGame();
				weaponChoice();
				valid = false;
				break;
			case 2:
				joinGame();
				valid = false;
				break;
			case 3:
				cout << "Goodbye";
				valid = false;
				break;
			default:
				cout << "That not a valid answer";
				valid = true;
				break;
			}
		} while (valid);
	//}
}

void main(){
	//These Parameters must be set before we can start the program, so they are run first:
	DLLVersion = MAKEWORD(2, 2); //Sets the version of the winsock that we want to use, here it is 2, the second parameter is the location the parameter was created
	SUCCESSFUL = WSAStartup(DLLVersion, &WinSockData); //WSAStartup tells the computer that we are going to use sockets
	sock = socket(AF_INET, SOCK_STREAM, NULL); // Here we initialize the socket. First = to assign the socket to the varible sock. First Parameter= = AF_INET which is: the adress family specification, usually you use AF_INET for IPV4 format(type of IP), if you use IPv6 it is AF_INET6. Second parameter is the SOCK_STREAM(TCP Connection) There are many types for example SOCK_DGRAM, which dosent open connection between computers but sends data immediately (Called UDP). The last parameter is 0, and this is ''The possible options for the protocol parameter are specific to the address family and socket type specified.''
	ADDRESS.sin_addr.s_addr = inet_addr("127.0.0.1"); //Local IP, the IP adress need to be converted into a format that can be used in Networking
	ADDRESS.sin_family = AF_INET; // Tells the computer to use IP format IPv4 (Standard at the momemnt)
	ADDRESS.sin_port = htons(54000); // Have to use htons method to convert it to network style, and then specify port number 444 which is the port we use. 

	//Once we have set up some basic networking stuff we ask the USER:
	cout << "\n\tCLIENT: Do you want to connect to this server? Press 'y' for yes or 'n' for no.";
	cin >> RESPONSE; //Inputs their response into the string variable RESPONSE 
	RESPONSE[0] = tolower(RESPONSE[0]); // Convert first letter to lower case and only this so if you type YES it takes Y = y

	//Depending on the answer we have two options:	
	if (RESPONSE == "n"){ //if no then just quit
		cout << "\n\tOK. Quitting instead.";
		exit(0);
	}
	
	else if (RESPONSE == "y"){
		connect(sock, (SOCKADDR*)&ADDRESS, sizeof(ADDRESS)); //This line connects us to the server. First parameter is our server socket, 2. parameter is the address information, 3. is the size of the 2. parameter. 
		SUCCESSFUL = recv(sock, MESSAGE, sizeof(MESSAGE), NULL); //WE assign the received data into the variable Successfull. In this case the server sends us information if it is connected correctly. First parameter is the server socket, second is the data (A char array), third is the size of the data send and last is a flag a way you send this data, usually set to 0.
		CONVERTER = MESSAGE; //The overloaded assignment operator allows us to convert Message (the simple string) into CONVERTER a more complex string.
		cout << '	' << CONVERTER;
		menu();
	}

	SUCCESSFUL = recv(sock, MESSAGE, sizeof(MESSAGE), NULL);
	cout << "\n\n\t";
	system("PAUSE");
	exit(1);
}