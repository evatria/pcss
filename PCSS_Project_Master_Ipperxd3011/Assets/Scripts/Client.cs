using UnityEngine;
using System.Collections;
[System.Serializable]
public class Client 
{

    public GameObject fishPrefab;
    //The clients IP
    public string IP;
    //The clients username
    public string clientName;

    //the clients horizontal position
    public float h;
    //the clients vertical position
    public float v;

    public float x;
    public float z;
    public float yRotate; 

    public Client(string newIP, string newClientName)
    {
        this.IP = newIP;
        this.clientName = newClientName;
        
    } 


    public void SetHV(float _h, float _v)
    {

        this.h = _h;
        this.v = _v;
        if (fishPrefab != null)

            Debug.Log(_h + "," + _v + "," + "Client");
    }

    public void SetCordinates() {
        this.x = fishPrefab.gameObject.transform.position.x;
        this.z = fishPrefab.gameObject.transform.position.z;
        this.yRotate = fishPrefab.gameObject.transform.rotation.y;
        Debug.Log(x + "Client");
    }

}