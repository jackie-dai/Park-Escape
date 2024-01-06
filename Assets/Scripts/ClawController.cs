using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ClawController : MonoBehaviour
{

    #region Variables
    private Rigidbody rb;
    
    [SerializeField]
    private float moveSpeed = 1f;

    private float moveX;
    private float moveY;

    public GameObject groundLevel;
    private float startingY;
    private bool grappling;
    private bool dialogueFinished;

    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startingY = transform.position.y;
        grappling = false;
        dialogueFinished = false;
    }
    // Recieve input 
    void FixedUpdate()
    {
        if (dialogueFinished)
        {
            moveX = Input.GetAxisRaw("Horizontal");
            //moveY = Input.GetAxisRaw("Vertical");
            if (!grappling)
            {
                Move();
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //  Grapple
            Hook();
        }
    }

    void Hook()
    {
        StartCoroutine(translateDown());
    }

    IEnumerator translateDown()
    {
        grappling = true;
        while (transform.position.y > groundLevel.transform.position.y)
        {
            transform.Translate(Vector3.down * 2 * moveSpeed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        while (transform.position.y < startingY)
        {
            transform.Translate(Vector3.up * 2 * moveSpeed * Time.deltaTime);
            yield return null;
        }
        grappling = false;
    }
    /* Handle moving */
    private void Move()
    {
        Vector3 moveDirection = new Vector3(moveX * Time.deltaTime, 0, 0);
       /* if (Mathf.Abs(moveX) > Mathf.Abs(moveY)) { //constrain to one axis at a time
            moveDirection= new Vector3(moveX * moveSpeed * Time.deltaTime, 0, 0);;
        } else
        {
            moveDirection = new Vector3(0, moveY * moveSpeed * Time.deltaTime, 0);
        }*/
        transform.Translate(moveDirection * moveSpeed);
        if (transform.position.x < -2)
        {
            transform.position = new Vector3(-2, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 31)
        {
            transform.position = new Vector3(31, transform.position.y, transform.position.z);
        }
    }

    [YarnCommand("claw_dialogue")]

    public void turnOffDialogue()
    {
        dialogueFinished = true;
    }
}
