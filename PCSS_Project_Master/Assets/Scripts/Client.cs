using UnityEngine;
using System.Collections;
[System.Serializable]
public class Client : MonoBehaviour 
{
    public Controller fishController;
    bool checkForRunOnce = false;
    public bool isCreated = false;
    public GameObject fishPrefab;
    //The clients IP
    public string IP;
    //The clients username
    public string clientName;

    //the clients horizontal position
    public float h;
    //the clients vertical position
    public float v;

    public GameObject manager;
    UDPServer udpServer;
    private Rigidbody rb;
    public string tempIP;

    public Animation anim;
    bool isHit = false;
    bool powerIsReady = true;
    public float movementSpeed = 10f;

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        udpServer = manager.GetComponent<UDPServer>();
    }

    //A client constructer
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
        if (fishPrefab != null && checkForRunOnce == false)
        {
            fishController = fishPrefab.GetComponent<Controller>();
            checkForRunOnce = true;
        }

    }

    void Update()
    {
        if (manager.GetComponent<UDPServer>().timeLeft <= 0)
        {
            if (isHit == false)
            {


                Vector3 move = transform.forward * movementSpeed * v;
                Vector3 rotation = new Vector3(0, h * 5, 0);
                transform.Rotate(rotation);
                rb.velocity = move + new Vector3(0, rb.velocity.y, 0);

            }
        }
    }

    /* problem area sort of
    public Client(string newIP, string newClientName)
    {
        this.IP = newIP;
        this.clientName = newClientName;
        
    } */


    public void SetHV(float _h, float _v)
    {
        
        this.h = _h;
        this.v = _v;
        if(fishPrefab != null)
    
        
        Debug.Log(_h + "," + _v + "," + "Client");
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.CompareTag("fishHook"))
        {
            StartCoroutine(hitObstacle());

        }


        if (col.CompareTag("PowerUps"))
        {

            if (powerIsReady == true)
            {
                StartCoroutine(speedPowerUp());
                print("hit powerUp");
            }
        }

    }



    public IEnumerator hitObstacle()
    {
        movementSpeed = 1;
        transform.Rotate(0, 0, 90);

        isHit = true;

        yield return new WaitForSeconds(3f);
        movementSpeed = 5;
        transform.Rotate(0, 0, -90);
        isHit = false;
    }

    //-------------------------------------------- increasing speed when hit
    public IEnumerator speedPowerUp()
    {
        movementSpeed = 10;
        powerIsReady = false;

        yield return new WaitForSeconds(3f);
        movementSpeed = 5;
        print("still not ready");

        yield return new WaitForSeconds(2f);
        powerIsReady = true;
        print("ready again");
    }
}