using UnityEngine;
using System.Collections;

public class testScript : MonoBehaviour {

	
	string msg = "Tried to edit a script directly on GitHub";
	
	// Use this for initialization
	void Start () {
		
		GitHubTest(msg, 5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void GitHubTest(string msg, int repeatCo)
	{
		for(int i = 0; int < repeatCo; i++)
			Debug.Log(msg);
		
	}
}
