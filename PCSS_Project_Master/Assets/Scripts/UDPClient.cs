﻿using UnityEngine;
using System.Collections;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPClient : MonoBehaviour
{

    UDPServer server;
    public string clientIP;
    private static int localPort;

    // prefs
    public static string serverIP;  // define in init
    public int port;  // define in init

    // "connection" things
    IPEndPoint remoteEndPoint;
    UdpClient client;

    // gui
    string serverNameIP = "Insert Server IP";
    string strMessage = "Insert Name";

    //movement related variables
    float _h;
    float v;
    private string h;


    // call it from shell (as program)
    private static void Main()
    {
        UDPClient sendObj = new UDPClient();
        sendObj.init();

        // testing via console
        // sendObj.inputFromConsole();

        // as server sending endless
        //sendObj.sendEndless(" endless infos \n");

    }
    // start from unity3d
    public void Start()
    {
        server = GetComponent<UDPServer>();
        init();
    }

    public void Update()
    {

        //w,a,s,d directions, value should be the ones to go into the fish controller

        h = Input.GetAxis("Horizontal").ToString();

        v = Input.GetAxis("Vertical");


        //in the end of update we send the movement information to the server

        sendButtonData("IP," + clientIP, "Name," + strMessage, "H," + h, "V," + v);


    }

    // OnGUI
    void OnGUI()
    {
        Rect rectObj = new Rect(40, 380, 200, 400);
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        GUI.Box(rectObj, "# UDPSend-Data\n" + serverIP + " : " + port + " #\n"
            + "shell> nc -lu " + serverIP + " : " + port + " \n"
            , style);

        // ------------------------
        // send it
        // ------------------------
        serverNameIP = GUI.TextField(new Rect(40, 450, 140, 20), serverNameIP);
        if (GUI.Button(new Rect(40, 480, 100, 20), "send server Ip"))
        {
            serverIP = serverNameIP;
            init();
        }
        strMessage = GUI.TextField(new Rect(40, 510, 140, 20), strMessage);
        if (GUI.Button(new Rect(40, 540, 40, 20), "send"))
        {
            sendIpAdress("IP," + clientIP, "Name," + strMessage);

            //server.AddClient(clientIP, strMessage);  
        }
    }

    // init
    public void init()
    {

        print("UDPSend.init()");

        // define
        clientIP = GetLocalIPAddress();
        //serverIP;
        port = 8051;

        // ----------------------------
        // Send
        // ----------------------------
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(serverIP), port);
        client = new UdpClient();

        // status
        print("Sending to " + serverIP + " : " + port);
        print("Testing: nc -lu " + serverIP + " : " + port);

    }
    //Finds the ip adresse for the client
    public static string GetLocalIPAddress()
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

    // inputFromConsole
    private void inputFromConsole()
    {
        try
        {
            string text;
            do
            {
                text = Console.ReadLine();

                // Den Text zum Remote-Client senden.
                if (text != "")
                {

                    // Daten mit der UTF8-Kodierung in das Binärformat kodieren.
                    byte[] data = Encoding.UTF8.GetBytes(text);

                    // Den Text zum Remote-Client senden.
                    client.Send(data, data.Length, remoteEndPoint);
                }
            } while (text != "");
        }
        catch (Exception err)
        {
            print(err.ToString());
        }

    }


    // sendData
    private void sendIpAdress(string clientIP, string name)
    {
        try
        {
            //if (message != "")
            //{

            // Daten mit der UTF8-Kodierung in das Binärformat kodieren.
            byte[] data = Encoding.UTF8.GetBytes(clientIP + ',' + name);

            // Den message zum Remote-Client senden.
            client.Send(data, data.Length, remoteEndPoint);
            //}
        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }

    // sendButtonData
    private void sendButtonData(string clientIP, string name, string _h, string _v)
    {
        try
        {
            //if (message != "")
            //{


            byte[] data = Encoding.UTF8.GetBytes(clientIP + ',' + name + ',' + _h + ',' + _v);


            client.Send(data, data.Length, remoteEndPoint);
            //}
        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }

    // endless test
    private void sendEndless(string clientIP, string name)
    {
        do
        {
            sendIpAdress(clientIP, name);


        }
        while (true);

    }

}