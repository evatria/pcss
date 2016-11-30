using UnityEngine;
using System.Collections;

public class ManagerScript : MonoBehaviour {
    public GameObject manager;
    void Awake()
    {
        DontDestroyOnLoad(manager);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
