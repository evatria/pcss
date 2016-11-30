using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;


public class Controller : MonoBehaviour
{
    public int controllerID;


    public GameObject fishPrefab;
    public Controller fishController;
    bool checkForRunOnce = false;
    public bool isCreated = false;


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

                        Vector3 move = transform.forward * movementSpeed * udpServer.clientList[controllerID].v;
                        Vector3 rotation = new Vector3(0, udpServer.clientList[controllerID].h * 5, 0);
                        transform.Rotate(rotation);
                        rb.velocity = move + new Vector3(0, rb.velocity.y, 0);

                    }
             
        }
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

