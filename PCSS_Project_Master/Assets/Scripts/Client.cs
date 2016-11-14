using UnityEngine;
using System.Collections;
[System.Serializable]
public class Client
{
    //The clients IP
    public string IP;
    //The clients username
    public string clientName;

    //the clients horizontal position
    public float h;
    //the clients vertical position
    public float v;

    //A client constructer
    public Client(string newIP, string newClientName)
    {
        this.IP = newIP;
        this.clientName = newClientName;
    }


    public void SetHV(float _h, float _v)
    {
        this.h = _h;
        this.v = _v;
    }

}