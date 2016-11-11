using UnityEngine;
using System.Collections;
[System.Serializable]
public class Client  {

    public string IP;
    public string clientName;

    public Client(string newIP, string newClientName)
    {
        this.IP = newIP;
        this.clientName = newClientName;
    }
	
}
