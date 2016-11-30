using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinningState : MonoBehaviour {

	UDPServer udpServer;
	saveName _saveName;
	public Text winnerName;
	public Text winnerIs;




	// Use this for initialization
	void Start () {
		//GameObject gameControllerScript = GameObject.FindGameObjectWithTag ("FishCharacter");
       
		udpServer = GetComponent<UDPServer>();

	//	GameObject saveNameScript = GameObject.FindGameObjectWithTag ("SavedName");
	//	_saveName = saveNameScript.GetComponent<saveName>();


	}
	
	// Update is called once per frame
	void Update () {
		Winner ();
	}


	void Winner() {

		if (udpServer.roundCount == 2) {
			winnerIs.GetComponent<Text> ().enabled = true;
			winnerName.GetComponent<Text> ().enabled = true;
			winnerName.GetComponent<Text> ().text = "" + _saveName.savePlayerName;

            udpServer.isRacing = false; 
		}
	}

	public void PlayAgain(){
		Application.LoadLevel("PCSS");
	}

	public void GoToMenu(){
		Application.LoadLevel("menuFish");
	}


}
