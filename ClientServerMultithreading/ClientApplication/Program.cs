using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class EchoClient {

    //Max 3 clients.

    static bool selectedName = false;
    static bool joinedLobby = false;
    static int lobbyNumber = 0;
    static String clientName = "";
    static bool startingGame = false;

    public static void Main() {
        try {
            TcpClient client = new TcpClient("127.0.0.1", 10000);
            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());
            String s = String.Empty;
            while (!s.Equals("Exit")) {
                if (!selectedName) {
                Console.WriteLine("Connected to server! \n");
                Console.Write("Hello There! Please select a unique screen name:  ");
                    clientName = Console.ReadLine();
                    s = "++"+clientName;
                    
                    selectedName = true;
                    while (clientName.Length < 2) {
                    Console.WriteLine("Your unique screen name needs to be longer. \n");
                    Console.Write("Hello There! Please select a unique screen name:  ");
                    clientName = Console.ReadLine();
                    s = "++"+clientName;
                }
                } else if (selectedName && !joinedLobby) {
                    Console.WriteLine("Here are your options: \n");
                    Console.WriteLine("lobbylist: View list of lobbies");
                    Console.WriteLine("open 1-3: create new lobby");
                    Console.WriteLine("close 1-3: close lobby");
                    Console.WriteLine("join 1-3: join lobby \n");

                    s = clientName+"_"+Console.ReadLine();
                    } 


                    if (joinedLobby && !startingGame) {
                Console.WriteLine("Waiting for game to start.");
                    Console.WriteLine("You are in lobby " + lobbyNumber);
                    Console.WriteLine("Type leave to leave the lobby.");
                    Console.WriteLine("Press Enter to update the state of the lobby. \n");
                    s = clientName+"_"+Console.ReadLine();
                    }

                    if (startingGame) {
                    Console.WriteLine("Starting Game! You can no longer use any commands. \n \n");
                    s = Console.ReadLine()+"xox9_";
                    }
                
                Console.WriteLine();
                writer.WriteLine(s);
                writer.Flush();
                String server_string = reader.ReadLine();
                Console.WriteLine("From Server: " + server_string + "\n");

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
        } catch (Exception e) {
            Console.WriteLine(e);
        }
    }
}