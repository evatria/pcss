using UnityEngine;
using System.Collections;

public class ManagerScript : MonoBehaviour {
    public GameObject manager;
    void Awake()
    {
        //So it does not destoy this object, when it loads
        DontDestroyOnLoad(manager);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
