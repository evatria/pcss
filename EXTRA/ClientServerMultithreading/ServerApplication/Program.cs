using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class MultiThreadedEchoServer {

    static bool selectedName = false;
    static String firstPlayerName = "";
    static String secondPlayerName = "";
    static String thirdPlayerName = "";

    static bool[] openLobbies = {false, false, false};
    static int playersInLobby1 = 0;
    static int playersInLobby2 = 0;
    static int playersInLobby3 = 0;
    
    static bool insideALobby = false;

    static int tempLobby = 0;

    static bool firstClientConnected = false;
    static bool secondClientConnected = false;
    static bool thirdClientConnected = false;

    private static void ProcessClientRequests(object argument) {

        TcpClient client = (TcpClient)argument;
        try {
            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());
            string s = String.Empty;
            while (!(s = reader.ReadLine()).Equals("Exit") || (s == null)) {
                //Console.WriteLine("\nInput: " + s);
                if (s[0] == '+' && s[1] == '+' && !firstClientConnected) {
                    firstPlayerName = s;
                    Console.WriteLine(firstPlayerName + " joined the server");
                    writer.WriteLine("Name selected: " + firstPlayerName);
                    selectedName = true;
                    firstClientConnected = true;
                    Console.WriteLine("firstClientConnected: " + firstClientConnected + "\n");
                 } else if (s[0] == '+' && s[1] == '+' && firstClientConnected && !secondClientConnected) {
                    secondPlayerName = s;
                    Console.WriteLine(secondPlayerName + " joined the server");
                    writer.WriteLine("Name selected: " + secondPlayerName);
                    selectedName = true;
                    secondClientConnected = true;
                    Console.WriteLine("secondClientConnected: " + secondClientConnected + "\n");
                 } else if (s[0] == '+' && s[1] == '+' && secondClientConnected) {
                    thirdPlayerName = s;
                    Console.WriteLine(thirdPlayerName + " joined the server");
                    writer.WriteLine("Name selected: " + thirdPlayerName);
                    selectedName = true;
                    thirdClientConnected = true;
                    Console.WriteLine("thirdClientConnected: " + thirdClientConnected + "\n");
                 } else {
                    String j = string.Concat("++", s);
                if (j == (firstPlayerName+"_lobbylist")) {
                        Console.WriteLine(firstPlayerName + " Requested to see the lobby list");
                    writer.WriteLine("Lobby 1: " + (openLobbies[0]?"Open " + "(" + playersInLobby1 + ")":"Closed ") +
                        "| Lobby 2: " + (openLobbies[1]?"Open " + "(" + playersInLobby2 + ")":"Closed ") +
                        "| Lobby 3: " + (openLobbies[2]?"Open " + "(" + playersInLobby3 + ")":"Closed" ));

                } else if (j == (secondPlayerName+"_lobbylist")) {
                        Console.WriteLine(secondPlayerName + " Requested to see the lobby list");
                    writer.WriteLine("Lobby 1: " + (openLobbies[0]?"Open " + "(" + playersInLobby1 + ")":"Closed ") +
                        "| Lobby 2: " + (openLobbies[1]?"Open " + "(" + playersInLobby2 + ")":"Closed ") +
                        "| Lobby 3: " + (openLobbies[2]?"Open " + "(" + playersInLobby3 + ")":"Closed" ));

                } else if (j == (thirdPlayerName+"_lobbylist")) {
                        Console.WriteLine(thirdPlayerName + " Requested to see the lobby list");
                    writer.WriteLine("Lobby 1: " + (openLobbies[0]?"Open " + "(" + playersInLobby1 + ")":"Closed ") +
                        "| Lobby 2: " + (openLobbies[1]?"Open " + "(" + playersInLobby2 + ")":"Closed ") +
                        "| Lobby 3: " + (openLobbies[2]?"Open " + "(" + playersInLobby3 + ")":"Closed" ));

                } else if (j == (firstPlayerName+"_Open 1") || j == (firstPlayerName+"_open 1")) {
                        if (!openLobbies[0]) {
                        openLobbies[0] = true;
                    writer.WriteLine("Opened lobby 1");
                        Console.WriteLine(firstPlayerName + " Opened lobby 1");
                        } else {
                         writer.WriteLine("Tried to open lobby 1 but it was already open.");
                        Console.WriteLine(firstPlayerName + " Tried to open lobby 1 but it was already open");
                         }
                } else if (j == (secondPlayerName+"_Open 1") || j == (secondPlayerName+"_open 1")) {
                        if (!openLobbies[0]) {
                        openLobbies[0] = true;
                    writer.WriteLine("Opened lobby 1");
                        Console.WriteLine(secondPlayerName + " Opened lobby 1");
                        } else {
                         writer.WriteLine("Tried to open lobby 1 but it was already open.");
                        Console.WriteLine(secondPlayerName + " Tried to open lobby 1 but it was already open");
                         }
                } else if (j == (thirdPlayerName+"_Open 1") || j == (thirdPlayerName+"_open 1")) {
                        if (!openLobbies[0]) {
                        openLobbies[0] = true;
                    writer.WriteLine("Opened lobby 1");
                        Console.WriteLine(thirdPlayerName + " Opened lobby 1");
                        } else {
                         writer.WriteLine("Tried to open lobby 1 but it was already open.");
                        Console.WriteLine(thirdPlayerName + " Tried to open lobby 1 but it was already open");
                         }
                } else if (j == (firstPlayerName+"_Open 2") || j == (firstPlayerName+"_open 2")) {
                        if (!openLobbies[1]) {
                        openLobbies[1] = true;
                    writer.WriteLine("Opened lobby 2");
                        Console.WriteLine(firstPlayerName + " Opened lobby 2");
                        } else {
                         writer.WriteLine("Tried to open lobby 2 but it was already open.");
                        Console.WriteLine(firstPlayerName + " Tried to open lobby 2 but it was already open");
                         }
                } else if (j == (secondPlayerName+"_Open 2") || j == (secondPlayerName+"_open 2")) {
                        if (!openLobbies[1]) {
                        openLobbies[1] = true;
                    writer.WriteLine("Opened lobby 2");
                        Console.WriteLine(secondPlayerName + " Opened lobby 2");
                        } else {
                         writer.WriteLine("Tried to open lobby 2 but it was already open.");
                        Console.WriteLine(secondPlayerName + " Tried to open lobby 2 but it was already open");
                         }
                } else if (j == (thirdPlayerName+"_Open 2") || j == (thirdPlayerName+"_open 2")) {
                        if (!openLobbies[1]) {
                        openLobbies[1] = true;
                    writer.WriteLine("Opened lobby 2");
                        Console.WriteLine(thirdPlayerName + " Opened lobby 2");
                        } else {
                         writer.WriteLine("Tried to open lobby 2 but it was already open.");
                        Console.WriteLine(thirdPlayerName + " Tried to open lobby 2 but it was already open");
                        }
                    } else if (j == (firstPlayerName+"_Open 3") || j == (firstPlayerName+"_open 3")) {
                        if (!openLobbies[2]) {
                        openLobbies[2] = true;
                    writer.WriteLine("Opened lobby 3");
                        Console.WriteLine(firstPlayerName + " Opened lobby 3");
                        } else {
                         writer.WriteLine("Tried to open lobby 3 but it was already open.");
                        Console.WriteLine(firstPlayerName + " Tried to open lobby 3 but it was already open");
                         }
                } else if (j == (secondPlayerName+"_Open 3") || j == (secondPlayerName+"_open 3")) {
                        if (!openLobbies[2]) {
                        openLobbies[2] = true;
                    writer.WriteLine("Opened lobby 3");
                        Console.WriteLine(secondPlayerName + " Opened lobby 2");
                        } else {
                         writer.WriteLine("Tried to open lobby 3 but it was already open.");
                        Console.WriteLine(secondPlayerName + " Tried to open lobby 3 but it was already open");
                         }
                } else if (j == (thirdPlayerName+"_Open 3") || j == (thirdPlayerName+"_open 3")) {
                        if (!openLobbies[2]) {
                        openLobbies[2] = true;
                    writer.WriteLine("Opened lobby 3");
                        Console.WriteLine(thirdPlayerName + " Opened lobby 3");
                        } else {
                         writer.WriteLine("Tried to open lobby 3 but it was already open.");
                        Console.WriteLine(thirdPlayerName + " Tried to open lobby 3 but it was already open");
                        }
                    } else if ( s == "close 1" || s == "Close 1") {
                        if (openLobbies[0]) {
                        openLobbies[0] = false;
                        writer.WriteLine("Closed lobby 1");
                        Console.WriteLine(firstPlayerName + " Closed lobby 1");
                        } else {
                         writer.WriteLine("Tried to close lobby 1 but it was already closed.");
                        Console.WriteLine(firstPlayerName + " Tried to close lobby 1 but it was already closed");
                         }
                } else if ( s == "close 2" || s == "Close 2") {
                        if (openLobbies[1]) {
                        openLobbies[1] = false;
                        writer.WriteLine("Closed lobby 2");
                        Console.WriteLine(firstPlayerName + " Closed lobby 2");
                        } else {
                         writer.WriteLine("Tried to close lobby 2 but it was already closed.");
                        Console.WriteLine(firstPlayerName + " Tried to close lobby 2 but it was already closed");
                         }
                } else if ( s == "close 3" || s == "Close 3") {
                        if (openLobbies[2]) {
                        openLobbies[2] = false;
                        writer.WriteLine("Closed lobby 3");
                        Console.WriteLine(firstPlayerName + " Closed lobby 3");
                        } else {
                         writer.WriteLine("Tried to close lobby 3 but it was already closed.");
                        Console.WriteLine(firstPlayerName + " Tried to close lobby 3 but it was already closed");
                         }
                } else if ( s == "join 1" || s == "Join 1") {
                        if (openLobbies[0] && !insideALobby) {
                        playersInLobby1++;
                        insideALobby = true;
                        tempLobby = 1;
                 writer.WriteLine("Joined lobby 1");
                            Console.WriteLine(firstPlayerName + " Joined lobby 1");
                        } else {
                 writer.WriteLine("Sorry! Lobby 1 is currently closed or you are already in a lobby.");
                            Console.WriteLine(firstPlayerName + " Tried to join lobby 1 but it was closed or he is already in a lobby.");
                 }
                } else if ( s == "join 2" || s == "Join 2") {
                        if (openLobbies[1] && !insideALobby) {
                        playersInLobby2++;
                        insideALobby = true;
                        tempLobby = 2;
                 writer.WriteLine("Joined lobby 2");
                            Console.WriteLine(firstPlayerName + " Joined lobby 2");
                        } else {
                 writer.WriteLine("Sorry! Lobby 2 is currently closed or you are already in a lobby.");
                            Console.WriteLine(firstPlayerName + " Tried to join lobby 2 but it was closed or he is already in a lobby.");
                 }
                } else if ( s == "join 3" || s == "Join 3") {
                        if (openLobbies[2] && !insideALobby) {
                        playersInLobby3++;
                        insideALobby = true;
                        tempLobby = 3;
                 writer.WriteLine("Joined lobby 3");
                            Console.WriteLine(firstPlayerName + " Joined lobby 3");
                        } else {
                 writer.WriteLine("Sorry! Lobby 3 is currently closed or you are already in a lobby.");
                            Console.WriteLine(firstPlayerName + " Tried to join lobby 3 but it was closed or he is already in a lobby.");
                 }
                } else if ( s == "leave") {
                        if (insideALobby) {
                    writer.WriteLine("Left lobby");
                            if (tempLobby == 1) {
                            playersInLobby1--;
                            insideALobby = false;
                                }
                            if (tempLobby == 2) {
                            playersInLobby2--;
                            insideALobby = false;
                                }
                            if (tempLobby == 3) {
                            playersInLobby3--;
                            insideALobby = false;
                                }
                            Console.WriteLine(firstPlayerName + " Left lobby " + tempLobby);
                    } else {
                    writer.WriteLine("Sorry. You are not in a lobby, so you can't leave it.");
                            Console.WriteLine(firstPlayerName + " Tried to leave lobby but was not in a lobby.");
                    }
                    
                } else {
                    writer.WriteLine("Unrecognized Command.");
                    }
                }
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

    public static void Main() {
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