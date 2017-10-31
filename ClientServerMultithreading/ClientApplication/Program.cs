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
        Console.Write("\nWrite r and press enter when you are ready \n");

        TcpClient client = new TcpClient("127.0.0.1", 10000);
        StreamReader reader = new StreamReader(client.GetStream());
        StreamWriter writer = new StreamWriter(client.GetStream());

        String readyCheck = Console.ReadLine();

        while(readyCheck.Equals("r")) {
            try {
               
                String s = String.Empty;

                Console.Write("\nYou are connected to the server. Waiting for other players.");
                Console.Write("\nEnter a string to send to the server: ");
                s = Console.ReadLine();
                Console.WriteLine();
                writer.WriteLine(s);
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
}