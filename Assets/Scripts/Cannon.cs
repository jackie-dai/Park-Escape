using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    CannonBall ball;

    GameObject player;
    PlayerController playerScript;

    private Rigidbody rb;

    private float inputX;

    bool canMove = false;

    private float timeUntilNextShot;
    private float cooldown;
    private MouseLook lookScript;

    void Start()
    {
        player = GameObject.Find("Player");
        if (player == null)
        {
            Debug.Log("Cannon: Player not found");
        }
        playerScript = player.GetComponent<PlayerController>();
        lookScript = GetComponent<MouseLook>();
        rb = GetComponent<Rigidbody>();
        timeUntilNextShot = 2f;
        cooldown = timeUntilNextShot;


        
    }

    // Spawns cannonball at tip of cannon and calls their launch function
    public void Fire()
    {
        CannonBall newBall = Instantiate(ball, transform);
        newBall.transform.localPosition = new Vector3(0, 1.5f, 0);
        Debug.Log("angle: " + transform.localRotation);
        newBall.Launch(transform.localRotation.eulerAngles);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cooldown < 0)
        {
            Fire();
            cooldown = timeUntilNextShot;
        }
        cooldown -= Time.deltaTime;

    }

    void FixedUpdate()
    {
        if (canMove)
        {
            inputX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector3(inputX * playerScript.moveSpeed, rb.velocity[1], rb.velocity[2]);
        }
    }

    public void Activate()
    {
        HandleMove();
    }

    // Call this function inside of interact script

    private void HandleMove()
    {
        if (!canMove)
        {
            //StartMove();
            //canMove = true;
            lookScript.enabled = true;
        } else
        {
            //EndMove();
            //canMove = false;
            lookScript.enabled = false;
        }
    }

    private void StartMove()
    {
        //transform.parent = player.transform;
        playerScript.CannonModeOn();
    }

    private void EndMove()
    {
        //transform.parent = null;
        playerScript.CannonModeOff();
    }
}
