using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPServer : MonoBehaviour
{
    public GameObject[] fishPrefabArray;
    public GameObject fishPrefab;
    public int cnr;
    public Text displayTimer;
    public bool start = false;
    bool goal = false;
    public float timeLeft = 60f;
    public bool isRacing = false;
    public int positionCount = 0;
    public int roundCount = 0;

    public Vector3 spawnPosition;
    //public GameObject[] fishPrefabArray;
    //public GameObject fishPrefab;
    //List
    public List<Client> clientList = new List<Client>();
    public List<int> fishToSpawn = new List<int>();
    // receiving Thread
    Thread receiveThread;

    // udpclient object
    UdpClient client;

    // public

    public string IP; // local
    public int port; // define > init
    

    // infos
    public string lastReceivedUDPPacket = "";
    public string allReceivedUDPPackets = ""; // clean up this from time to time!

    void Update()
    {

        if (fishToSpawn.Count > 0) {
            for (int i = 0; i < fishToSpawn.Count; i++)
            {
                InitFish(fishToSpawn[i]);
                
            }
            fishToSpawn = new List<int>();
        }
        
        
        if (start == false)
        {
            countdown();
        }
    }

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
            new ThreadStart(() => ReceiveData(port,IP)));
        receiveThread.IsBackground = true;
        receiveThread.Start();

    }

    // receive thread
    private void ReceiveData(int _port, string _ip)
    {

    client = new UdpClient(port);



        while (true)
        {

            try
            {

                IPEndPoint anyIP = new IPEndPoint(IPAddress.Parse(IP), port);
                Debug.Log(anyIP);
                 
                byte[] data = client.Receive(ref anyIP);



                string text = Encoding.UTF8.GetString(data);


                string[] textContent = text.Split(',');

                //If the client list is 0, add, the first client
                
                if (clientList.Count == 0)
                {
                    /*
                    print(">> " + text);

                    // latest UDPpacket
                    lastReceivedUDPPacket = text;

                    // ....
                    allReceivedUDPPackets = allReceivedUDPPackets + text; */

                    AddClient(textContent[1], textContent[3]);
                    

                    if (clientList.Count == 1){
                        
                       
                        fishToSpawn.Add(0);
                        print("new client");
                        while (true)
                        {
                            
                            clientList[0].SetHV(float.Parse(textContent[5]), float.Parse(textContent[7]));
                        }
                    }
                }
                else if(clientList.Count == 2)
                {
                    AddClient(textContent[1], textContent[3]);

                    if (clientList.Count == 2)
                    {
                        fishToSpawn.Add(1);
                        

                        while (true)
                        {
                            clientList[1].SetHV(float.Parse(textContent[5]), float.Parse(textContent[7]));
                        }
                    }
                    
                }
                else if (clientList.Count == 2)
                {
                    AddClient(textContent[1], textContent[3]);

                    if (clientList.Count == 3)
                    {
                        fishToSpawn.Add(2);
                        

                        while (true)
                        {
                            clientList[2].SetHV(float.Parse(textContent[5]), float.Parse(textContent[7]));
                        }
                    }

                }
                else if (clientList.Count == 3)
                {
                    AddClient(textContent[1], textContent[3]);

                    if (clientList.Count == 4)
                    {
                        fishToSpawn.Add(3);
                        

                        while (true)
                        {
                            clientList[3].SetHV(float.Parse(textContent[5]), float.Parse(textContent[7]));
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
        clientList.Add(new cl);
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.CompareTag("Checkpoint"))
        {

            goal = true;
            print("checkpoint");
        }

        if (col.CompareTag("PositionRank"))
        {

            positionCount++;
            print(positionCount);
        }
        if (col.CompareTag("Goal") && goal == true)
        {

            roundCount++;
            print(roundCount);
            goal = false;
        }
    }
    public void countdown()
    {
        timeLeft -= Time.deltaTime;

        displayTimer.GetComponent<Text>().text = "" + (int)timeLeft;

        if (timeLeft <= 0)
        {
            isRacing = true;
            start = true;
            displayTimer.GetComponent<Text>().enabled = false;
        }


    }

    public void InitFish(int clientIndex)
    {
        //fishPrefabArray[cnr] = fishPrefab;
        print("Runs");
        
        clientList[clientIndex].fishPrefab = (GameObject)Instantiate(fishPrefab, spawnPosition, Quaternion.identity); // This causes the program to crash      
    }


}