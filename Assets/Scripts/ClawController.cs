using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawController : MonoBehaviour
{

    #region Variables
    private Rigidbody rb;
    
    [SerializeField]
    private float moveSpeed = 1f;

    private float moveX;
    private float moveY;

    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Recieve input 
    void FixedUpdate()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        Move();
    }

    /* Handle moving */
    private void Move()
    {
        Vector3 moveDirection;
        if (Mathf.Abs(moveX) > Mathf.Abs(moveY)) { //constrain to one axis at a time
            moveDirection= new Vector3(moveX * moveSpeed * Time.deltaTime, 0, 0);;
        } else
        {
            moveDirection = new Vector3(0, moveY * moveSpeed * Time.deltaTime, 0);
        }
        transform.Translate( moveDirection * moveSpeed);

    }
}
