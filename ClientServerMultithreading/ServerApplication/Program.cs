using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class MultiThreadedEchoServer {

    // MAXIMUM 3 CLIENTS SUPPORTED

    static bool selectedName = false;

    static bool foundRandom = false;

    static int x = 0;
    static int y = 0;
    static int z = 0;

    static String[] playerNames = {"", "", ""};
    static bool[] openLobbies = {false, false, false};
    static int[] playersinlobby = {0, 0, 0};
    static bool[] playerinlobby = {false, false, false};
    static int[] tempLobby = {0, 0, 0};
    static bool[] clientsConnected = {false, false, false};

    // Alt er sat ind i arrays her, så vi kan eventuelt lave koden 50% kortere med en masse for each loops. Orker bare ikke helt at gøre det zzz
    
    private static void ProcessClientRequests(object argument) {

        TcpClient client = (TcpClient)argument;
        try {
            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());
            string s = String.Empty;
            while (!(s = reader.ReadLine()).Equals("Exit") || (s == null)) {
                //Console.WriteLine("\nInput: " + s);
                if (s[0] == '+' && s[1] == '+' && !clientsConnected[0]) {
                    playerNames[0] = s;
                    Console.WriteLine(playerNames[0] + " joined the server");
                    writer.WriteLine("Name selected: " + playerNames[0]);
                    selectedName = true;
                    clientsConnected[0] = true;
                    Console.WriteLine("clientsConnected[0]: " + clientsConnected[0] + "\n");
                 } else if (s[0] == '+' && s[1] == '+' && clientsConnected[0] && !clientsConnected[1]) {
                    playerNames[1] = s;
                    Console.WriteLine(playerNames[1] + " joined the server");
                    writer.WriteLine("Name selected: " + playerNames[1]);
                    selectedName = true;
                    clientsConnected[1] = true;
                    Console.WriteLine("clientsConnected[1]: " + clientsConnected[1] + "\n");
                 } else if (s[0] == '+' && s[1] == '+' && clientsConnected[1]) {
                    playerNames[2] = s;
                    Console.WriteLine(playerNames[2] + " joined the server");
                    writer.WriteLine("Name selected: " + playerNames[2]);
                    selectedName = true;
                    clientsConnected[2] = true;
                    Console.WriteLine("clientsConnected[2]: " + clientsConnected[2] + "\n");
                 } else {
                    String j = string.Concat("++", s);
                    //Console.WriteLine(j);
                if (j == (playerNames[0]+"_lobbylist")) {
                        Console.WriteLine(playerNames[0] + " Requested to see the lobby list");
                    writer.WriteLine("Lobby 1: " + (openLobbies[0]?"Open " + "(" + playersinlobby[0] + ")":"Closed ") +
                        " | Lobby 2: " + (openLobbies[1]?"Open " + "(" + playersinlobby[1] + ")":"Closed ") +
                        " | Lobby 3: " + (openLobbies[2]?"Open " + "(" + playersinlobby[2] + ")":"Closed" ));

                } else if (j == (playerNames[1]+"_lobbylist")) {
                        Console.WriteLine(playerNames[1] + " Requested to see the lobby list");
                    writer.WriteLine("Lobby 1: " + (openLobbies[0]?"Open " + "(" + playersinlobby[0] + ")":"Closed ") +
                        " | Lobby 2: " + (openLobbies[1]?"Open " + "(" + playersinlobby[1] + ")":"Closed ") +
                        " | Lobby 3: " + (openLobbies[2]?"Open " + "(" + playersinlobby[2] + ")":"Closed" ));

                } else if (j == (playerNames[2]+"_lobbylist")) {
                        Console.WriteLine(playerNames[2] + " Requested to see the lobby list");
                    writer.WriteLine("Lobby 1: " + (openLobbies[0]?"Open " + "(" + playersinlobby[0] + ")":"Closed ") +
                        " | Lobby 2: " + (openLobbies[1]?"Open " + "(" + playersinlobby[1] + ")":"Closed ") +
                        " | Lobby 3: " + (openLobbies[2]?"Open " + "(" + playersinlobby[2] + ")":"Closed" ));

                } else if (j == (playerNames[0]+"_Open 1") || j == (playerNames[0]+"_open 1")) {
                        if (!openLobbies[0]) {
                        openLobbies[0] = true;
                    writer.WriteLine("Opened lobby 1");
                        Console.WriteLine(playerNames[0] + " Opened lobby 1");
                        } else {
                         writer.WriteLine("Tried to open lobby 1 but it was already open.");
                        Console.WriteLine(playerNames[0] + " Tried to open lobby 1 but it was already open");
                         }
                } else if (j == (playerNames[1]+"_Open 1") || j == (playerNames[1]+"_open 1")) {
                        if (!openLobbies[0]) {
                        openLobbies[0] = true;
                    writer.WriteLine("Opened lobby 1");
                        Console.WriteLine(playerNames[1] + " Opened lobby 1");
                        } else {
                         writer.WriteLine("Tried to open lobby 1 but it was already open.");
                        Console.WriteLine(playerNames[1] + " Tried to open lobby 1 but it was already open");
                         }
                } else if (j == (playerNames[2]+"_Open 1") || j == (playerNames[2]+"_open 1")) {
                        if (!openLobbies[0]) {
                        openLobbies[0] = true;
                    writer.WriteLine("Opened lobby 1");
                        Console.WriteLine(playerNames[2] + " Opened lobby 1");
                        } else {
                         writer.WriteLine("Tried to open lobby 1 but it was already open.");
                        Console.WriteLine(playerNames[2] + " Tried to open lobby 1 but it was already open");
                         }
                } else if (j == (playerNames[0]+"_Open 2") || j == (playerNames[0]+"_open 2")) {
                        if (!openLobbies[1]) {
                        openLobbies[1] = true;
                    writer.WriteLine("Opened lobby 2");
                        Console.WriteLine(playerNames[0] + " Opened lobby 2");
                        } else {
                         writer.WriteLine("Tried to open lobby 2 but it was already open.");
                        Console.WriteLine(playerNames[0] + " Tried to open lobby 2 but it was already open");
                         }
                } else if (j == (playerNames[1]+"_Open 2") || j == (playerNames[1]+"_open 2")) {
                        if (!openLobbies[1]) {
                        openLobbies[1] = true;
                    writer.WriteLine("Opened lobby 2");
                        Console.WriteLine(playerNames[1] + " Opened lobby 2");
                        } else {
                         writer.WriteLine("Tried to open lobby 2 but it was already open.");
                        Console.WriteLine(playerNames[1] + " Tried to open lobby 2 but it was already open");
                         }
                } else if (j == (playerNames[2]+"_Open 2") || j == (playerNames[2]+"_open 2")) {
                        if (!openLobbies[1]) {
                        openLobbies[1] = true;
                    writer.WriteLine("Opened lobby 2");
                        Console.WriteLine(playerNames[2] + " Opened lobby 2");
                        } else {
                         writer.WriteLine("Tried to open lobby 2 but it was already open.");
                        Console.WriteLine(playerNames[2] + " Tried to open lobby 2 but it was already open");
                        }
                    } else if (j == (playerNames[0]+"_Open 3") || j == (playerNames[0]+"_open 3")) {
                        if (!openLobbies[2]) {
                        openLobbies[2] = true;
                    writer.WriteLine("Opened lobby 3");
                        Console.WriteLine(playerNames[0] + " Opened lobby 3");
                        } else {
                         writer.WriteLine("Tried to open lobby 3 but it was already open.");
                        Console.WriteLine(playerNames[0] + " Tried to open lobby 3 but it was already open");
                         }
                } else if (j == (playerNames[1]+"_Open 3") || j == (playerNames[1]+"_open 3")) {
                        if (!openLobbies[2]) {
                        openLobbies[2] = true;
                    writer.WriteLine("Opened lobby 3");
                        Console.WriteLine(playerNames[1] + " Opened lobby 3");
                        } else {
                         writer.WriteLine("Tried to open lobby 3 but it was already open.");
                        Console.WriteLine(playerNames[1] + " Tried to open lobby 3 but it was already open");
                         }
                } else if (j == (playerNames[2]+"_Open 3") || j == (playerNames[2]+"_open 3")) {
                        if (!openLobbies[2]) {
                        openLobbies[2] = true;
                    writer.WriteLine("Opened lobby 3");
                        Console.WriteLine(playerNames[2] + " Opened lobby 3");
                        } else {
                         writer.WriteLine("Tried to open lobby 3 but it was already open.");
                        Console.WriteLine(playerNames[2] + " Tried to open lobby 3 but it was already open");
                        }
                    } else if (j == (playerNames[0]+"_Close 1") || j == (playerNames[0]+"_close 1")) {
                        if (openLobbies[0]) {
                        openLobbies[0] = false;
                        playersinlobby[0] = 0;
                    writer.WriteLine("Closed lobby 1");
                        Console.WriteLine(playerNames[0] + " Closed lobby 1");
                        } else {
                         writer.WriteLine("Tried to close lobby 1 but it was already closed.");
                        Console.WriteLine(playerNames[0] + " Tried to close lobby 1 but it was already closed");
                         }
                } else if (j == (playerNames[1]+"_Close 1") || j == (playerNames[1]+"_close 1")) {
                        if (openLobbies[0]) {
                        openLobbies[0] = false;
                            playersinlobby[0] = 0;
                    writer.WriteLine("Closed lobby 1");
                        Console.WriteLine(playerNames[1] + " Closed lobby 1");
                        } else {
                         writer.WriteLine("Tried to close lobby 1 but it was already closed.");
                        Console.WriteLine(playerNames[1] + " Tried to close lobby 1 but it was already closed");
                         }
                } else if (j == (playerNames[2]+"_Close 1") || j == (playerNames[2]+"_close 1")) {
                        if (openLobbies[0]) {
                        openLobbies[0] = false;
                            playersinlobby[0] = 0;
                    writer.WriteLine("Closed lobby 1");
                        Console.WriteLine(playerNames[2] + " Closed lobby 1");
                        } else {
                         writer.WriteLine("Tried to close lobby 1 but it was already closed.");
                        Console.WriteLine(playerNames[2] + " Tried to close lobby 1 but it was already closed");
                        }
                } else if (j == (playerNames[0]+"_Close 2") || j == (playerNames[0]+"_close 2")) {
                        if (openLobbies[1]) {
                        openLobbies[1] = false;
                            playersinlobby[1] = 0;
                    writer.WriteLine("Closed lobby 2");
                        Console.WriteLine(playerNames[0] + " Closed lobby 2");
                        } else {
                         writer.WriteLine("Tried to close lobby 2 but it was already closed.");
                        Console.WriteLine(playerNames[0] + " Tried to close lobby 2 but it was already closed");
                         }
                } else if (j == (playerNames[1]+"_Close 2") || j == (playerNames[1]+"_close 2")) {
                        if (openLobbies[1]) {
                        openLobbies[1] = false;
                    writer.WriteLine("Closed lobby 2");
                            playersinlobby[1] = 0;
                        Console.WriteLine(playerNames[1] + " Closed lobby 2");
                        } else {
                         writer.WriteLine("Tried to close lobby 2 but it was already closed.");
                        Console.WriteLine(playerNames[1] + " Tried to close lobby 2 but it was already closed");
                         }
                } else if (j == (playerNames[2]+"_Close 2") || j == (playerNames[2]+"_close 2")) {
                        if (openLobbies[1]) {
                        openLobbies[1] = false;
                    writer.WriteLine("Closed lobby 2");
                            playersinlobby[1] = 0;
                        Console.WriteLine(playerNames[2] + " Closed lobby 2");
                        } else {
                         writer.WriteLine("Tried to close lobby 2 but it was already closed.");
                        Console.WriteLine(playerNames[2] + " Tried to close lobby 2 but it was already closed");
                        }
                } else if (j == (playerNames[0]+"_Close 3") || j == (playerNames[0]+"_close 3")) {
                        if (openLobbies[2]) {
                        openLobbies[2] = false;
                            playersinlobby[2] = 0;
                    writer.WriteLine("Closed lobby 3");
                        Console.WriteLine(playerNames[0] + " Closed lobby 3");
                        } else {
                         writer.WriteLine("Tried to close lobby 3 but it was already closed.");
                        Console.WriteLine(playerNames[0] + " Tried to close lobby 3 but it was already closed");
                         }
                } else if (j == (playerNames[1]+"_Close 3") || j == (playerNames[1]+"_close 3")) {
                        if (openLobbies[2]) {
                        openLobbies[2] = false;
                            playersinlobby[2] = 0;
                    writer.WriteLine("Closed lobby 3");
                        Console.WriteLine(playerNames[1] + " Closed lobby 3");
                        } else {
                         writer.WriteLine("Tried to close lobby 3 but it was already closed.");
                        Console.WriteLine(playerNames[1] + " Tried to close lobby 3 but it was already closed");
                         }
                } else if (j == (playerNames[2]+"_Close 3") || j == (playerNames[2]+"_close 3")) {
                        if (openLobbies[2]) {
                        openLobbies[2] = false;
                            playersinlobby[2] = 0;
                    writer.WriteLine("Closed lobby 3");
                        Console.WriteLine(playerNames[2] + " Closed lobby 3");
                        } else {
                         writer.WriteLine("Tried to close lobby 3 but it was already closed.");
                        Console.WriteLine(playerNames[2] + " Tried to close lobby 3 but it was already closed");
                        }

                } else if (j == (playerNames[0]+"_join 1") || j == (playerNames[0]+"_Join 1")) {
                        if (openLobbies[0] && !playerinlobby[0]) {
                        playersinlobby[0]++;
                        playerinlobby[0] = true;
                        tempLobby[0] = 1;
                        writer.WriteLine("Joined lobby 1 (" + playersinlobby[0] + ")");
                            Console.WriteLine(playerNames[0] + " Joined lobby 1 (" + playersinlobby[0] + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 1 is currently closed or you are already in a lobby.");
                            Console.WriteLine(playerNames[0] + " Tried to join lobby 1 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (playerNames[1]+"_join 1") || j == (playerNames[1]+"_Join 1")) {
                        if (openLobbies[0] && !playerinlobby[1]) {
                        playersinlobby[0]++;
                        playerinlobby[1] = true;
                        tempLobby[1] = 1;
                 writer.WriteLine("Joined lobby 1 (" + playersinlobby[0] + ")");
                            Console.WriteLine(playerNames[1] + " Joined lobby 1 (" + playersinlobby[0] + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 1 is currently closed or you are already in a lobby.");
                            Console.WriteLine(playerNames[1] + " Tried to join lobby 1 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (playerNames[2]+"_join 1") || j == (playerNames[2]+"_Join 1")) {
                        if (openLobbies[0] && !playerinlobby[2]) {
                        playersinlobby[0]++;
                        playerinlobby[2] = true;
                        tempLobby[2] = 1;
                 writer.WriteLine("Joined lobby 1 (" + playersinlobby[0] + ")");
                            Console.WriteLine(playerNames[0] + " Joined lobby 1 (" + playersinlobby[0] + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 1 is currently closed or you are already in a lobby.");
                            Console.WriteLine(playerNames[0] + " Tried to join lobby 1 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (playerNames[0]+"_join 2") || j == (playerNames[0]+"_Join 2")) {
                        if (openLobbies[1] && !playerinlobby[0]) {
                        playersinlobby[1]++;
                        playerinlobby[0] = true;
                        tempLobby[0] = 2;
                 writer.WriteLine("Joined lobby 2 (" + playersinlobby[1] + ")");
                            Console.WriteLine(playerNames[0] + " Joined lobby 2 (" + playersinlobby[1] + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 2 is currently closed or you are already in a lobby.");
                            Console.WriteLine(playerNames[0] + " Tried to join lobby 2 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (playerNames[1]+"_join 2") || j == (playerNames[1]+"_Join 2")) {
                        if (openLobbies[1] && !playerinlobby[1]) {
                        playersinlobby[1]++;
                        playerinlobby[1] = true;
                        tempLobby[1] = 2;
                 writer.WriteLine("Joined lobby 2 (" + playersinlobby[1] + ")");
                            Console.WriteLine(playerNames[1] + " Joined lobby 2 (" + playersinlobby[1] + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 2 is currently closed or you are already in a lobby.");
                            Console.WriteLine(playerNames[1] + " Tried to join lobby 2 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (playerNames[2]+"_join 2") || j == (playerNames[2]+"_Join 2")) {
                        if (openLobbies[1] && !playerinlobby[2]) {
                        playersinlobby[1]++;
                        playerinlobby[2] = true;
                        tempLobby[2] = 2;
                 writer.WriteLine("Joined lobby 2 (" + playersinlobby[1] + ")");
                            Console.WriteLine(playerNames[0] + " Joined lobby 2 (" + playersinlobby[1] + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 2 is currently closed or you are already in a lobby.");
                            Console.WriteLine(playerNames[0] + " Tried to join lobby 2 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (playerNames[0]+"_join 3") || j == (playerNames[0]+"_Join 3")) {
                        if (openLobbies[2] && !playerinlobby[0]) {
                        playersinlobby[2]++;
                        playerinlobby[0] = true;
                        tempLobby[0] = 3;
                 writer.WriteLine("Joined lobby 3 (" + playersinlobby[2] + ")");
                            Console.WriteLine(playerNames[0] + " Joined lobby 3 (" + playersinlobby[2] + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 3 is currently closed or you are already in a lobby.");
                            Console.WriteLine(playerNames[0] + " Tried to join lobby 3 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (playerNames[1]+"_join 3") || j == (playerNames[1]+"_Join 3")) {
                        if (openLobbies[2] && !playerinlobby[1]) {
                        playersinlobby[2]++;
                        playerinlobby[1] = true;
                        tempLobby[1] = 3;
                 writer.WriteLine("Joined lobby 3 (" + playersinlobby[2] + ")");
                            Console.WriteLine(playerNames[1] + " Joined lobby 3 (" + playersinlobby[2] + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 3 is currently closed or you are already in a lobby.");
                            Console.WriteLine(playerNames[1] + " Tried to join lobby 3 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (playerNames[2]+"_join 3") || j == (playerNames[2]+"_Join 3")) {
                        if (openLobbies[2] && !playerinlobby[2]) {
                        playersinlobby[2]++;
                        playerinlobby[2] = true;
                        tempLobby[2] = 3;
                 writer.WriteLine("Joined lobby 3 (" + playersinlobby[2] + ")");
                            Console.WriteLine(playerNames[0] + " Joined lobby 3 (" + playersinlobby[2] + ")");
                        } else {
                 writer.WriteLine("Sorry! Lobby 3 is currently closed or you are already in a lobby.");
                            Console.WriteLine(playerNames[0] + " Tried to join lobby 3 but it was closed or he is already in a lobby.");
                 }
                } else if (j == (playerNames[0]+"_leave")) {
                        if (playerinlobby[0]) {
                    writer.WriteLine("Left lobby");
                            if (tempLobby[0] == 1) {
                            playersinlobby[0]--;
                            playerinlobby[0] = false;
                                }
                            if (tempLobby[0] == 2) {
                            playersinlobby[1]--;
                            playerinlobby[0] = false;
                                }
                            if (tempLobby[0] == 3) {
                            playersinlobby[2]--;
                            playerinlobby[0] = false;
                                }
                            Console.WriteLine(playerNames[0] + " Left lobby " + tempLobby[0]);
                    } else {
                    writer.WriteLine("Sorry. You are not in a lobby, so you can't leave it.");
                            Console.WriteLine(playerNames[0] + " Tried to leave lobby but was not in a lobby.");
                    }
                    } else if (j == (playerNames[1]+"_leave")) {
                        if (playerinlobby[1]) {
                    writer.WriteLine("Left lobby");
                            if (tempLobby[1] == 1) {
                            playersinlobby[0]--;
                            playerinlobby[1] = false;
                                }
                            if (tempLobby[1] == 2) {
                            playersinlobby[1]--;
                            playerinlobby[1] = false;
                                }
                            if (tempLobby[1] == 3) {
                            playersinlobby[2]--;
                            playerinlobby[1] = false;
                                }
                            Console.WriteLine(playerNames[1] + " Left lobby " + tempLobby[1]);
                    } else {
                    writer.WriteLine("Sorry. You are not in a lobby, so you can't leave it.");
                            Console.WriteLine(playerNames[1] + " Tried to leave lobby but was not in a lobby.");
                    }
                    } else if (j == (playerNames[2]+"_leave")) {
                        if (playerinlobby[2]) {
                    writer.WriteLine("Left lobby");
                            if (tempLobby[2] == 1) {
                            playersinlobby[0]--;
                            playerinlobby[2] = false;
                                }
                            if (tempLobby[2] == 2) {
                            playersinlobby[1]--;
                            playerinlobby[2] = false;
                                }
                            if (tempLobby[2] == 3) {
                            playersinlobby[2]--;
                            playerinlobby[2] = false;
                                }
                            Console.WriteLine(playerNames[2] + " Left lobby " + tempLobby[2]);
                    } else {
                    writer.WriteLine("Sorry. You are not in a lobby, so you can't leave it.");
                            Console.WriteLine(playerNames[2] + " Tried to leave lobby but was not in a lobby.");
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
                        writer.WriteLine(" Highest number wins! " + playerNames[0] + " rolled " + x + ". " + playerNames[1] + " rolled " + y + ". " + playerNames[2] + " rolled " + z + ". " + playerNames[0] + " Wins!! GAME OVER! RESTART SERVER AND CLIENTS TO PLAY AGAIN");
                            }
                        else if (x > y && x > z) {
                        writer.WriteLine(" Highest number wins! " + playerNames[0] + " rolled " + x + ". " + playerNames[1] + " rolled " + y + ". " + playerNames[2] + " rolled " + z + ". " + playerNames[0] + " Wins!! GAME OVER! RESTART SERVER AND CLIENTS TO PLAY AGAIN");
                            }
                        else if (x > y && x > z) {
                        writer.WriteLine(" Highest number wins! " + playerNames[0] + " rolled " + x + ". " + playerNames[1] + " rolled " + y + ". " + playerNames[2] + " rolled " + z + ". " + playerNames[0] + " Wins!! GAME OVER! RESTART SERVER AND CLIENTS TO PLAY AGAIN");
                            }
                    } else {
                    writer.WriteLine(""); //Opdater folket
                    }
                }

                if (playersinlobby[0] == 3) {
                    Console.WriteLine("3 Players connected to lobby 1! Ready to start game!");
                    writer.Write("3 Players connected to lobby 1! Ready to start game!");
                }
                
                if (playersinlobby[1] == 3) {
                    Console.WriteLine("3 Players connected to lobby 2! Ready to start game!");
                    writer.Write("3 Players connected to lobby 2! Ready to start game!");
                }
                
                if (playersinlobby[2] == 3) {
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