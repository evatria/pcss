//TCP SERVER source file
#include "SERVER.h"
using namespace std;

//Variables declared at the top in catagories:

//NETWORKING VARIABLES:
int SUCCESSFUL;
WSAData WinSockData;
WORD DLLVERSION; //Word are objects of a data size that our processor naturally handles (16 or 32-bit)
SOCKADDR_IN ADDRESS; //Instantiate a SOCKADDR_IN object and name ADRESS
int numberOfClients;

char MESSAGE01[200];
char MESSAGE02[200];


					   
//Strings for Assigning tasks using String Comparison:
std::string createGame("Server Create me a Game");
std::string joinGame("Server join a game");
std::string rockChosen("You chose rock");
std::string paperChosen("You chose paper");
std::string scissorChosen("You chose scissor");
std::string assignTaskClient01;
std::string assignTaskClient02;

//SOCKETS
SOCKET sock_LISTEN; //Listen for incomming connection
SOCKET sock;
SOCKET client;
SOCKET outSock;

//Client Sockets..
SOCKET Client01;
SOCKET Client02;

//Variables for evaluating game creation

bool hasGameBeenCreate = false;


//STRUCT for holding game information

struct games_01and02 {
	string title;

	int score_Player01;
	int score_Player02;

	int weapon_Player01;
	int weapon_Player02;

	bool game_01_created = false;
} Game01, Game02;


//Functions declared here before main


void createGameonServer() {

	
	Game01.title = "Game 01";
	Game01.score_Player01 = 0;
	Game01.score_Player02 = 0;
	
	Game01.weapon_Player01 = 0;
	Game01.weapon_Player02 = 1;

}

void printGameData() {

cout << Game01.title << endl;
cout << Game01.score_Player01 << endl;
cout << Game01.score_Player02 << endl;
}

void CompareWeapons() {
	if (Game01.weapon_Player01 == Game01.weapon_Player02) {
		cout << "It's a draw" << endl;
	}
	else if (Game01.weapon_Player01 == 1 && Game01.weapon_Player02 == 2) {
		cout << "Player 1 wins" << endl;
		Game01.score_Player01++;
	}
	else if (Game01.weapon_Player01 == 1 && Game01.weapon_Player02 == 3) {
		cout << "Player 2 wins" << endl;
		Game01.score_Player02++;
	}

}


void JoinSpecificGame() {




}

void connectionHandler() {
}

