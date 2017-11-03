using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class EchoClient {

    static bool selectedName = false;
    static bool joinedLobby = false;
    static int lobbyNumber = 0;
    static String clientName = "";

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
                    if (s == "join 1" || s == "Join 1")  {
                        lobbyNumber = 1;
                        joinedLobby = true;
                    } else if (s == "join 2" || s == "Join 2")  {
                        lobbyNumber = 2;
                        joinedLobby = true;
                    } else if (s == "join 3" || s == "Join 3")  {
                        lobbyNumber = 3;
                        joinedLobby = true;
                    }

                    } else if (joinedLobby) {
                Console.WriteLine("Waiting for game to start.");
                    Console.WriteLine("You are in lobby " + lobbyNumber);
                    Console.WriteLine("Type leave to leave the lobby.");
                    Console.WriteLine("Press Enter to update the state of the lobby. \n");
                    s = clientName+Console.ReadLine();

                }
                
                Console.WriteLine();
                writer.WriteLine(s);
                writer.Flush();
                String server_string = reader.ReadLine();
                //Console.Clear();
                Console.WriteLine("From Server: " + server_string + "\n");
            }
            reader.Close();
            writer.Close();
            client.Close();
        } catch (Exception e) {
            Console.WriteLine(e);
        }
    }
}