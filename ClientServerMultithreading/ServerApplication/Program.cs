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

    static bool[] openLobbies = {false, false, false}; // Man burde lave alle de andre ting til arrays ligesom det her. Koden ville være meget pænere. Det er bare et lidt stort arbejde.
    static int playersInLobby1 = 0;
    static int playersInLobby2 = 0;
    static int playersInLobby3 = 0;
    
    static bool firstPlayerInsideALobby = false;
    static bool secondPlayerInsideALobby = false;
    static bool thirdPlayerInsideALobby = false;

    static int firstPlayerTempLobby = 0;
    static int secondPlayerTempLobby = 0;
    static int thirdPlayerTempLobby = 0;

    static bool firstClientConnected = false;
    static bool secondClientConnected = false;
    static bool thirdClientConnected = false;

    static bool foundRandom = false;

    static int x = 0;
    static int y = 0;
    static int z = 0;
    
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
                    //Console.WriteLine(j);
                if (j == (firstPlayerName+"_lobbylist")) {
                        Console.WriteLine(firstPlayerName + " Requested to see the lobby list");
                    writer.WriteLine("Lobby 1: " + (openLobbies[0]?"Open " + "(" + playersInLobby1 + ")":"Closed ") +
                        " | Lobby 2: " + (openLobbies[1]?"Open " + "(" + playersInLobby2 + ")":"Closed ") +
                        " | Lobby 3: " + (openLobbies[2]?"Open " + "(" + playersInLobby3 + ")":"Closed" ));

                } else if (j == (secondPlayerName+"_lobbylist")) {
                        Console.WriteLine(secondPlayerName + " Requested to see the lobby list");
                    writer.WriteLine("Lobby 1: " + (openLobbies[0]?"Open " + "(" + playersInLobby1 + ")":"Closed ") +
                        " | Lobby 2: " + (openLobbies[1]?"Open " + "(" + playersInLobby2 + ")":"Closed ") +
                        " | Lobby 3: " + (openLobbies[2]?"Open " + "(" + playersInLobby3 + ")":"Closed" ));

                } else if (j == (thirdPlayerName+"_lobbylist")) {
                        Console.WriteLine(thirdPlayerName + " Requested to see the lobby list");
                    writer.WriteLine("Lobby 1: " + (openLobbies[0]?"Open " + "(" + playersInLobby1 + ")":"Closed ") +
                        " | Lobby 2: " + (openLobbies[1]?"Open " + "(" + playersInLobby2 + ")":"Closed ") +
                        " | Lobby 3: " + (openLobbies[2]?"Open " + "(" + playersInLobby3 + ")":"Closed" ));

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
                        Console.WriteLine(secondPlayerName + " Opened lobby 3");
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
                    } else if (j == (firstPlayerName+"_Close 1") || j == (firstPlayerName+"_close 1")) {
                        if (openLobbies[0]) {
                        openLobbies[0] = false;
                        playersInLobby1 = 0;
                    writer.WriteLine("Closed lobby 1");
                        Console.WriteLine(firstPlayerName + " Closed lobby 1");
                        } else {
                         writer.WriteLine("Tried to close lobby 1 but it was already closed.");
                        Console.WriteLine(firstPlayerName + " Tried to close lobby 1 but it was already closed");
                         }
                } else if (j == (secondPlayerName+"_Close 1") || j == (secondPlayerName+"_close 1")) {
                        if (openLobbies[0]) {
                        openLobbies[0] = false;
                            playersInLobby1 = 0;
                    writer.WriteLine("Closed lobby 1");
                        Console.WriteLine(secondPlayerName + " Closed lobby 1");
                        } else {
                         writer.WriteLine("Tried to close lobby 1 but it was already closed.");
                        Console.WriteLine(secondPlayerName + " Tried to close lobby 1 but it was already closed");
                         }
                } else if (j == (thirdPlayerName+"_Close 1") || j == (thirdPlayerName+"_close 1")) {
                        if (openLobbies[0]) {
                        openLobbies[0] = false;
                            playersInLobby1 = 0;
                    writer.WriteLine("Closed lobby 1");
                        Console.WriteLine(thirdPlayerName + " Closed lobby 1");
                        } else {
                         writer.WriteLine("Tried to close lobby 1 but it was already closed.");
                        Console.WriteLine(thirdPlayerName + " Tried to close lobby 1 but it was already closed");
                        }
                } else if (j == (firstPlayerName+"_Close 2") || j == (firstPlayerName+"_close 2")) {
                        if (openLobbies[1]) {
                        openLobbies[1] = false;
                            playersInLobby2 = 0;
                    writer.WriteLine("Closed lobby 2");
                        Console.WriteLine(firstPlayerName + " Closed lobby 2");
                        } else {
                         writer.WriteLine("Tried to close lobby 2 but it was already closed.");
                        Console.WriteLine(firstPlayerName + " Tried to close lobby 2 but it was already closed");
                         }
                } else if (j == (secondPlayerName+"_Close 2") || j == (secondPlayerName+"_close 2")) {
                        if (openLobbies[1]) {
                        openLobbies[1] = false;
                    writer.WriteLine("Closed lobby 2");
                            playersInLobby2 = 0;
                        Console.WriteLine(secondPlayerName + " Closed lobby 2");
                        } else {
                         writer.WriteLine("Tried to close lobby 2 but it was already closed.");
                        Console.WriteLine(secondPlayerName + " Tried to close lobby 2 but it was already closed");
                         }
                } else if (j == (thirdPlayerName+"_Close 2") || j == (thirdPlayerName+"_close 2")) {
                        if (openLobbies[1]) {
                        openLobbies[1] = false;
                    writer.WriteLine("Closed lobby 2");
                            playersInLobby2 = 0;
                        Console.WriteLine(thirdPlayerName + " Closed lobby 2");
                        } else {
                         writer.WriteLine("Tried to close lobby 2 but it was already closed.");
                        Console.WriteLine(thirdPlayerName + " Tried to close lobby 2 but it was already closed");
                        }
                } else if (j == (firstPlayerName+"_Close 3") || j == (firstPlayerName+"_close 3")) {
                        if (openLobbies[2]) {
                        openLobbies[2] = false;
                            playersInLobby3 = 0;
                    writer.WriteLine("Closed lobby 3");
                        Console.WriteLine(firstPlayerName + " Closed lobby 3");
                        } else {
                         writer.WriteLine("Tried to close lobby 3 but it was already closed.");
                        Console.WriteLine(firstPlayerName + " Tried to close lobby 3 but it was already closed");
                         }
                } else if (j == (secondPlayerName+"_Close 3") || j == (secondPlayerName+"_close 3")) {
                        if (openLobbies[2]) {
                        openLobbies[2] = false;
                            playersInLobby3 = 0;
                    writer.WriteLine("Closed lobby 3");
                        Console.WriteLine(secondPlayerName + " Closed lobby 3");
                        } else {
                         writer.WriteLine("Tried to close lobby 3 but it was already closed.");
                        Console.WriteLine(secondPlayerName + " Tried to close lobby 3 but it was already closed");
                         }
                } else if (j == (thirdPlayerName+"_Close 3") || j == (thirdPlayerName+"_close 3")) {
                        if (openLobbies[2]) {
                        openLobbies[2] = false;
                            playersInLobby3 = 0;
                    writer.WriteLine("Closed lobby 3");
                        Console.WriteLine(thirdPlayerName + " Closed lobby 3");
                        } else {
                         writer.WriteLine("Tried to close lobby 3 but it was already closed.");
                        Console.WriteLine(thirdPlayerName + " Tried to close lobby 3 but it was already closed");
                        }

                } else if (j == (firstPlayerName+"_join 1") || j == (firstPlayerName+"_Join 1")) {
                        if (openLobbies[0] && !firstPlayerInsideALobby) {
                        playersInLobby1++;
                        firstPlayerInsideALobby = true;
                        firstPlayerTempLobby = 1;
                        writer.WriteLine("Joined lobby 1 (" + playersInLobby1 + ")");
                            Console.WriteLine(firstPlayerName + " Joined lobby 1 (" + playersInLobby1 + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 1 is currently closed or you are already in a lobby.");
                            Console.WriteLine(firstPlayerName + " Tried to join lobby 1 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (secondPlayerName+"_join 1") || j == (secondPlayerName+"_Join 1")) {
                        if (openLobbies[0] && !secondPlayerInsideALobby) {
                        playersInLobby1++;
                        secondPlayerInsideALobby = true;
                        secondPlayerTempLobby = 1;
                 writer.WriteLine("Joined lobby 1 (" + playersInLobby1 + ")");
                            Console.WriteLine(secondPlayerName + " Joined lobby 1 (" + playersInLobby1 + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 1 is currently closed or you are already in a lobby.");
                            Console.WriteLine(secondPlayerName + " Tried to join lobby 1 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (thirdPlayerName+"_join 1") || j == (thirdPlayerName+"_Join 1")) {
                        if (openLobbies[0] && !thirdPlayerInsideALobby) {
                        playersInLobby1++;
                        thirdPlayerInsideALobby = true;
                        thirdPlayerTempLobby = 1;
                 writer.WriteLine("Joined lobby 1 (" + playersInLobby1 + ")");
                            Console.WriteLine(firstPlayerName + " Joined lobby 1 (" + playersInLobby1 + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 1 is currently closed or you are already in a lobby.");
                            Console.WriteLine(firstPlayerName + " Tried to join lobby 1 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (firstPlayerName+"_join 2") || j == (firstPlayerName+"_Join 2")) {
                        if (openLobbies[1] && !firstPlayerInsideALobby) {
                        playersInLobby2++;
                        firstPlayerInsideALobby = true;
                        firstPlayerTempLobby = 2;
                 writer.WriteLine("Joined lobby 2 (" + playersInLobby2 + ")");
                            Console.WriteLine(firstPlayerName + " Joined lobby 2 (" + playersInLobby2 + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 2 is currently closed or you are already in a lobby.");
                            Console.WriteLine(firstPlayerName + " Tried to join lobby 2 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (secondPlayerName+"_join 2") || j == (secondPlayerName+"_Join 2")) {
                        if (openLobbies[1] && !secondPlayerInsideALobby) {
                        playersInLobby2++;
                        secondPlayerInsideALobby = true;
                        secondPlayerTempLobby = 2;
                 writer.WriteLine("Joined lobby 2 (" + playersInLobby2 + ")");
                            Console.WriteLine(secondPlayerName + " Joined lobby 2 (" + playersInLobby2 + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 2 is currently closed or you are already in a lobby.");
                            Console.WriteLine(secondPlayerName + " Tried to join lobby 2 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (thirdPlayerName+"_join 2") || j == (thirdPlayerName+"_Join 2")) {
                        if (openLobbies[1] && !thirdPlayerInsideALobby) {
                        playersInLobby2++;
                        thirdPlayerInsideALobby = true;
                        thirdPlayerTempLobby = 2;
                 writer.WriteLine("Joined lobby 2 (" + playersInLobby2 + ")");
                            Console.WriteLine(firstPlayerName + " Joined lobby 2 (" + playersInLobby2 + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 2 is currently closed or you are already in a lobby.");
                            Console.WriteLine(firstPlayerName + " Tried to join lobby 2 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (firstPlayerName+"_join 3") || j == (firstPlayerName+"_Join 3")) {
                        if (openLobbies[2] && !firstPlayerInsideALobby) {
                        playersInLobby3++;
                        firstPlayerInsideALobby = true;
                        firstPlayerTempLobby = 3;
                 writer.WriteLine("Joined lobby 3 (" + playersInLobby3 + ")");
                            Console.WriteLine(firstPlayerName + " Joined lobby 3 (" + playersInLobby3 + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 3 is currently closed or you are already in a lobby.");
                            Console.WriteLine(firstPlayerName + " Tried to join lobby 3 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (secondPlayerName+"_join 3") || j == (secondPlayerName+"_Join 3")) {
                        if (openLobbies[2] && !secondPlayerInsideALobby) {
                        playersInLobby3++;
                        secondPlayerInsideALobby = true;
                        secondPlayerTempLobby = 3;
                 writer.WriteLine("Joined lobby 3 (" + playersInLobby3 + ")");
                            Console.WriteLine(secondPlayerName + " Joined lobby 3 (" + playersInLobby3 + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 3 is currently closed or you are already in a lobby.");
                            Console.WriteLine(secondPlayerName + " Tried to join lobby 3 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (thirdPlayerName+"_join 3") || j == (thirdPlayerName+"_Join 3")) {
                        if (openLobbies[2] && !thirdPlayerInsideALobby) {
                        playersInLobby3++;
                        thirdPlayerInsideALobby = true;
                        thirdPlayerTempLobby = 3;
                 writer.WriteLine("Joined lobby 3 (" + playersInLobby3 + ")");
                            Console.WriteLine(firstPlayerName + " Joined lobby 3 (" + playersInLobby3 + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 3 is currently closed or you are already in a lobby.");
                            Console.WriteLine(firstPlayerName + " Tried to join lobby 3 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (firstPlayerName+"_leave")) {
                        if (firstPlayerInsideALobby) {
                    writer.WriteLine("Left lobby");
                            if (firstPlayerTempLobby == 1) {
                            playersInLobby1--;
                            firstPlayerInsideALobby = false;
                                }
                            if (firstPlayerTempLobby == 2) {
                            playersInLobby2--;
                            firstPlayerInsideALobby = false;
                                }
                            if (firstPlayerTempLobby == 3) {
                            playersInLobby3--;
                            firstPlayerInsideALobby = false;
                                }
                            Console.WriteLine(firstPlayerName + " Left lobby " + firstPlayerTempLobby);
                    } else {
                    writer.WriteLine("Sorry. You are not in a lobby, so you can't leave it.");
                            Console.WriteLine(firstPlayerName + " Tried to leave lobby but was not in a lobby.");
                    }
                    } else if (j == (secondPlayerName+"_leave")) {
                        if (secondPlayerInsideALobby) {
                    writer.WriteLine("Left lobby");
                            if (secondPlayerTempLobby == 1) {
                            playersInLobby1--;
                            secondPlayerInsideALobby = false;
                                }
                            if (secondPlayerTempLobby == 2) {
                            playersInLobby2--;
                            secondPlayerInsideALobby = false;
                                }
                            if (secondPlayerTempLobby == 3) {
                            playersInLobby3--;
                            secondPlayerInsideALobby = false;
                                }
                            Console.WriteLine(secondPlayerName + " Left lobby " + secondPlayerTempLobby);
                    } else {
                    writer.WriteLine("Sorry. You are not in a lobby, so you can't leave it.");
                            Console.WriteLine(secondPlayerName + " Tried to leave lobby but was not in a lobby.");
                    }
                    } else if (j == (thirdPlayerName+"_leave")) {
                        if (thirdPlayerInsideALobby) {
                    writer.WriteLine("Left lobby");
                            if (thirdPlayerTempLobby == 1) {
                            playersInLobby1--;
                            thirdPlayerInsideALobby = false;
                                }
                            if (thirdPlayerTempLobby == 2) {
                            playersInLobby2--;
                            thirdPlayerInsideALobby = false;
                                }
                            if (thirdPlayerTempLobby == 3) {
                            playersInLobby3--;
                            thirdPlayerInsideALobby = false;
                                }
                            Console.WriteLine(thirdPlayerName + " Left lobby " + thirdPlayerTempLobby);
                    } else {
                    writer.WriteLine("Sorry. You are not in a lobby, so you can't leave it.");
                            Console.WriteLine(thirdPlayerName + " Tried to leave lobby but was not in a lobby.");
                    }
                    
                } else if (s[s.Length-1] == '_' && s[s.Length-2] == '9' && s[s.Length-3] == 'x' && s[s.Length-4] == 'o' && s[s.Length-5] == 'x') {
                        //Console.WriteLine("Received this input: " + s);
                        //Console.WriteLine("game");
                        Random rnd = new Random();

                        if (!foundRandom) {
                        x = rnd.Next(1,100);
                        y = rnd.Next(1,100);
                        z = rnd.Next(1,100);
                        while (x == z && x == y && y == z) {
                            x = rnd.Next(1,100);
                            y = rnd.Next(1,100);
                            z = rnd.Next(1,100);
                            }
                        foundRandom = true;
                        }

                        if (x > y && x > z) {
                        writer.WriteLine(" Highest number wins! " + firstPlayerName + " rolled " + x + ". " + secondPlayerName + " rolled " + y + ". " + thirdPlayerName + " rolled " + z + ". " + firstPlayerName + " Wins!! GAME OVER! RESTART SERVER AND CLIENTS TO PLAY AGAIN");
                            }
                        else if (x > y && x > z) {
                        writer.WriteLine(" Highest number wins! " + firstPlayerName + " rolled " + x + ". " + secondPlayerName + " rolled " + y + ". " + thirdPlayerName + " rolled " + z + ". " + firstPlayerName + " Wins!! GAME OVER! RESTART SERVER AND CLIENTS TO PLAY AGAIN");
                            }
                        else if (x > y && x > z) {
                        writer.WriteLine(" Highest number wins! " + firstPlayerName + " rolled " + x + ". " + secondPlayerName + " rolled " + y + ". " + thirdPlayerName + " rolled " + z + ". " + firstPlayerName + " Wins!! GAME OVER! RESTART SERVER AND CLIENTS TO PLAY AGAIN");
                            }
                    } else {
                    writer.WriteLine(""); //Opdater folket
                    }
                }

                if (playersInLobby1 == 3) {
                    Console.WriteLine("3 Players connected to lobby 1! Ready to start game!");
                    writer.Write("3 Players connected to lobby 1! Ready to start game!");
                }
                
                if (playersInLobby2 == 3) {
                    Console.WriteLine("3 Players connected to lobby 2! Ready to start game!");
                    writer.Write("3 Players connected to lobby 2! Ready to start game!");
                }
                
                if (playersInLobby3 == 3) {
                    Console.WriteLine("3 Players connected to lobby 3! Ready to start game!");
                    writer.Write("3 Players connected to lobby 3! Ready to start game!");
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