void main()
{


	DLLVERSION = MAKEWORD(2, 2); //macro to create WORD value by concatenating(Means link serveral object together) its arguments //Start Winsock DLL
	int SUCCESSFUL = WSAStartup(DLLVERSION, &WinSockData); //WSAStartup starts the winsock application interface
	if (SUCCESSFUL != 0)
	{
		cerr << "Can't Initialize winsock! Quitting" << endl; //If we cant initialize winsock we are going to fail (This is so that we have an idea of what went wrong..)
		return;
	}


	//Create Socket Structure
	int AddressSize = sizeof(ADDRESS); //Store Adress size in an int 

	sock_LISTEN = socket(AF_INET, SOCK_STREAM, NULL); //The server needs a socket to listen in on for incomming connections. 
	ADDRESS.sin_family = AF_INET;
	ADDRESS.sin_port = htons(54000); //port, htons method to convert the type to a network type
	ADDRESS.sin_addr.s_addr = INADDR_ANY; //INADDR_ANY, means use the IP of the machine you are on, you can also specify it to Local //inet_addr("127.0.0.1"); //Set IP, this number must be converted


	if (sock_LISTEN == INVALID_SOCKET)
	{
		cerr << "Can't Create a socket ! Quitting" << endl;
		return;
	}

	bind(sock_LISTEN, (SOCKADDR*)&ADDRESS, sizeof(ADDRESS)); //Bind command bind a socket to an adress, we bind the sock_LISTEN to our IP Adress

	// Tell the Winsock the socket is for listening

	listen(sock_LISTEN, SOMAXCONN); //LISTEN without limits. First argument is the socket we set to listen and SOMAXCONN is the maximum number of connections a system will allow. The maximum lenght of the queue of pending connections. f set to SOMAXCONN, the underlying service provider responsible for socket s will set the backlog to a maximum reasonable value. There is no standard provision to obtain the actual backlog value.

	//SETUP fd_set

	fd_set master;
	FD_ZERO(&master); //Zeroed the set

	FD_SET(sock_LISTEN, &master);

	while (true)
	{
		fd_set copy = master;

		int socketCount = select(0, &copy, nullptr, nullptr, nullptr);

		for (int i = 0; i < socketCount; i++)
		{
			sock = copy.fd_array[i];
			if (sock == sock_LISTEN)
			{
				// Accept a new connection
				client = accept(sock_LISTEN, nullptr, nullptr);

				// Add the new connection to the list of connected clients
				FD_SET(client, &master);
				numberOfClients++;
				// Send a welcome message to the connected client
				string welcomeMsg = "Welcome to the server!\r\n";
				send(client, welcomeMsg.c_str(), welcomeMsg.size() + 1, 0);
				cout << "Number of clients: " << numberOfClients << endl;
				cout << "The listening socket is: " << master.fd_array[0] << endl;
				cout << "The first client socket " << master.fd_array[1] << endl;
				cout << "The second client socket " << master.fd_array[2] << endl;
				
			}
			/*else
			{
				char buf[4096];
				ZeroMemory(buf, 4096);

				//receive message
				int bytesIn = recv(sock, buf, 4096, 0);
				if (bytesIn <= 0)
				{
					//drop client
					closesocket(sock);
					FD_CLR(sock, &master);

				} */
				else
				{
					// Send message to other clients and definitely not the listening socket



					for (int i = 0; i < master.fd_count; i++) //A loop for sending a message to all players
					{
						outSock = master.fd_array[i];
						if (outSock != sock_LISTEN && outSock != sock)
						{
							ostringstream ss;
							ss << "Other Players are picking their weapon..." << "\n";
							string strOut = ss.str();
							send(outSock, strOut.c_str(), strOut.size() + 1, 0);
						}

						if (numberOfClients = 1) { //If you are the first client to log on you are assigned to the socket in position 1 of the array the client 01 socket
							Client01 = master.fd_array[1];
							ostringstream ss01;
							ss01 << "You are client 01" << "\n";
							string strOut01 = ss01.str();
							send(Client01, strOut01.c_str(), strOut01.size() + 1, 0);
						}
						
						if (numberOfClients = 2) {
							Client02 = master.fd_array[2];
							ostringstream ss02;
							ss02 << "You are client 02" << "\n";
							string strOut02 = ss02.str();
							send(Client02, strOut02.c_str(), strOut02.size() + 1, 0);

							
							//Here we receive from Client 01!
							
							SUCCESSFUL = recv(Client01, MESSAGE01, sizeof(MESSAGE01), NULL);

							assignTaskClient01 = MESSAGE01;

							if (assignTaskClient01.compare(createGame) == 0) {
								if (hasGameBeenCreate == false) {
									createGameonServer();
									cout << "Correct input for CreateGame\n" << endl;
									std::string assignTaskClient01 = "";
									cout << Game01.title << " has been created!\n\n" << "Player 01 Score: " << Game01.score_Player01 << '\t' << "Player 02 Score: " << Game01.score_Player02 << endl;
									hasGameBeenCreate = true;
								}
								else if(hasGameBeenCreate == true)
									cout << "Game has already been created..." << endl;
									SUCCESSFUL = send(Client01, "The game has already been created", 46, NULL);

							}
							else if (assignTaskClient01.compare(joinGame) == 0) {
								cout << "Correct input for Joingame" << endl;
								std::string assignTaskClient01 = "";
							}
							else if (assignTaskClient01.compare(rockChosen) == 0) {
								cout << "Correct input for rock chosen" << endl;
								Game01.weapon_Player02 = 1;
								CompareWeapons();
								SUCCESSFUL = send(Client01, "It's a draw!", 46, NULL);
								std::string assignTaskClient01 = "";
							}
							else if (assignTaskClient01.compare(paperChosen) == 0) {
								cout << "Correct input for paper chosen" << endl;
								Game01.weapon_Player02 = 2;
								CompareWeapons();
								SUCCESSFUL = send(Client01, "Player 1 wins!", 46, NULL);
							std::string assignTaskClient01 = "";
							}
							else if (assignTaskClient01.compare(scissorChosen) == 0) {
								cout << "Correct input for scissor chosen" << endl;
								Game01.weapon_Player02 = 3;
								CompareWeapons();
								SUCCESSFUL = send(Client01, "Player 2 wins!", 46, NULL);
							std::string assignTaskClient01 = "";
							

							}

							//Here we receive from Client 02!


							SUCCESSFUL = recv(Client02, MESSAGE02, sizeof(MESSAGE02), NULL);

							assignTaskClient02 = MESSAGE02;
							if (assignTaskClient02.compare(createGame) == 0) {
								if (hasGameBeenCreate == false) {
									createGameonServer();
									cout << "Correct input for CreateGame\n" << endl;
									std::string assignTaskClient02 = "";
									cout << Game01.title << " has been created!\n\n" << "Player 01 Score: " << Game01.score_Player01 << '\t' << "Player 02 Score: " << Game01.score_Player02 << endl;
									hasGameBeenCreate = true;
								}
								else if(hasGameBeenCreate == true)
									cout << "Game has already been created..." << endl;
								SUCCESSFUL = send(Client02, "The game has already been created", 46, NULL);

							


							}
							else if (assignTaskClient02.compare(joinGame) == 0) {
								cout << "Correct input for Joingame" << endl;
								std::string assignTaskClient02 = "";
							}
							else if (assignTaskClient02.compare(rockChosen) == 0) {
								cout << "Correct input for rock chosen" << endl;
								Game01.weapon_Player02 = 1;
								CompareWeapons();
								SUCCESSFUL = send(Client02, "It's a draw!", 46, NULL);
								std::string assignTaskClient02 = "";
							}
							else if (assignTaskClient02.compare(paperChosen) == 0) {
								cout << "Correct input for paper chosen" << endl;
								Game01.weapon_Player02 = 2;
								CompareWeapons();
								SUCCESSFUL = send(Client02, "Player 1 wins!", 46, NULL);
								std::string assignTaskClient02 = "";
							}
							else if (assignTaskClient02.compare(scissorChosen) == 0) {
								cout << "Correct input for scissor chosen" << endl;
								Game01.weapon_Player02 = 3;
								CompareWeapons();
								SUCCESSFUL = send(Client02, "Player 2 wins!", 46, NULL);
								std::string assignTaskClient02 = "";


							}
						}
					}
				}
			}
		}
	}


		