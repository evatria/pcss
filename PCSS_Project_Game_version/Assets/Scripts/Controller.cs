using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;


public class Controller : MonoBehaviour
{
	
	private Rigidbody rb;

	public float movementSpeed = 10f;
	public Animation anim;
	public Text displayTimer;

	bool goal = false;
	bool isHit = false;
	public bool isRacing = false;
	bool start = false;
	bool powerIsReady = true;

	float timeLeft = 6f;

	public int roundCount = 1;
	public int positionCount = 0;


	// Use this for initialization
	void Start ()
	{

		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animation> ();

	}

	// Update is called once per frame
	void Update ()
	{
		if (start == false) {
			countdown ();
		}

		if (isRacing == true) {
			
		
			if (isHit == false) {
			
		
				float h = Input.GetAxis ("Horizontal");
				float v = Input.GetAxis ("Vertical");
				Vector3 move = transform.forward * movementSpeed * v;
				Vector3 rotation = new Vector3 (0, h * 5, 0);
				transform.Rotate (rotation);
				rb.velocity = move + new Vector3 (0, rb.velocity.y, 0);
			}
		}
	}


	void OnTriggerEnter (Collider col) {

		if (col.CompareTag("fishHook")) {
			StartCoroutine (hitObstacle ());

		}

		if (col.CompareTag("Goal") && goal == true) {
			
			roundCount++;
			print (roundCount);
			goal = false;
		}

		if (col.CompareTag("Checkpoint")) {
			
			goal = true;
			print ("checkpoint");
		}

		if (col.CompareTag("PositionRank")) {

			positionCount++;
			print (positionCount);
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


	void countdown(){
		timeLeft -= Time.deltaTime;

			displayTimer.GetComponent<Text> ().text = "" + (int)timeLeft;

			if (timeLeft <= 0) {
				isRacing = true;
				start = true;
				displayTimer.GetComponent<Text> ().enabled = false;
			}


	}


}