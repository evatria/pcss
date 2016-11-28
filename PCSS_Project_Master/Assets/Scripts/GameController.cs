using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    UDPServer udpServer;
    public GameObject[] fishPrefabArray;
    public GameObject fishPrefab;
    public int cnr;
    public Text displayTimer;
    public bool start = false;
    bool goal = false;
    float timeLeft = 6f;
    public bool isRacing = false;
    public int positionCount = 0;
    public int roundCount = 0;

    

    // Use this for initialization
    void Start () {
        udpServer = GetComponent<UDPServer>();
	
	}

    // Update is called once per frame
    void Update()
    {

        //    fishPrefabArray = new GameObject[udpServer.clientList.Count];
        foreach (Client c in udpServer.clientList)
        {
            if(!c.isCreated)
            InitFish();
            fishPrefab.GetComponentInChildren<Controller>().tempIP = c.IP; 
            c.isCreated = true;
        }

        if (start == false)
        {
            countdown();
        }
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

    public void InitFish()
    {
                //fishPrefabArray[cnr] = fishPrefab;
                Instantiate(fishPrefab, udpServer.spawnPosition, Quaternion.identity); // This causes the program to crash      
    }


    

}
