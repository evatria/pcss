using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;


public class Controller : MonoBehaviour
{
    public GameObject manager; 
    UDPServer udpServer;
    private Rigidbody rb;
    public string tempIP; 
	public float movementSpeed = 10f;
	public Animation anim;
	bool isHit = false;
	bool powerIsReady = true;
    


    // Use this for initialization
    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        udpServer = manager.GetComponent<UDPServer>();
        
    }
    void Start ()
	{
       
		rb = GetComponent<Rigidbody> ();
        
        anim = GetComponent<Animation> ();

	}

	// Update is called once per frame
	void Update ()
	{
        if (isHit == false)
        {
            Debug.Log("It get here 1");
            foreach (Client c in udpServer.clientList)
            {
                Debug.Log("It get here 2");
                if (tempIP == c.IP)
                {
                    Debug.Log("temp ip: " + tempIP  + "client ip: " + c.IP);
                    Debug.Log("It get here 3");
                    Vector3 move = transform.forward * movementSpeed * c.v;
                    Vector3 rotation = new Vector3(0, c.h * 5, 0);
                    transform.Rotate(rotation);
                    rb.velocity = move + new Vector3(0, rb.velocity.y, 0);
                }

            }
        }
	}

	void OnTriggerEnter (Collider col) {

		if (col.CompareTag("fishHook")) {
			StartCoroutine (hitObstacle ());

		}


		if (col.CompareTag("PowerUps")) {

			if (powerIsReady == true) {
				StartCoroutine (speedPowerUp ());
				print ("hit powerUp");
			}
		}

	}



	public IEnumerator hitObstacle () {
		movementSpeed = 1;
		transform.Rotate (0, 0, 90);

		isHit = true;

		yield return new WaitForSeconds(3f);
		movementSpeed = 5;
		transform.Rotate (0, 0, -90);
		isHit = false;
	}

	//-------------------------------------------- increasing speed when hit
	public IEnumerator speedPowerUp () {
		movementSpeed = 10;
		powerIsReady = false;

		yield return new WaitForSeconds(3f);
		movementSpeed = 5;
		print ("still not ready");

		yield return new WaitForSeconds(2f);
		powerIsReady = true;
		print ("ready again");
	}

}