using UnityEngine;
using System.Collections;

public class saveName : MonoBehaviour {

	menuScript _menu;
	public string savePlayerName = "Empty";


	// Use this for initialization
	void Start () {
		GameObject menuScript = GameObject.FindGameObjectWithTag ("Name");
		_menu = menuScript.GetComponent<menuScript>();
		DontDestroyOnLoad(this);

	}
	
	// Update is called once per frame
	void Update () {
		savePlayerName = _menu.charName;

	}


}
