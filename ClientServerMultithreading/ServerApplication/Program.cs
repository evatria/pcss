using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class MultiThreadedEchoServer
{
    static int totalNumberOfAs = 0;

    private static void ProcessClientRequests(object argument)
    {
        TcpClient client = (TcpClient)argument;
        try {
            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());
            string s = String.Empty;
            while (!(s = reader.ReadLine()).Equals("Exit") || (s == null)) {
                Console.WriteLine("Client sends the following string: " + s);
                int count = s.Split('a').Length - 1;
                totalNumberOfAs = totalNumberOfAs + count;
                Console.WriteLine("The accumulated number of a's found in all messages from all client threads so far: " + totalNumberOfAs + "\n");
                writer.WriteLine("The letter 'a' was found " + count + " times in the string you sent the server.");
                writer.Flush();
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
                Console.WriteLine("Waiting for client...");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Accepted new client...");
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