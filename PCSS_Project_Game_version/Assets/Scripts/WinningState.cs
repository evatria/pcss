using UnityEngine;
using System.Collections;

public class WinningState : MonoBehaviour {

	Controller controller;


	// Use this for initialization
	void Start () {
		GameObject controllerScript = GameObject.FindGameObjectWithTag ("FishCharacter");
		controller = controllerScript.GetComponent<Controller>();
	}
	
	// Update is called once per frame
	void Update () {
		Winner ();
	}


	void Winner() {

		if (controller.roundCount == 2) {
			print ("Winner is Fish!");
		}

	}


}
