using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {

	public int moveSpeed = 10;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * moveSpeed, Space.World);
	}
}
