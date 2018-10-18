
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
        try { // try-catch Tries To Catch Exceptions And Prints It Out If Something Goes Wrong In The Program
            TcpClient client = new TcpClient("127.0.0.1", 10000); // Client IP and port, 127.0.0.1 is localhost
            StreamReader reader = new StreamReader(client.GetStream()); // For Reading Data From The Server
            StreamWriter writer = new StreamWriter(client.GetStream()); // For Writing Data To The Server
            String s = String.Empty; // String s Is Used To Temporarily Store What Is Input Into The Console
            while (!s.Equals("Exit")) {
                if (!selectedName) {
                Console.WriteLine("Connected to server! \n"); // Outputs Message To Console
                Console.Write("Hello There! Please select a unique screen name:  "); // Outputs Message To Console
                    clientName = Console.ReadLine(); // Write The Screen Name You Want
                    s = "++"+clientName; // Store It In The String - the ++ is added before it's sent so the server can identify it later

                    selectedName = true; 
                    while (clientName.Length < 2) { // String Length Need To Be Larger Than 2
                    Console.WriteLine("Your unique screen name needs to be longer. \n");
                    Console.Write("Hello There! Please select a unique screen name:  ");
                    clientName = Console.ReadLine();
                    s = "++"+clientName;
                }
                } else if (selectedName && !joinedLobby && !startingGame) { // If You Selected A Name But Did Not Join And/Or Start A Game Yet
                    Console.WriteLine("Here are your options: \n");
                    Console.WriteLine("lobbylist: View list of lobbies");
                    Console.WriteLine("open 1-3: create new lobby");
                    Console.WriteLine("close 1-3: close lobby");
                    Console.WriteLine("join 1-3: join lobby \n");

                    s = clientName+"_"+Console.ReadLine(); //the client name and an underscore is added before it's sent so the server can identify it
                    } 


                    if (joinedLobby && !startingGame) { // If You Joined A Lobby But Did Not Start The Game Yet
                Console.WriteLine("Waiting for game to start.");
                    Console.WriteLine("You are in lobby " + lobbyNumber);
                    Console.WriteLine("Type leave to leave the lobby.");
                    Console.WriteLine("Press Enter to update the state of the lobby. \n");
                    s = clientName+"_"+Console.ReadLine(); //the client name and an underscore is added before it's sent so the server can identify it
                    }


                    if (startingGame) { // If A Game Has Started
                    Console.WriteLine("Starting Game! Press enter to see who won! \n \n");
                    s = Console.ReadLine()+"xox9_"; //random numbers xox9_ added at the end so the server can identify it
                    //Console.WriteLine("Sending this input: " + s);
                    }
                
                Console.WriteLine();
                writer.WriteLine(s); // Sends Input To The Server
                writer.Flush(); // Flushes The Streamreader

                String server_string = reader.ReadLine(); // Streamreader To Receive Data/Information From The Server
                Console.WriteLine("From Server: " + server_string + "\n");

                /* 
                   Below Code Checks Which Lobby The Player Is Connected To, 
                   How Many Other Players Are Connected And If The Game Is Ready To Start
                   It Receives Strings From The Server According To Which Other Players Joined The Game etc. 
                   This Happens via The String server_string streamreader (because the server can only send one line at a time, we make the clients print the code)
                */

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
            reader.Close(); // Called To Close Reader After The Game Has Ended
            writer.Close(); // Called To Close Writer After The Game Has Ended
            client.Close(); // Called To Close The Client After The Game Has Ended
        } catch (Exception e) { // If There Are Any Errors ...
            Console.WriteLine(e); // Output Them To The Console
        }
    }
}