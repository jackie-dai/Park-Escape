using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement Variables
    public float moveSpeed = 4f;
    float inputX;
    float inputY;

    // Attached componenets
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        Move();
    }

    //  Handle movement input
    private void Move()
    {
        if (inputX < 0)
        {
            rb.velocity = moveSpeed * Vector2.left;
        } else if (inputX > 0)
        {
            rb.velocity = moveSpeed * Vector2.right;
        } else if (inputY < 0)
        {
            rb.velocity = moveSpeed * Vector2.down;

        } else if (inputY > 0)
        {
            rb.velocity = moveSpeed * Vector2.up;
        } else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
