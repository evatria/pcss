using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {

	public int rotationSpeed = 5;
	public float pivotSize = 0.75f;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * rotationSpeed, Space.World);
	}


	void OnDrawGizmos() {

		Gizmos.DrawWireSphere (transform.position, pivotSize);

	}
}
