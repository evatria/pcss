using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class EchoClient {
    static bool selectedId = false;
    static bool selectedLobby = false;
public static void Main() {
    try {
    TcpClient client = new TcpClient("127.0.0.1", 10000);
    StreamReader reader = new StreamReader(client.GetStream());
    StreamWriter writer = new StreamWriter(client.GetStream());
    String s = String.Empty;
    String x = "asd";

    while (!s.Equals("Exit")) {
                
        if(!selectedLobby) {
                    while (!selectedLobby) {
                        //Console.Clear();
        Console.WriteLine("Join/create a lobby.");
        Console.WriteLine("Type lobby 1 to join lobby 1. If you type anything else you don't join a lobby.");
        
        String k = "LOBB!"+Console.ReadLine();
        
        String[] omfg = k.Split('!');

                    if (omfg[1] == "1") {
                        Console.WriteLine("Joined lobby " + omfg[1]);
                            writer.WriteLine(k);
                        selectedLobby = true;
                }
        
                    if (omfg[1] != "1") {
                        Console.WriteLine("Could not find a lobby to join.");
                        }
                    }
                    writer.Flush();
        } else {

        if (!selectedId) {
        Console.Write("Connected to server! \n");
        Console.Write("Select a unique name: ");
        x = "xIDx_"+Console.ReadLine();
                    while (x.Length < 8 || x.Length > 15) {
                        Console.Write("Name has to be more than 2 characters and less than 10 \n");
                        Console.Write("Select a unique ID: ");
                        x = "xIDx_"+Console.ReadLine();
                        }
        Console.WriteLine();
        writer.WriteLine(x);
        selectedId = true;
        writer.Flush();
                        
                    } else {
              }
        Console.Write("Press enter to update the state of the lobby.");
                    
        s = Console.ReadLine();

        Console.WriteLine();
        writer.WriteLine(s);
                   // Console.Clear();
                    
        
        }

        writer.Flush();
        String server_string = reader.ReadLine();
        Console.WriteLine("From server: " + server_string + "\n");
                if (server_string.Length > 80) {
                    Console.WriteLine("Game Over!");
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