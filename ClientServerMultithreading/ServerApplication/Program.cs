using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class MultiThreadedEchoServer
{
    static String id1 = "noIdYet";
    static String id2 = "noIdYet";
    static String id3 = "noIdYet";
    static int amountOfPlayersConnected = 0;

    private static void ProcessClientRequests(object argument)
    {
        
        TcpClient client = (TcpClient)argument;
        try {
            
            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());
            string s = String.Empty;
            while (!(s = reader.ReadLine()).Equals("Exit") || (s == null)) {

                if (amountOfPlayersConnected < 3) {

                    if (s != "") {


                if (s[0] == 'x' && s[1] == 'I' && s[2] == 'D' && s[3] == 'x' && s[4] == '_' ) {
                String[] splitString = s.Split('_');
                Console.Write("ID: " + splitString[1] + "\n");


                if (id1 == "noIdYet") {
                    id1 = splitString[1];
                    Console.Write("player 1: " + id1 + "\n");
                        Console.WriteLine ("Waiting for more players. \n");
                        amountOfPlayersConnected++;
                } else if (id1 != "noIdYet" && id2 == "noIdYet") {
                    id2 = splitString[1];
                    Console.Write("player 2: " + id2 + "\n");
                        Console.WriteLine ("Waiting for more players. \n");
                        amountOfPlayersConnected++;
                } else if (id2 != "noIdYet" && id3 == "noIdYet") {
                    id3 = splitString[1];
                    Console.Write("player 3: " + id3 + "\n");
                        Console.WriteLine ("Found three players! \n");
                        amountOfPlayersConnected++;
                }

                if (id1 != "noIdYet" && id2 != "noIdYet" && id3 != "noIdYet") {
                    Console.Write("Player 1: " + id1 + "\n");
                    Console.Write("Player 2: " + id2 + "\n");
                    Console.Write("Player 3: " + id3 + "\n");
                }
                }
                }
                    }
                if (amountOfPlayersConnected > 2) {
                Console.WriteLine ("Ready to go! Enough players connected.");
                        writer.WriteLine("Starting game! Highest number wins!");
                    writer.Flush();

                } else {
                        writer.WriteLine("Waiting for more players... Amount of players connected: " + amountOfPlayersConnected);
                    writer.Flush();
                //Console.Write("input: " + s + "\n");

                 
                }

                
            }
            reader.Close();
            writer.Close();
            client.Close();
            Console.WriteLine("Closing client connection");
        } catch (IOException) {
            Console.WriteLine("There was a problem. Exiting");
        } finally {
            if (client != null) {
                client.Close();
            }
        }
    }

    public static void Main()
    {
        TcpListener listener = null;
        try {
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 10000);
            listener.Start();
            Console.WriteLine("MultiThreadedEchoServer started...");
            while (true) {
                Console.WriteLine("Waiting for client... \n");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Accepted new client... \n");
                Thread t = new Thread(ProcessClientRequests);
                t.Start(client);
            }
        } catch (Exception e) {
            Console.WriteLine(e);
        } finally {
            if (listener != null) {
                listener.Stop();
            }
        }
    }
}