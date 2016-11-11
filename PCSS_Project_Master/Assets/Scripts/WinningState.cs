using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinningState : MonoBehaviour {

	Controller _controller;
	saveName _saveName;
	public Text winnerName;
	public Text winnerIs;



	// Use this for initialization
	void Start () {
		GameObject controllerScript = GameObject.FindGameObjectWithTag ("FishCharacter");
		_controller = controllerScript.GetComponent<Controller>();

		GameObject saveNameScript = GameObject.FindGameObjectWithTag ("SavedName");
		_saveName = saveNameScript.GetComponent<saveName>();
	}
	
	// Update is called once per frame
	void Update () {
		Winner ();
	}


	void Winner() {

		if (_controller.roundCount == 1) {
			winnerIs.GetComponent<Text> ().enabled = true;
			winnerName.GetComponent<Text> ().enabled = true;
			winnerName.GetComponent<Text> ().text = "" + _saveName.savePlayerName;
			_controller.isRacing = false;


		}

	}


}
