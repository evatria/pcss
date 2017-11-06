
// Using Directive List
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;


// Creating The public class "MultiThreadedEchoServer
public class MultiThreadedEchoServer {

    // MAXIMUM 3 CLIENTS SUPPORTED

    // Calling static variables

    static bool foundRandom = false;

    // 3 Integers Created To Give Space For 3 Players Later In The Code
    static int x = 0;
    static int y = 0;
    static int z = 0;


    // Array Variables For Storing Various Information About Players And Lobbies
    static String[] playerNames = {"", "", ""};
    static bool[] openLobbies = {false, false, false};
    static int[] playersinlobby = {0, 0, 0};
    static bool[] playerinlobby = {false, false, false};
    static int[] tempLobby = {0, 0, 0};
    static bool[] clientsConnected = {false, false, false};
    
    
    private static void ProcessClientRequests(object argument) {

        /*
         * The Following Code Is Data/Information That Will Be Send To The Client
         * To Make It Possible For The Client To Create/Join Lobbies.
        */
        
        TcpClient client = (TcpClient)argument; // Creating Tcp Object "client" From The class "TcpClient"
        try { // try-catch Is Called To Catch Exceptions If Something Goes Wrong

            StreamReader reader = new StreamReader(client.GetStream()); // StreamReader Takes Input From Client
            StreamWriter writer = new StreamWriter(client.GetStream()); // StreamWriter Sends Output To Client
            string s = String.Empty;
            while (!(s = reader.ReadLine()).Equals("Exit") || (s == null)) { //if there is a message and it's not Exit, do everything in this while loop.
                
                if (s[0] == '+' && s[1] == '+' && !clientsConnected[0]) { // if 0 clients connected
                    playerNames[0] = s; //player array entry 0 is set to the input
                    Console.WriteLine(playerNames[0] + " joined the server");
                    writer.WriteLine("Name selected: " + playerNames[0]);
                    clientsConnected[0] = true;
                    Console.WriteLine("clientsConnected[0]: " + clientsConnected[0] + "\n");
                 } else if (s[0] == '+' && s [1] == '+' && clientsConnected[0] && !clientsConnected[1]) { // if 1 client connected
                    playerNames[1] = s; //player array entry 2 is set to the input
                    Console.WriteLine(playerNames[1] + " joined the server");
                    writer.WriteLine("Name selected: " + playerNames[1]);
                    clientsConnected[1] = true;
                    Console.WriteLine("clientsConnected[1]: " + clientsConnected[1] + "\n");
                 } else if (s[0] == '+' && s[1] == '+' && clientsConnected[1]) { // if 2 clients connected
                    playerNames[2] = s; //player array entry 3 is set to the input
                    Console.WriteLine(playerNames[2] + " joined the server"); 
                    writer.WriteLine("Name selected: " + playerNames[2]);
                    clientsConnected[2] = true;
                    Console.WriteLine("clientsConnected[2]: " + clientsConnected[2] + "\n");
                 } else {
                    String j = string.Concat("++", s); //has some problems with s so turned it into j. dont know if this is still neccesary

                if (j == (playerNames[0]+"_lobbylist")) { // if the input is lobbylist  and sent by client1. To keep track of who wrote it, the client also sends their own name and an underscore here (see client code line 48)
                        Console.WriteLine(playerNames[0] + " Requested to see the lobby list");
                    writer.WriteLine("Lobby 1: " + (openLobbies[0]?"Open " + "(" + playersinlobby[0] + ")":"Closed ") +
                        " | Lobby 2: " + (openLobbies[1]?"Open " + "(" + playersinlobby[1] + ")":"Closed ") +
                        " | Lobby 3: " + (openLobbies[2]?"Open " + "(" + playersinlobby[2] + ")":"Closed" ));

                } else if (j == (playerNames[1]+"_lobbylist")) { // if the input is lobbylist  and sent by client2. To keep track of who wrote it, the client also sends their own name and an underscore here (see client code line 48)
                        Console.WriteLine(playerNames[1] + " Requested to see the lobby list");
                    writer.WriteLine("Lobby 1: " + (openLobbies[0]?"Open " + "(" + playersinlobby[0] + ")":"Closed ") +
                        " | Lobby 2: " + (openLobbies[1]?"Open " + "(" + playersinlobby[1] + ")":"Closed ") +
                        " | Lobby 3: " + (openLobbies[2]?"Open " + "(" + playersinlobby[2] + ")":"Closed" ));

                } else if (j == (playerNames[2]+"_lobbylist")) { // if the input is lobbylist and sent by client3. To keep track of who wrote it, the client also sends their own name and an underscore here (see client code line 48)
                        Console.WriteLine(playerNames[2] + " Requested to see the lobby list");
                    writer.WriteLine("Lobby 1: " + (openLobbies[0]?"Open " + "(" + playersinlobby[0] + ")":"Closed ") +
                        " | Lobby 2: " + (openLobbies[1]?"Open " + "(" + playersinlobby[1] + ")":"Closed ") +
                        " | Lobby 3: " + (openLobbies[2]?"Open " + "(" + playersinlobby[2] + ")":"Closed" ));

                } else if (j == (playerNames[0]+"_Open 1") || j == (playerNames[0]+"_open 1")) { // if the input is open 1 or Open 1 and sent by client2. To keep track of who wrote it, the client also sends their own name and an underscore here (see client code line 48)
                        if (!openLobbies[0]) {
                        openLobbies[0] = true;
                    writer.WriteLine("Opened lobby 1");
                        Console.WriteLine(playerNames[0] + " Opened lobby 1");
                        } else {
                         writer.WriteLine("Tried to open lobby 1 but it was already open.");
                        Console.WriteLine(playerNames[0] + " Tried to open lobby 1 but it was already open");
                         }
                } else if (j == (playerNames[1]+"_Open 1") || j == (playerNames[1]+"_open 1")) {// if the input is open 1 or Open 1 and sent by client2. To keep track of who wrote it, the client also sends their own name and an underscore here (see client code line 48)
                        if (!openLobbies[0]) {
                        openLobbies[0] = true;
                    writer.WriteLine("Opened lobby 1");
                        Console.WriteLine(playerNames[1] + " Opened lobby 1");
                        } else {
                         writer.WriteLine("Tried to open lobby 1 but it was already open.");
                        Console.WriteLine(playerNames[1] + " Tried to open lobby 1 but it was already open");
                         }
                } else if (j == (playerNames[2]+"_Open 1") || j == (playerNames[2]+"_open 1")) { // if the input is open 1 or Open 1 and sent by client2. To keep track of who wrote it, the client also sends their own name and an underscore here (see client code line 48)
                        if (!openLobbies[0]) {
                        openLobbies[0] = true;
                    writer.WriteLine("Opened lobby 1");
                        Console.WriteLine(playerNames[2] + " Opened lobby 1");
                        } else {
                         writer.WriteLine("Tried to open lobby 1 but it was already open.");
                        Console.WriteLine(playerNames[2] + " Tried to open lobby 1 but it was already open");
                         }
                } else if (j == (playerNames[0]+"_Open 2") || j == (playerNames[0]+"_open 2")) { //all of the else if statements work this same way. see line 106 comment for explanation
                        if (!openLobbies[1]) {
                        openLobbies[1] = true;
                    writer.WriteLine("Opened lobby 2");
                        Console.WriteLine(playerNames[0] + " Opened lobby 2");
                        } else {
                         writer.WriteLine("Tried to open lobby 2 but it was already open.");
                        Console.WriteLine(playerNames[0] + " Tried to open lobby 2 but it was already open");
                         }
                } else if (j == (playerNames[1]+"_Open 2") || j == (playerNames[1]+"_open 2")) { //all of the else if statements work this same way. see line 106 comment for explanation
                        if (!openLobbies[1]) {
                        openLobbies[1] = true;
                    writer.WriteLine("Opened lobby 2");
                        Console.WriteLine(playerNames[1] + " Opened lobby 2");
                        } else {
                         writer.WriteLine("Tried to open lobby 2 but it was already open.");
                        Console.WriteLine(playerNames[1] + " Tried to open lobby 2 but it was already open");
                         }
                } else if (j == (playerNames[2]+"_Open 2") || j == (playerNames[2]+"_open 2")) { //all of the else if statements work this same way. see line 106 comment for explanation
                        if (!openLobbies[1]) {
                        openLobbies[1] = true;
                    writer.WriteLine("Opened lobby 2");
                        Console.WriteLine(playerNames[2] + " Opened lobby 2");
                        } else {
                         writer.WriteLine("Tried to open lobby 2 but it was already open.");
                        Console.WriteLine(playerNames[2] + " Tried to open lobby 2 but it was already open");
                        }
                    } else if (j == (playerNames[0]+"_Open 3") || j == (playerNames[0]+"_open 3")) { //all of the else if statements work this same way. see line 106 comment for explanation
                        if (!openLobbies[2]) {
                        openLobbies[2] = true;
                    writer.WriteLine("Opened lobby 3");
                        Console.WriteLine(playerNames[0] + " Opened lobby 3");
                        } else {
                         writer.WriteLine("Tried to open lobby 3 but it was already open.");
                        Console.WriteLine(playerNames[0] + " Tried to open lobby 3 but it was already open");
                         }
                } else if (j == (playerNames[1]+"_Open 3") || j == (playerNames[1]+"_open 3")) { //all of the else if statements work this same way. see line 106 comment for explanation
                        if (!openLobbies[2]) {
                        openLobbies[2] = true;
                    writer.WriteLine("Opened lobby 3");
                        Console.WriteLine(playerNames[1] + " Opened lobby 3");
                        } else {
                         writer.WriteLine("Tried to open lobby 3 but it was already open.");
                        Console.WriteLine(playerNames[1] + " Tried to open lobby 3 but it was already open");
                         }
                } else if (j == (playerNames[2]+"_Open 3") || j == (playerNames[2]+"_open 3")) { //all of the else if statements work this same way. see line 106 comment for explanation
                        if (!openLobbies[2]) {
                        openLobbies[2] = true;
                    writer.WriteLine("Opened lobby 3");
                        Console.WriteLine(playerNames[2] + " Opened lobby 3");
                        } else {
                         writer.WriteLine("Tried to open lobby 3 but it was already open.");
                        Console.WriteLine(playerNames[2] + " Tried to open lobby 3 but it was already open");
                        }
                    } else if (j == (playerNames[0]+"_Close 1") || j == (playerNames[0]+"_close 1")) { //all of the else if statements work this same way. see line 106 comment for explanation
                        if (openLobbies[0]) {
                        openLobbies[0] = false;
                        playersinlobby[0] = 0;
                    writer.WriteLine("Closed lobby 1");
                        Console.WriteLine(playerNames[0] + " Closed lobby 1");
                        } else {
                         writer.WriteLine("Tried to close lobby 1 but it was already closed.");
                        Console.WriteLine(playerNames[0] + " Tried to close lobby 1 but it was already closed");
                         }
                } else if (j == (playerNames[1]+"_Close 1") || j == (playerNames[1]+"_close 1")) { //all of the else if statements work this same way. see line 106 comment for explanation
                        if (openLobbies[0]) {
                        openLobbies[0] = false;
                            playersinlobby[0] = 0;
                    writer.WriteLine("Closed lobby 1");
                        Console.WriteLine(playerNames[1] + " Closed lobby 1");
                        } else {
                         writer.WriteLine("Tried to close lobby 1 but it was already closed.");
                        Console.WriteLine(playerNames[1] + " Tried to close lobby 1 but it was already closed");
                         }
                } else if (j == (playerNames[2]+"_Close 1") || j == (playerNames[2]+"_close 1")) { //all of the else if statements work this same way. see line 106 comment for explanation
                        if (openLobbies[0]) {
                        openLobbies[0] = false;
                            playersinlobby[0] = 0;
                    writer.WriteLine("Closed lobby 1");
                        Console.WriteLine(playerNames[2] + " Closed lobby 1");
                        } else {
                         writer.WriteLine("Tried to close lobby 1 but it was already closed.");
                        Console.WriteLine(playerNames[2] + " Tried to close lobby 1 but it was already closed");
                        }
                } else if (j == (playerNames[0]+"_Close 2") || j == (playerNames[0]+"_close 2")) { //all of the else if statements work this same way. see line 106 comment for explanation
                        if (openLobbies[1]) {
                        openLobbies[1] = false;
                            playersinlobby[1] = 0;
                    writer.WriteLine("Closed lobby 2");
                        Console.WriteLine(playerNames[0] + " Closed lobby 2");
                        } else {
                         writer.WriteLine("Tried to close lobby 2 but it was already closed.");
                        Console.WriteLine(playerNames[0] + " Tried to close lobby 2 but it was already closed");
                         }
                } else if (j == (playerNames[1]+"_Close 2") || j == (playerNames[1]+"_close 2")) { //all of the else if statements work this same way. see line 106 comment for explanation
                        if (openLobbies[1]) {
                        openLobbies[1] = false;
                    writer.WriteLine("Closed lobby 2");
                            playersinlobby[1] = 0;
                        Console.WriteLine(playerNames[1] + " Closed lobby 2");
                        } else {
                         writer.WriteLine("Tried to close lobby 2 but it was already closed.");
                        Console.WriteLine(playerNames[1] + " Tried to close lobby 2 but it was already closed");
                         }
                } else if (j == (playerNames[2]+"_Close 2") || j == (playerNames[2]+"_close 2")) { //all of the else if statements work this same way. see line 106 comment for explanation
                        if (openLobbies[1]) {
                        openLobbies[1] = false;
                    writer.WriteLine("Closed lobby 2");
                            playersinlobby[1] = 0;
                        Console.WriteLine(playerNames[2] + " Closed lobby 2");
                        } else {
                         writer.WriteLine("Tried to close lobby 2 but it was already closed.");
                        Console.WriteLine(playerNames[2] + " Tried to close lobby 2 but it was already closed");
                        }
                } else if (j == (playerNames[0]+"_Close 3") || j == (playerNames[0]+"_close 3")) { //this statement lets players close lobby 3. all of the else if statements work this same way. see line 106 comment for explanation.
                        if (openLobbies[2]) {
                        openLobbies[2] = false;
                            playersinlobby[2] = 0;
                    writer.WriteLine("Closed lobby 3");
                        Console.WriteLine(playerNames[0] + " Closed lobby 3");
                        } else {
                         writer.WriteLine("Tried to close lobby 3 but it was already closed.");
                        Console.WriteLine(playerNames[0] + " Tried to close lobby 3 but it was already closed");
                         }
                } else if (j == (playerNames[1]+"_Close 3") || j == (playerNames[1]+"_close 3")) { //this statement lets players close lobby 3. all of the else if statements work this same way. see line 106 comment for explanation.
                        if (openLobbies[2]) {
                        openLobbies[2] = false;
                            playersinlobby[2] = 0;
                    writer.WriteLine("Closed lobby 3");
                        Console.WriteLine(playerNames[1] + " Closed lobby 3");
                        } else {
                         writer.WriteLine("Tried to close lobby 3 but it was already closed.");
                        Console.WriteLine(playerNames[1] + " Tried to close lobby 3 but it was already closed");
                         }
                } else if (j == (playerNames[2]+"_Close 3") || j == (playerNames[2]+"_close 3")) { //this statement lets players close lobby 3. all of the else if statements work this same way. see line 106 comment for explanation.
                        if (openLobbies[2]) {
                        openLobbies[2] = false;
                            playersinlobby[2] = 0;
                    writer.WriteLine("Closed lobby 3");
                        Console.WriteLine(playerNames[2] + " Closed lobby 3");
                        } else {
                         writer.WriteLine("Tried to close lobby 3 but it was already closed.");
                        Console.WriteLine(playerNames[2] + " Tried to close lobby 3 but it was already closed");
                        }

                } else if (j == (playerNames[0]+"_join 1") || j == (playerNames[0]+"_Join 1")) { //all of the else if statements work this same way. see line 106 comment for explanation
                        if (openLobbies[0] && !playerinlobby[0]) {
                        playersinlobby[0]++;
                        playerinlobby[0] = true;
                        tempLobby[0] = 1;
                        writer.WriteLine("Joined lobby 1 (" + playersinlobby[0] + ")");
                            Console.WriteLine(playerNames[0] + " Joined lobby 1 (" + playersinlobby[0] + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 1 is currently closed or you are already in a lobby.");
                            Console.WriteLine(playerNames[0] + " Tried to join lobby 1 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (playerNames[1]+"_join 1") || j == (playerNames[1]+"_Join 1")) { //all of the else if statements work this same way. see line 106 comment for explanation
                        if (openLobbies[0] && !playerinlobby[1]) {
                        playersinlobby[0]++;
                        playerinlobby[1] = true;
                        tempLobby[1] = 1;
                 writer.WriteLine("Joined lobby 1 (" + playersinlobby[0] + ")");
                            Console.WriteLine(playerNames[1] + " Joined lobby 1 (" + playersinlobby[0] + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 1 is currently closed or you are already in a lobby.");
                            Console.WriteLine(playerNames[1] + " Tried to join lobby 1 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (playerNames[2]+"_join 1") || j == (playerNames[2]+"_Join 1")) { //all of the else if statements work this same way. see line 106 comment for explanation
                        if (openLobbies[0] && !playerinlobby[2]) {
                        playersinlobby[0]++;
                        playerinlobby[2] = true;
                        tempLobby[2] = 1;
                 writer.WriteLine("Joined lobby 1 (" + playersinlobby[0] + ")");
                            Console.WriteLine(playerNames[0] + " Joined lobby 1 (" + playersinlobby[0] + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 1 is currently closed or you are already in a lobby.");
                            Console.WriteLine(playerNames[0] + " Tried to join lobby 1 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (playerNames[0]+"_join 2") || j == (playerNames[0]+"_Join 2")) { //all of the else if statements work this same way. see line 106 comment for explanation
                        if (openLobbies[1] && !playerinlobby[0]) {
                        playersinlobby[1]++;
                        playerinlobby[0] = true;
                        tempLobby[0] = 2;
                 writer.WriteLine("Joined lobby 2 (" + playersinlobby[1] + ")");
                            Console.WriteLine(playerNames[0] + " Joined lobby 2 (" + playersinlobby[1] + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 2 is currently closed or you are already in a lobby.");
                            Console.WriteLine(playerNames[0] + " Tried to join lobby 2 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (playerNames[1]+"_join 2") || j == (playerNames[1]+"_Join 2")) { //all of the else if statements work this same way. see line 106 comment for explanation
                        if (openLobbies[1] && !playerinlobby[1]) {
                        playersinlobby[1]++;
                        playerinlobby[1] = true;
                        tempLobby[1] = 2;
                 writer.WriteLine("Joined lobby 2 (" + playersinlobby[1] + ")");
                            Console.WriteLine(playerNames[1] + " Joined lobby 2 (" + playersinlobby[1] + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 2 is currently closed or you are already in a lobby.");
                            Console.WriteLine(playerNames[1] + " Tried to join lobby 2 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (playerNames[2]+"_join 2") || j == (playerNames[2]+"_Join 2")) { //all of the else if statements work this same way. see line 106 comment for explanation
                        if (openLobbies[1] && !playerinlobby[2]) {
                        playersinlobby[1]++;
                        playerinlobby[2] = true;
                        tempLobby[2] = 2;
                 writer.WriteLine("Joined lobby 2 (" + playersinlobby[1] + ")");
                            Console.WriteLine(playerNames[0] + " Joined lobby 2 (" + playersinlobby[1] + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 2 is currently closed or you are already in a lobby.");
                            Console.WriteLine(playerNames[0] + " Tried to join lobby 2 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (playerNames[0]+"_join 3") || j == (playerNames[0]+"_Join 3")) { //this statement lets players join lobby 3. all of the else if statements work this same way. see line 106 comment for explanation.
                        if (openLobbies[2] && !playerinlobby[0]) {
                        playersinlobby[2]++;
                        playerinlobby[0] = true;
                        tempLobby[0] = 3;
                 writer.WriteLine("Joined lobby 3 (" + playersinlobby[2] + ")");
                            Console.WriteLine(playerNames[0] + " Joined lobby 3 (" + playersinlobby[2] + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 3 is currently closed or you are already in a lobby.");
                            Console.WriteLine(playerNames[0] + " Tried to join lobby 3 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (playerNames[1]+"_join 3") || j == (playerNames[1]+"_Join 3")) { //this statement lets players join lobby 3. all of the else if statements work this same way. see line 106 comment for explanation.
                        if (openLobbies[2] && !playerinlobby[1]) {
                        playersinlobby[2]++;
                        playerinlobby[1] = true;
                        tempLobby[1] = 3;
                 writer.WriteLine("Joined lobby 3 (" + playersinlobby[2] + ")");
                            Console.WriteLine(playerNames[1] + " Joined lobby 3 (" + playersinlobby[2] + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 3 is currently closed or you are already in a lobby.");
                            Console.WriteLine(playerNames[1] + " Tried to join lobby 3 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (playerNames[2]+"_join 3") || j == (playerNames[2]+"_Join 3")) { //this statement lets players join lobby 3. all of the else if statements work this same way. see line 106 comment for explanation. 
                        if (openLobbies[2] && !playerinlobby[2]) {
                        playersinlobby[2]++;
                        playerinlobby[2] = true;
                        tempLobby[2] = 3;
                 writer.WriteLine("Joined lobby 3 (" + playersinlobby[2] + ")");
                            Console.WriteLine(playerNames[0] + " Joined lobby 3 (" + playersinlobby[2] + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 3 is currently closed or you are already in a lobby.");
                            Console.WriteLine(playerNames[0] + " Tried to join lobby 3 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (playerNames[0]+"_leave")) { //this statement lets players leave the lobby they are currently in. all of the else if statements work this same way. see line 106 comment for explanation. 
                        if (playerinlobby[0]) {
                    writer.WriteLine("Left lobby");
                            if (tempLobby[0] == 1) {
                            playersinlobby[0]--;
                            playerinlobby[0] = false;
                                }
                            if (tempLobby[0] == 2) {
                            playersinlobby[1]--;
                            playerinlobby[0] = false;
                                }
                            if (tempLobby[0] == 3) {
                            playersinlobby[2]--;
                            playerinlobby[0] = false;
                                }
                            Console.WriteLine(playerNames[0] + " Left lobby " + tempLobby[0]);
                    } else {
                    writer.WriteLine("Sorry. You are not in a lobby, so you can't leave it.");
                            Console.WriteLine(playerNames[0] + " Tried to leave lobby but was not in a lobby.");
                    }
                    } else if (j == (playerNames[1]+"_leave")) {
                        if (playerinlobby[1]) {
                    writer.WriteLine("Left lobby");
                            if (tempLobby[1] == 1) {
                            playersinlobby[0]--;
                            playerinlobby[1] = false;
                                }
                            if (tempLobby[1] == 2) {
                            playersinlobby[1]--;
                            playerinlobby[1] = false;
                                }
                            if (tempLobby[1] == 3) {
                            playersinlobby[2]--;
                            playerinlobby[1] = false;
                                }
                            Console.WriteLine(playerNames[1] + " Left lobby " + tempLobby[1]);
                    } else {
                    writer.WriteLine("Sorry. You are not in a lobby, so you can't leave it.");
                            Console.WriteLine(playerNames[1] + " Tried to leave lobby but was not in a lobby.");
                    }
                    } else if (j == (playerNames[2]+"_leave")) {
                        if (playerinlobby[2]) {
                    writer.WriteLine("Left lobby");
                            if (tempLobby[2] == 1) {
                            playersinlobby[0]--;
                            playerinlobby[2] = false;
                                }
                            if (tempLobby[2] == 2) {
                            playersinlobby[1]--;
                            playerinlobby[2] = false;
                                }
                            if (tempLobby[2] == 3) {
                            playersinlobby[2]--;
                            playerinlobby[2] = false;
                                }
                            Console.WriteLine(playerNames[2] + " Left lobby " + tempLobby[2]);
                    } else {
                    writer.WriteLine("Sorry. You are not in a lobby, so you can't leave it.");
                            Console.WriteLine(playerNames[2] + " Tried to leave lobby but was not in a lobby.");
                    }
                    
                } else if (s[s.Length-1] == '_' && s[s.Length-2] == '9' && s[s.Length-3] == 'x' && s[s.Length-4] == 'o' && s[s.Length-5] == 'x') { //checks if the last entries of the string received from client has xox9_. if it does the server starts the game
                        //Console.WriteLine("Received this input: " + s);
                        //Console.WriteLine("game");

                        Random rnd = new Random(); // "rnd" Random Object Created To Generate A Random Rolled Dice Number For Each Player

                        if (!foundRandom) { // If A Random Number Hasn't Been Found, Create One?
                        x = rnd.Next(1,100);
                        y = rnd.Next(1,100);
                        z = rnd.Next(1,100);
                        while (x == z && x == y && y == z) { // If All Players Have The Same Number, Generate A New For Each Player
                            x = rnd.Next(1,100);
                            y = rnd.Next(1,100);
                            z = rnd.Next(1,100);
                            }
                        foundRandom = true; // Set The Boolean To True After A Number Has Been Generated For Each Player
                        }

                        // If Statements Used To Write The Winner In The Output
                        if (x > y && x > z) {
                        writer.WriteLine(" Highest number wins! " + playerNames[0] + " rolled " + x + ". " + playerNames[1] + " rolled " + y + ". " + playerNames[2] + " rolled " + z + ". " + playerNames[0] + " Wins!! GAME OVER! RESTART SERVER AND CLIENTS TO PLAY AGAIN");
                            }
                        else if (x > y && x > z) {
                        writer.WriteLine(" Highest number wins! " + playerNames[0] + " rolled " + x + ". " + playerNames[1] + " rolled " + y + ". " + playerNames[2] + " rolled " + z + ". " + playerNames[0] + " Wins!! GAME OVER! RESTART SERVER AND CLIENTS TO PLAY AGAIN");
                            }
                        else if (x > y && x > z) {
                        writer.WriteLine(" Highest number wins! " + playerNames[0] + " rolled " + x + ". " + playerNames[1] + " rolled " + y + ". " + playerNames[2] + " rolled " + z + ". " + playerNames[0] + " Wins!! GAME OVER! RESTART SERVER AND CLIENTS TO PLAY AGAIN");
                            }
                    } else {
                    writer.WriteLine(""); // Update Players
                    }
                }
                // Displays How Many Players That Are Currently In The Lobby - Updates Everytime A New Player Joins

                if (playersinlobby[0] == 3) {
                    //Console.WriteLine("3 Players connected to lobby 1! Ready to start game!");
                    writer.Write("3 Players connected to lobby 1! Ready to start game!");
                }
                
                if (playersinlobby[1] == 3) {
                    //Console.WriteLine("3 Players connected to lobby 2! Ready to start game!");
                    writer.Write("3 Players connected to lobby 2! Ready to start game!");
                }
                
                if (playersinlobby[2] == 3) {
                    //Console.WriteLine("3 Players connected to lobby 3! Ready to start game!");
                    writer.Write("3 Players connected to lobby 3! Ready to start game!");
                }
                writer.Flush(); // Flush The Writer
            }
            reader.Close(); // Called To Close Reader After 3 Players Have Joined
            writer.Close(); // Called To Close Writer After 3 Players Have Joined
            client.Close(); // The Client Closes Automatically After A Winner Has Been Found
            Console.WriteLine("Closing client connection");
        } catch (IOException) {
            Console.WriteLine("There was a problem. Exiting"); // Write If A Problem/Exception Has Been Found
        } finally { // Closes The Client After An Exception Is Caught
            if (client != null) {
                client.Close();
            }
        }
    }

    public static void Main() {

        // Object Is Created From The Class TcpListener To Try And "Catch" A Client That Is Looking For The Server
        TcpListener listener = null;
        try {
            // The Object Is Given An IPAdress: "127.0.0.1", And The Port: "10000"
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 10000);
            listener.Start();
            Console.WriteLine("MultiThreadedEchoServer started...");

            // The Server Will Wait For Incoming Clients While Open
            while (true) {
                Console.WriteLine("Waiting for client...");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Accepted new client...");
                Thread t = new Thread(ProcessClientRequests);
                t.Start(client);
            }
        } catch (Exception e) {
            Console.WriteLine(e);
        } finally { // Called To Stop The Listener From Looking For Clients If An Exception Is Called
            if (listener != null) {
                listener.Stop();
            }
        }
    }
}