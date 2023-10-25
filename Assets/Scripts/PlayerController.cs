using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region Variables
    #region Animation
    private Animator animator;
    #endregion

    // Components
    Rigidbody rb;
    SpriteRenderer sp;
    [SerializeField] GameObject interactCollider;

    // Move
    float inputX;
    float inputZ;
    float groundOffset = 1.5f;
    [SerializeField]
    float moveSpeed = 2;

    public LayerMask terrainLayer;
    #endregion


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        NullCheck(interactCollider);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ActivateInteract();
        }
        Move();
        HandleCollider();
    }

    private void FixedUpdate()
    {
        HandleGroundOffset();
    }


    // Uses raycast to calculate ground offset
    private void HandleGroundOffset()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position;
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if (hit.collider != null)
            {
                Debug.Log(hit.point.y);
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundOffset;
                transform.position = movePos;

            }
        }
    }

    // Handles character movement on x and z axis
    private void Move()
    {
        // update inputX and inputY and move character
        inputX = Input.GetAxisRaw("Horizontal");
        inputZ = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(inputX, rb.velocity[1], inputZ);
        rb.velocity = moveDirection * moveSpeed;
        sp.flipX = inputX > 0 ? false : true; // tenary operator for flipping sprite horizontally

        // updating arguments for move animations
        animator.SetFloat("inputX", inputX);
        animator.SetFloat("inputZ", inputZ);
    }

    private void ActivateInteract()
    {
        StartCoroutine(HoldCollider());
        StopCoroutine(HoldCollider());
    }

    private void NullCheck(GameObject obj)
    {
        if (obj == null)
        {
            Debug.Log(obj.name + " not found");
        }
    }

    IEnumerator HoldCollider()
    {
        interactCollider.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        interactCollider.SetActive(false);
    }

    // Change direction of collider according to direction player is facing
    void HandleCollider()
    {
        if (inputX > 0)
        {
            interactCollider.GetComponent<Interact>().SwitchToRight();
        }
        if (inputX < 0)
        {
            interactCollider.GetComponent<Interact>().SwitchToLeft();
        }
        if (inputZ > 0)
        {
            interactCollider.GetComponent<Interact>().SwitchToBack();
        }
        if (inputZ < 0)
        {
            interactCollider.GetComponent<Interact>().SwitchToForward();
        }
    }
}
