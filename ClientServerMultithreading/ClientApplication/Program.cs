using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class EchoClient
{

    public static void Main()
    {
        Console.Write("Please enter your screen name and press enter: \n");
        String screenName = Console.ReadLine();
        Console.Write("\nWelcome " + screenName + ". You are now connected to the server.");

        try {
        TcpClient client = new TcpClient("127.0.0.1", 10000);
        StreamReader reader = new StreamReader(client.GetStream());
        StreamWriter writer = new StreamWriter(client.GetStream());

        /*String s = String.Empty;
        s = Console.ReadLine();
        Console.Write("\nEnter a string to send to the server: ");*/

        Console.Write("\nYou are connected to the server. Waiting for other players.");
        
        Console.WriteLine();
        writer.WriteLine(screenName);
        writer.Flush();
        String server_string = reader.ReadLine();
        Console.WriteLine(server_string);

        reader.Close();
        writer.Close();
        client.Close();

        } catch (Exception e) {
            Console.WriteLine(e);
        }
    }
}
