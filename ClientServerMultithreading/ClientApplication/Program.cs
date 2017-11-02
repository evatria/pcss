using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

//workfromhometest

public class EchoClient {
    static Boolean selectedId = false;
public static void Main() {
    try {
    TcpClient client = new TcpClient("127.0.0.1", 10000);
    StreamReader reader = new StreamReader(client.GetStream());
    StreamWriter writer = new StreamWriter(client.GetStream());
    String s = String.Empty;
            String x = "asd";

    while (!s.Equals("Exit")) {
        
<<<<<<< HEAD
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

=======
>>>>>>> parent of 178368f... DET MED HIGHEST NUMBER WINS FUNGERER IKKE. Kan ikke se om det er fordi serveren ikke sender, eller fordi clienten ikke printer...
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
                    } else {
<<<<<<< HEAD
              }
        Console.Write("Press enter to update the state of the lobby.");
=======
              
                 Console.Write("Press enter to update the state of the lobby.");
>>>>>>> parent of 178368f... DET MED HIGHEST NUMBER WINS FUNGERER IKKE. Kan ikke se om det er fordi serveren ikke sender, eller fordi clienten ikke printer...
                    
        s = Console.ReadLine();

        Console.WriteLine();
        writer.WriteLine(s);
<<<<<<< HEAD
                   // Console.Clear();
                    
        
        }
=======
                    Console.Clear();
                    }
>>>>>>> parent of 178368f... DET MED HIGHEST NUMBER WINS FUNGERER IKKE. Kan ikke se om det er fordi serveren ikke sender, eller fordi clienten ikke printer...

        writer.Flush();
        String server_string = reader.ReadLine();
        Console.WriteLine(server_string + "\n");
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