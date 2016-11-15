using UnityEngine;
using System.Collections.Generic;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPServer : MonoBehaviour
{
    public Vector3 spawnPosition;
    public GameObject[] fishPrefabArray;
    public GameObject fishPrefab;
    //List
    public List<Client> clientList = new List<Client>();
    // receiving Thread
    Thread receiveThread;

    // udpclient object
    UdpClient client;

    // public

    public string IP; // local
    public int port; // define > init
    public int cnr;

    // infos
    public string lastReceivedUDPPacket = "";
    public string allReceivedUDPPackets = ""; // clean up this from time to time!


    // start from shell
    private static void Main()
    {
        UDPServer receiveObj = new UDPServer();
        receiveObj.init();

        string text = "";
        do
        {
            text = Console.ReadLine();
        }
        while (!text.Equals("exit"));
    }
    // start from unity3d
    public void Start()
    {

        init();
    }

    public string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        throw new Exception("Local IP Address Not Found!");
    }


    // OnGUI
    void OnGUI()
    {
        Rect rectObj = new Rect(40, 10, 200, 400);
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        GUI.Box(rectObj, "# UDPReceive\n" + IP + " " + port + " #\n"
            + "shell> nc -u " + IP + " : " + port + " \n"
            + "\nLast Packet: \n" + lastReceivedUDPPacket
            + "\n\nAll Messages: \n" + allReceivedUDPPackets
            , style);
    }

    // init
    private void init()
    {
        // Endpunkt definieren, von dem die Nachrichten gesendet werden.
        print("UDPSend.init()");

        // define IP host
        IP = GetLocalIPAddress();

        // define port
        port = 8051;

        // status
        print("Sending to " + IP + " : " + port);
        print("Test-Sending to this Port: nc -u " + IP + " " + port + "");


        receiveThread = new Thread(
            new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();

    }

    // receive thread
    private void ReceiveData()
    {

        client = new UdpClient(port);

        while (true)
        {

            try
            {

                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref anyIP);



                string text = Encoding.UTF8.GetString(data);


                string[] textContent = text.Split(',');

                //If the client list is 0, add, the first client
                fishPrefabArray = new GameObject[clientList.Count];
                if (clientList.Count == 0)
                {
                    /*
                    print(">> " + text);

                    // latest UDPpacket
                    lastReceivedUDPPacket = text;

                    // ....
                    allReceivedUDPPackets = allReceivedUDPPackets + text; */

                    AddClient(textContent[1], textContent[3]);
                }
                else if(clientList.Count <= 1)
                {
                    //for each client in the client list
                    foreach (Client c in clientList)
                    {
                         
                        if (cnr < clientList.Count)
                            cnr++;
                        else
                            cnr = 0;

                        fishPrefabArray[cnr] = fishPrefab;
                        if (c.IP == textContent[1])
                        {
                            //Sets the H & V for the client, to be the input for
                            Instantiate(fishPrefabArray[cnr], spawnPosition, Quaternion.identity); // This causes the program to crash
                            c.SetHV(float.Parse(textContent[5]), float.Parse(textContent[7]));
                            //Prints the clients h and v
                            Debug.Log(c.h + "" + c.v);

                        }
                        else if(c.IP != textContent[1])
                        {

                            print(">> " + text);
                            /*
                            // latest UDPpacket
                            lastReceivedUDPPacket = text;

                            // ....
                            allReceivedUDPPackets = allReceivedUDPPackets + text; */

                            //The function for adding a client to a list 
                            AddClient(textContent[1], textContent[3]);  //I think here it's the problem with adding a client constantly
                        }
                    }
                }

            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

    // getLatestUDPPacket
    // cleans up the rest
    public string getLatestUDPPacket()
    {
        allReceivedUDPPackets = "";
        return lastReceivedUDPPacket;
    }


    void OnDisable()
    {
        if (receiveThread != null)
            receiveThread.Abort();

        client.Close();
    }

    //Adds clients to a list function
    public void AddClient(string ip, string name)
    {
        clientList.Add(new Client(ip, name));
    }
}