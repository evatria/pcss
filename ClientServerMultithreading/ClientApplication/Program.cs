using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class EchoClient {
    static Boolean selectedId = false;
public static void Main() {

/*Console.Write("Press 0 to create a server. Press any other button to see a list of servers to join.");
    String x = Console.ReadLine();

    if (x == "0") {
            Console.Write("Creating server");
            String j = Console.ReadLine();
    } else {
            Console.Write("List of servers: \n");
            String j = Console.ReadLine();
    }*/

    try {
    TcpClient client = new TcpClient("127.0.0.1", 10000);
    StreamReader reader = new StreamReader(client.GetStream());
    StreamWriter writer = new StreamWriter(client.GetStream());
    String s = String.Empty;

    while (!s.Equals("Exit")) {
        if (!selectedId) {

        Console.Write("Connected to server! \n");
        Console.Write("Select a unique ID: ");
        s = Console.ReadLine();

        Console.WriteLine();
        writer.WriteLine(s);
        selectedId = true;
        }
        writer.Flush();
        String server_string = reader.ReadLine();
        Console.WriteLine("from server: " + server_string + "\n");
         
        }
    
    reader.Close();
    writer.Close();
    client.Close();

    } catch (Exception e) {
    Console.WriteLine(e);
    }
}
}