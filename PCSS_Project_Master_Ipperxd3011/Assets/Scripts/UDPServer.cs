using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPServer : MonoBehaviour
{
    private bool shutdown = false;

    public GameObject[] fishPrefabArray = new GameObject[4];
    public GameObject fishPrefab;
    public int cnr;
    public Text displayTimer;
    public bool start = false;
    bool goal = false;
    bool serverCreated = false;
    public float timeLeft = 60f;
    public bool isRacing = false;
    public int positionCount = 0;
    public int roundCount = 0;
    bool spawnFish1 = false;
    bool spawnFish2 = false;

    public Vector3 spawnPosition;
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
        
        if (clientList.Count == 1 && spawnFish1 == false)
        {
            fishPrefabArray[0].GetComponent<Controller>().controllerID = 0;
            clientList[0].fishPrefab = (GameObject)Instantiate(fishPrefab, spawnPosition, Quaternion.identity);
            spawnFish1 = true;
        } 
        else if (clientList.Count == 2 && spawnFish2 == false)
        {
            fishPrefabArray[1].GetComponent<Controller>().controllerID = 1;
            clientList[1].fishPrefab = (GameObject)Instantiate(fishPrefab, spawnPosition, Quaternion.identity);
            spawnFish2 = true;
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
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        init();
        serverCreated = true;
        

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
            new ThreadStart(() => ReceiveData(port, IP)));
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
                

                byte[] data = client.Receive(ref anyIP);

                
                string text = Encoding.UTF8.GetString(data);


                string[] textContent = text.Split(',');


                //If the client list is 0, add, the first client

                if (clientList.Count == 0)
                {
                    AddClient(textContent[1], textContent[3]);
                    
                    fishPrefabArray[0] = fishPrefab;
                    clientList[0].fishPrefab = fishPrefabArray[0];
                    
                    print("Added client with IP:" + textContent[1]);
                    Debug.Log("Initial IP:" + textContent[1] + " Initial Name:" + textContent[3] + " Initial Res H:" + textContent[5] + " Initial Res V:" + textContent[7]);
                }

                if (clientList[0].IP == textContent[1])
                {

                    clientList[0].SetHV(float.Parse(textContent[5]), float.Parse(textContent[7]));
                    SendCameraBack(clientList[0].x.ToString(), clientList[0].z.ToString(), clientList[0].yRotate.ToString());
                    Debug.Log(clientList[0].x + "," + clientList[0].z + "," + clientList[0].yRotate);
                    Debug.Log("Recieved IP:" + textContent[1] + " Recieved Name:" + textContent[3] + " Res H:" + textContent[5] + " Res V:" + textContent[5]);

                }

                //If the client list is 1, add, the second client
                if (clientList.Count == 1 && clientList[0].IP != textContent[1])
                {
                    AddClient(textContent[1], textContent[3]);

                    fishPrefabArray[1] = fishPrefab;
                    clientList[0].fishPrefab = fishPrefabArray[1];

                    print("Added client with IP:" + textContent[1]);
                    Debug.Log("Initial IP:" + textContent[1] + " Initial Name:" + textContent[3] + " Initial Res H:" + textContent[5] + " Initial Res V:" + textContent[7]);
                }

                if (clientList[1].IP == textContent[1])
                {

                    clientList[1].SetHV(float.Parse(textContent[5]), float.Parse(textContent[7]));
                    SendCameraBack(clientList[1].x.ToString(),clientList[1].z.ToString(), clientList[1].yRotate.ToString());
                    print(clientList[1].x+ "Thread");
                    Debug.Log("Recieved IP:" + textContent[1] + " Recieved Name:" + textContent[3] + " Res H:" + textContent[5] + " Res V:" + textContent[5]);
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
        print("Added client from addClient method");
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
        if (serverCreated == true)
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


    }
    
        private void SendCameraBack(string x, string z, string yRotate)
    {
        IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Parse(clientList[1].IP), port);
        try
        {
            //if (message != "")
            //{


            byte[] data = Encoding.UTF8.GetBytes(x + z + yRotate);


            client.Send(data, data.Length, RemoteIpEndPoint);
            //}
        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }


}