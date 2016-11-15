using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public Text displayTimer;
    public bool start = false;
    bool goal = false;
    float timeLeft = 6f;
    public bool isRacing = false;
    public int positionCount = 0;
    public int roundCount = 1;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

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
}
