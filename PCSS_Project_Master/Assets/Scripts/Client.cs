using UnityEngine;
using System.Collections;
[System.Serializable]
public class Client
{

    public string IP;
    public string clientName;


    public float h;
    public float v;


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
