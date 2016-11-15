using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinningState : MonoBehaviour {

	GameController _gameController;
	saveName _saveName;
	public Text winnerName;
	public Text winnerIs;




	// Use this for initialization
	void Start () {
		GameObject gameControllerScript = GameObject.FindGameObjectWithTag ("FishCharacter");
		_gameController = gameControllerScript.GetComponent<GameController>();

		GameObject saveNameScript = GameObject.FindGameObjectWithTag ("SavedName");
		_saveName = saveNameScript.GetComponent<saveName>();


	}
	
	// Update is called once per frame
	void Update () {
		Winner ();
	}


	void Winner() {

		if (_gameController.roundCount == 2) {
			winnerIs.GetComponent<Text> ().enabled = true;
			winnerName.GetComponent<Text> ().enabled = true;
			winnerName.GetComponent<Text> ().text = "" + _saveName.savePlayerName;

            _gameController.isRacing = false;
		}
	}

	public void PlayAgain(){
		Application.LoadLevel("PCSS");
	}

	public void GoToMenu(){
		Application.LoadLevel("menuFish");
	}


}
