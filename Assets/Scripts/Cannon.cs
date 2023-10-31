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

    void Start()
    {
        player = GameObject.Find("Player");
        if (player == null)
        {
            Debug.Log("Cannon: Player not found");
        }
        playerScript = player.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
    }

    // Spawns cannonball at tip of cannon and calls their launch function
    public void Fire()
    {
        CannonBall newBall = Instantiate(ball, transform);
        newBall.transform.localPosition = new Vector3(0, 1.5f, 0);
        newBall.Launch();
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
        if (!canMove)
        {
            Fire();
        }
    }

    // Call this function inside of interact script
    public void MoveCannon()
    {
        HandleMove();
    }

    private void HandleMove()
    {
        if (!canMove)
        {
            //StartMove();
            canMove = true;
        } else
        {
            //EndMove();
            canMove = false;
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
