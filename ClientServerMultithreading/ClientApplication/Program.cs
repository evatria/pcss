
// Using Directive List
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

// Creating The public class "EchoClient"
public class EchoClient {

    // MAXIMUM 3 CLIENTS SUPPORTED

    // Calling static variables
    static bool selectedName = false;
    static bool joinedLobby = false;
    static int lobbyNumber = 0;
    static String clientName = "";
    static bool startingGame = false;


    public static void Main() {
        try {
            TcpClient client = new TcpClient("127.0.0.1", 10000); // client IP and port, 127.0.0.1 is localhost
            StreamReader reader = new StreamReader(client.GetStream()); // for reading data from the server
            StreamWriter writer = new StreamWriter(client.GetStream()); // for writing data to the server
            String s = String.Empty; // String s is used to temporarily store what is input into the console
            while (!s.Equals("Exit")) {
                if (!selectedName) {
                Console.WriteLine("Connected to server! \n");
                Console.Write("Hello There! Please select a unique screen name:  "); // outputs message to console
                    clientName = Console.ReadLine(); // write the screen name you want
                    s = "++"+clientName; // store it in the string
                    
                    selectedName = true; 
                    while (clientName.Length < 2) { // string length needs to be larger than 2 
                    Console.WriteLine("Your unique screen name needs to be longer. \n");
                    Console.Write("Hello There! Please select a unique screen name:  ");
                    clientName = Console.ReadLine();
                    s = "++"+clientName;
                }
                } else if (selectedName && !joinedLobby && !startingGame) { // if you selected a name but did not join and/or start a game yet
                    Console.WriteLine("Here are your options: \n");
                    Console.WriteLine("lobbylist: View list of lobbies");
                    Console.WriteLine("open 1-3: create new lobby");
                    Console.WriteLine("close 1-3: close lobby");
                    Console.WriteLine("join 1-3: join lobby \n");

                    s = clientName+"_"+Console.ReadLine();
                    } 


                    if (joinedLobby && !startingGame) { // if you joined a lobby but did not start the game yet
                Console.WriteLine("Waiting for game to start.");
                    Console.WriteLine("You are in lobby " + lobbyNumber);
                    Console.WriteLine("Type leave to leave the lobby.");
                    Console.WriteLine("Press Enter to update the state of the lobby. \n");
                    s = clientName+"_"+Console.ReadLine();
                    }


                    if (startingGame) {
                    Console.WriteLine("Starting Game! Press enter to see who won! \n \n");
                    s = Console.ReadLine()+"xox9_";
                    //Console.WriteLine("Sending this input: " + s);
                    }
                
                Console.WriteLine();
                writer.WriteLine(s); // sends input to the server
                writer.Flush(); //flushes the streamreader

                String server_string = reader.ReadLine(); // streamreader to receive data/information from the server
                Console.WriteLine("From Server: " + server_string + "\n");

                // below code checks which lobby the player is connected to, how many other players are connected and if the game is ready to start
                // it receives strings from the server according to which other players joined the game etc. 
                // this happens via the String server_string streamreader


                if (server_string == "Joined lobby 1 (1)" || server_string == "Joined lobby 1 (2)") {
                    joinedLobby = true;
                    lobbyNumber = 1;
                } else if (server_string == "Joined lobby 1 (3)" || server_string == "3 Players connected to lobby 1! Ready to start game!") {
                    joinedLobby = true;
                    lobbyNumber = 1;
                    startingGame = true;
                }

                if (server_string == "Joined lobby 2 (1)" || server_string == "Joined lobby 2 (2)") {
                    joinedLobby = true;
                    lobbyNumber = 2;
                } else if (server_string == "Joined lobby 2 (3)" || server_string == "3 Players connected to lobby 2! Ready to start game!") {                 
                    joinedLobby = true;
                    lobbyNumber = 2;
                    startingGame = true;
                }

                if (server_string == "Joined lobby 3 (1)" || server_string == "Joined lobby 3 (2)") {
                    joinedLobby = true;
                    lobbyNumber = 3;
                } else if (server_string == "Joined lobby 3 (3)" || server_string == "3 Players connected to lobby 3! Ready to start game!") {
                    joinedLobby = true;
                    lobbyNumber = 3;
                    startingGame = true;
                }
            }
            reader.Close();
            writer.Close();
            client.Close();
        } catch (Exception e) { // if there are any errors ... 
            Console.WriteLine(e); // output them to the console
        }
    }
}