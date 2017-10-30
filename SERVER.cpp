//TCP SERVER source file
#include "SERVER.h"
using namespace std;

//Variables declared at the top in catagories:

//NETWORKING VARIABLES:
long SUCCESSFUL;
WSAData WinSockData;
WORD DLLVERSION; //Word are objects of a data size that our processor naturally handles (16 or 32-bit)
string CONVERTER;
char MESSAGE[200];

//Strings for Assigning tasks using String Comparison:


std::string createGame("Server Create me a Game");
std::string joinGame("Server join a game");
std::string rockChosen("You chose rock");
std::string paperChosen("You chose paper");
std::string scissorChosen("You chose scissor");
std::string assignTask;


//STRUCT for holding game information

struct games_01and02 {
	string title;

	int score_Player01;
	int score_Player02;

	bool game_01_created = false;
};

//Variables for holding scores... ?
int player01;
int player02;
int player03;
int player04;

//Functions declared here before main


void createGameonServer() {

	games_01and02 Game01;
	Game01.title = "Game 01";
	Game01.score_Player01 = 2;
	Game01.score_Player02 = 0;

}

void printGameData() {

	cout << Game01.title << endl;
	cout << Game01.score_Player01 << endl;
	cout << Game01.score_Player02 << endl;
}

void CompareWeapons() {
	/* if (player_weapon01 = rock && player_weapon02 = paper) {
		score_Player02++;
		cout << "Player two wins!" << endl;
	}
	else if (player_weapon01 = paper && player_weapon02 = rock) {
		score_Player01++;
		cout << "Player one wins!" << endl;

	}
	else if (player_weapon01 = paper && player_weapon02 = scissor) {
		score_Player02++;
		cout << "Player two wins!" << endl;
	}
	else if (player_weapon01 = scissor && player_weapon02 = paper) {
		score_Player01++;
		cout << "Player one wins!" << endl;
	}
	else if (player_weapon01 = scissor && player_weapon02 = rock) {
		score_Player02++;
		cout << "player two wins!" << endl;
	}
	else if (player_weapon01 = rock && player_weapon02 = scissor) {
		score_Player01++;
		cout << "Player one wins!" << endl;
	}
	else {
		rematch();
		cout << "It's a draw! try again." << endl;
	}
	*/


}


void JoinSpecificGame() {




}



void main()
{
	createGameonServer();
	printGameData();

	DLLVERSION = MAKEWORD(2, 1); //macro to create WORD value by concatenating(Means link serveral object together) its arguments //Start Winsock DLL
	SUCCESSFUL = WSAStartup(DLLVERSION, &WinSockData); //WSAStartup starts the winsock application interface


	//Create Socket Structure
	SOCKADDR_IN ADDRESS; //Instantiate a SOCKADDR_IN object and name ADRESS
	int AddressSize = sizeof(ADDRESS); //Store Adress size in an int 

	//Create Sockets
	SOCKET sock_LISTEN; //Listen for incomming connection
	SOCKET sock_CONNECTION;//activate if connection found


	sock_CONNECTION = socket(AF_INET, SOCK_STREAM, NULL); //socket Arguments: AF_INET = internet domain (not Unix doman), //SOCK_STREAM = connection oriented TCP (not SOCK_DGRAM(UDP))
	ADDRESS.sin_addr.s_addr = INADDR_ANY; //INADDR_ANY, means use the IP of the machine you are on, you can also specify it to Local //inet_addr("127.0.0.1"); //Set IP, this number must be converted
	ADDRESS.sin_family = AF_INET;
	ADDRESS.sin_port = htons(444); //port, htons method to convert the type to a network type

	sock_LISTEN = socket(AF_INET, SOCK_STREAM, NULL); //The server needs a socket to listen in on for incomming connections. 
	bind(sock_LISTEN, (SOCKADDR*)&ADDRESS, sizeof(ADDRESS)); //Bind command bind a socket to an adress, we bind the sock_LISTEN to our IP Adress
	listen(sock_LISTEN, SOMAXCONN); //LISTEN without limits. First argument is the socket we set to listen and SOMAXCONN is the maximum number of connections a system will allow. The maximum lenght of the queue of pending connections. f set to SOMAXCONN, the underlying service provider responsible for socket s will set the backlog to a maximum reasonable value. There is no standard provision to obtain the actual backlog value.

	//If connection found:

	for (;;) //Infinite foor loop will loop forever...
	{
		cout << "\n\tSERVER: Waiting for incoming connection...";

		if (sock_CONNECTION = accept(sock_LISTEN, (SOCKADDR*)&ADDRESS, &AddressSize))
		{
			cout << "\n\tA connection was found!" << endl;

			SUCCESSFUL = send(sock_CONNECTION, "Welcome! You have connected to the Server!", 46, NULL);


			SUCCESSFUL = recv(sock_CONNECTION, MESSAGE, 46, NULL); //Create Game Request!

			assignTask = MESSAGE;

			cout << assignTask << endl;

			if (assignTask.compare(createGame) == 0) {
				cout << "Correct input for CreateGame" << endl;
				std::string assignTask = "";
			}
			else if (assignTask.compare(joinGame) == 0) {
				cout << "Correct input for Joingame" << endl;
				std::string assignTask = "";
			}
			else if (assignTask.compare(rockChosen) == 0) {
				cout << "Correct input for rock chosen" << endl;
				std::string assignTask = "";
			}
			else if (assignTask.compare(paperChosen) == 0) {
				cout << "Correct input for paper chosen" << endl;
				std::string assignTask = "";
			}
			else if (assignTask.compare(scissorChosen) == 0) {
				cout << "Correct input for scissor chosen" << endl;
				std::string assignTask = "";
			}


			//cout << CONVERTER;



		}
	}
}