using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class MultiThreadedEchoServer
{
    //static int totalNumberOfAs = 0;
    static String id1 = "noIdYet";
    static String id2 = "noIdYet";
    static String id3 = "noIdYet";
    static Boolean threePlayersConnected = false;

    private static void ProcessClientRequests(object argument)
    {
        
        TcpClient client = (TcpClient)argument;
        try {
            
            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());
            string s = String.Empty;
            while (!(s = reader.ReadLine()).Equals("Exit") || (s == null)) {
                if (!threePlayersConnected) {
                //Console.Write("input: " + s + "\n");
                Console.Write("ID: " + s + "\n");
                Console.Write("\n");

                if (id1 == "noIdYet") {
                    id1 = s;
                    Console.Write("player 1: " + id1 + "\n");
                        Console.WriteLine ("Waiting for more players. \n");
                } else if (id1 != "noIdYet" && id2 == "noIdYet") {
                    id2 = s;
                    Console.Write("player 2: " + id2 + "\n");
                        Console.WriteLine ("Waiting for more players. \n");
                } else if (id2 != "noIdYet" && id3 == "noIdYet") {
                    id3 = s;
                    Console.Write("player 3: " + id3 + "\n");
                        Console.WriteLine ("Found three players! \n");
                }

                if (id1 != "noIdYet" && id2 != "noIdYet" && id3 != "noIdYet") {
                    Console.Write("3 players connected!" + "\n");
                    threePlayersConnected = true;
                    Console.Write("Player 1: " + id1 + "\n");
                    Console.Write("Player 2: " + id2 + "\n");
                    Console.Write("Player 3: " + id3 + "\n");
                }
                if (threePlayersConnected) {
                    Console.WriteLine ("Starting Game!");
                }
                
                writer.Flush();
                }
                

                /*if (s[0] == '0') {
                    Console.WriteLine("CREATING LOBBY 0");
                    writer.WriteLine("CREATING LOBBY 0");
                } else if (s[0] == '1') {
                    Console.WriteLine("JOINING LOBBY 0");
                    writer.WriteLine("JOINING LOBBY 0");
                } else {
                    Console.WriteLine("DID NOT RECOGNIZE COMMAND");
                    writer.WriteLine("DID NOT RECOGNIZE COMMAND");
                }*/

                //Console.WriteLine("Client sends the following string: " + s);
                //int count = s.Split('a').Length - 1;

                //totalNumberOfAs = totalNumberOfAs + count;
                //Console.WriteLine("The accumulated number of a's found in all messages from all client threads so far: " + totalNumberOfAs + "\n");
                //writer.WriteLine("The letter 'a' was found " + count + " times in the string you sent the server.");
                
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