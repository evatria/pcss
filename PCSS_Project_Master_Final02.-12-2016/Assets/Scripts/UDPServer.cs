using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPServer : MonoBehaviour
{
    

    public GameObject[] fishPrefabArray = new GameObject[4];
    public GameObject fishPrefab;
    public Button menuButton;
    public Text menuButtonText; 
    public Text displayTimer;
    public Text LogIn1;
    public Text LogIn2;
    public Text LogIn3;
    public Text LogIn4;


    public bool start = false;
   
    
    bool serverCreated = false;
    public float timeLeft = 60f;
    public bool isRacing = false;
    
    bool spawnFish1 = false;
    bool spawnFish2 = false;
    bool spawnFish3 = false;
    bool spawnFish4 = false;
    bool makeDisplayVanish = false;
    bool gameDone = false;

    public Text winnerName;
    public Text winnerIs;

    public string savePlayerName = "Empty";
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
    void Start()
    {
        
    }
    void Update()
    {
       
        if (clientList.Count == 1 && spawnFish1 == false)
        {

            LogIn1 = GameObject.Find("LogIn1").GetComponent<Text>();
            LogIn1.text = clientList[0].clientName + " Has logged in"; ;

            fishPrefabArray[0].GetComponent<Controller>().controllerID = 0;
            clientList[0].fishPrefab = (GameObject)Instantiate(fishPrefab, spawnPosition, Quaternion.identity);
            spawnFish1 = true;
           
        } 
        else if (clientList.Count == 2 && spawnFish2 == false)
        {
            LogIn2 = GameObject.Find("LogIn2").GetComponent<Text>();
            LogIn2.text = clientList[1].clientName + " Has logged in"; ;
            fishPrefabArray[1].GetComponent<Controller>().controllerID = 1;
            clientList[1].fishPrefab = (GameObject)Instantiate(fishPrefab, spawnPosition, Quaternion.identity);
            spawnFish2 = true;
        }
        if (clientList.Count == 3 && spawnFish3 == false)
        {
            LogIn3 = GameObject.Find("LogIn3").GetComponent<Text>();
            LogIn3.text = clientList[2].clientName + " Has logged in"; ;
            fishPrefabArray[2].GetComponent<Controller>().controllerID = 2;
            clientList[2].fishPrefab = (GameObject)Instantiate(fishPrefab, spawnPosition, Quaternion.identity);
            spawnFish1 = true;
        }
        else if (clientList.Count == 4 && spawnFish4 == false)
        {
            LogIn4 = GameObject.Find("LogIn4").GetComponent<Text>();
            LogIn4.text = clientList[3].clientName + " Has logged in";
            fishPrefabArray[3].GetComponent<Controller>().controllerID = 3;
            clientList[3].fishPrefab = (GameObject)Instantiate(fishPrefab, spawnPosition, Quaternion.identity);
            spawnFish2 = true;
        }

        if (serverCreated == true)
        {
            if (makeDisplayVanish == false)
            {
                DisplayTime();
                

                if (timeLeft <= 0)
                {
                    if(clientList.Count == 1)
                    LogIn1.GetComponent<Text>().enabled = false;
                    if (clientList.Count == 2)
                    {
                        LogIn1.GetComponent<Text>().enabled = false;
                        LogIn2.GetComponent<Text>().enabled = false;
                    }
                    if (clientList.Count == 3)
                    {
                        LogIn1.GetComponent<Text>().enabled = false;
                        LogIn2.GetComponent<Text>().enabled = false;
                        LogIn3.GetComponent<Text>().enabled = false;
                    }
                    if(clientList.Count == 4)
                    {
                        LogIn1.GetComponent<Text>().enabled = false;
                        LogIn2.GetComponent<Text>().enabled = false;
                        LogIn3.GetComponent<Text>().enabled = false;
                        LogIn4.GetComponent<Text>().enabled = false;
                    }
                    
                    displayTimer.GetComponent<Text>().enabled = false;
                    isRacing = true;
                    start = true;
                    makeDisplayVanish = true; 
                }
            }

        }

        Winner();
        if(gameDone == true)
        {

            StartCoroutine(goBackTOMenu());

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

    public void DisplayTime()
    {
        displayTimer = GameObject.Find("DisplayTimer").GetComponent<Text>();
        timeLeft -= Time.deltaTime;

        displayTimer.GetComponent<Text>().text = "" + (int)timeLeft;

    }
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
                    AddClient(GetLocalIPAddress(), textContent[3]);
                    
                    fishPrefabArray[0] = fishPrefab;
                    clientList[0].fishPrefab = fishPrefabArray[0];
                    
                    print("Added client with IP:" + IP);
                    Debug.Log("Initial IP:" + textContent[1] + " Initial Name:" + textContent[3] + " Initial Res H:" + textContent[5] + " Initial Res V:" + textContent[7]);
                }

                if (IP == textContent[1])
                {

                    clientList[0].SetHV(float.Parse(textContent[5]), float.Parse(textContent[7]));
                    
                    Debug.Log(clientList[0].x + "," + clientList[0].z + "," + clientList[0].yRotate);
                    Debug.Log("Recieved IP:" + textContent[1] + " Recieved Name:" + textContent[3] + " Res H:" + textContent[5] + " Res V:" + textContent[5]);

                }

                //If the client list is 1, add, the second client
                if (clientList.Count == 1 && clientList[0].IP != textContent[1])
                {
                    AddClient(textContent[1], textContent[3]);

                    fishPrefabArray[1] = fishPrefab;
                    clientList[1].fishPrefab = fishPrefabArray[1];

                    print("Added client with IP:" + textContent[1]);
                    Debug.Log("Initial IP:" + textContent[1] + " Initial Name:" + textContent[3] + " Initial Res H:" + textContent[5] + " Initial Res V:" + textContent[7]);
                }

                if (clientList[1].IP == textContent[1])
                {

                    clientList[1].SetHV(float.Parse(textContent[5]), float.Parse(textContent[7]));
                    
                    print(clientList[1].x+ "Thread");
                    Debug.Log("Recieved IP:" + textContent[1] + " Recieved Name:" + textContent[3] + " Res H:" + textContent[5] + " Res V:" + textContent[5]);
                }

                //If the client list is 2, add, the third client
                if (clientList.Count == 2 && clientList[0].IP != textContent[1] && clientList[1].IP != textContent[1])
                {
                    AddClient(textContent[1], textContent[3]);

                    fishPrefabArray[2] = fishPrefab;
                    clientList[2].fishPrefab = fishPrefabArray[2];

                    print("Added client with IP:" + textContent[1]);
                    Debug.Log("Initial IP:" + textContent[1] + " Initial Name:" + textContent[3] + " Initial Res H:" + textContent[5] + " Initial Res V:" + textContent[7]);
                }

                if (clientList[2].IP == textContent[1])
                {

                    clientList[2].SetHV(float.Parse(textContent[5]), float.Parse(textContent[7]));
                   
                    print(clientList[1].x + "Thread");
                    Debug.Log("Recieved IP:" + textContent[1] + " Recieved Name:" + textContent[3] + " Res H:" + textContent[5] + " Res V:" + textContent[5]);
                }
                //If the client list is 2, add, the third client
                if (clientList.Count == 3 && clientList[0].IP != textContent[1] && clientList[1].IP != textContent[1] && clientList[2].IP != textContent[2])
                {
                    AddClient(textContent[1], textContent[3]);

                    fishPrefabArray[3] = fishPrefab;
                    clientList[3].fishPrefab = fishPrefabArray[3];

                    print("Added client with IP:" + textContent[1]);
                    Debug.Log("Initial IP:" + textContent[1] + " Initial Name:" + textContent[3] + " Initial Res H:" + textContent[5] + " Initial Res V:" + textContent[7]);
                }

                if (clientList[3].IP == textContent[1])
                {

                    clientList[3].SetHV(float.Parse(textContent[5]), float.Parse(textContent[7]));

                    print(clientList[1].x + "Thread");
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
    

    void Winner()
    {

        if (clientList[0].fishPrefab.GetComponent<Controller>().roundCount == 2)
        {
            winnerIs = GameObject.Find("Winner Is").GetComponent<Text>();
            winnerName = GameObject.Find("Winner").GetComponent<Text>();           
            winnerIs.GetComponent<Text>().enabled = true;
            winnerName.GetComponent<Text>().enabled = true;
            winnerName.GetComponent<Text>().text = clientList[0].clientName;
            gameDone = true;
            print("Player 1 won");
            isRacing = false;
        }
        else if (clientList[1].fishPrefab.GetComponent<Controller>().roundCount == 2)
        {
            winnerIs = GameObject.Find("Winner Is").GetComponent<Text>();
            winnerName = GameObject.Find("Winner").GetComponent<Text>();
            winnerIs.GetComponent<Text>().enabled = true;
            winnerName.GetComponent<Text>().enabled = true;
            winnerName.GetComponent<Text>().text = clientList[1].clientName;
            print("Player 2 won");
            gameDone = true;
            isRacing = false;
        }
        else if (clientList[2].fishPrefab.GetComponent<Controller>().roundCount == 2)
        {
            winnerIs = GameObject.Find("Winner Is").GetComponent<Text>();
            winnerName = GameObject.Find("Winner").GetComponent<Text>();
            winnerIs.GetComponent<Text>().enabled = true;
            winnerName.GetComponent<Text>().enabled = true;
            winnerName.GetComponent<Text>().text = clientList[2].clientName;
            print("Player 3 won");
            gameDone = true;
            isRacing = false;
        }
        else if (clientList[3].fishPrefab.GetComponent<Controller>().roundCount == 2)
        {
            winnerIs = GameObject.Find("Winner Is").GetComponent<Text>();
            winnerName = GameObject.Find("Winner").GetComponent<Text>();
            winnerIs.GetComponent<Text>().enabled = true;
            winnerName.GetComponent<Text>().enabled = true;
            winnerName.GetComponent<Text>().text = clientList[3].clientName;
            print("Player 4 won");
            gameDone = true;
            isRacing = false;
        }
        else {
            print("No one has won yet");
        }
        menuButton = GameObject.Find("GoToMenuButton").GetComponent<Button>();
    }

    public void PlayAgain()
    {
        Application.LoadLevel("PCSS");
    }


    IEnumerator goBackTOMenu()
    {
        yield return new WaitForSeconds(5);
        Application.LoadLevel("menuFish");
    }

}