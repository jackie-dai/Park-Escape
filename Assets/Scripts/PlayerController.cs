using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    #region Variables
    #region Animation
    private Animator animator;
    [SerializeField]
    private Sprite frontSprite;
  
    #endregion

    // Components
    Rigidbody rb;
    SpriteRenderer sp;
    [SerializeField] GameObject interactCollider;

    RigidbodyConstraints originalConstraints;
    // Move
    float inputX;
    float inputZ;
    float groundOffset = 1.5f;
    [SerializeField]
    public float moveSpeed = 2;

    public LayerMask terrainLayer;

    private int coinCount;
    private bool inCannonMode;

    [SerializeField]
    private CinemachineVirtualCamera mainCamera;

    private int balloonCount = 0;
    #endregion


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        NullCheck(interactCollider);
        originalConstraints = rb.constraints;
        coinCount = 2;
        inCannonMode = false;
      
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

        if (balloonCount >= 12)
        {
            SceneManager.LoadScene("Main");
        }
    }

    private void FixedUpdate()
    {
        HandleGroundOffset();
    }


    // called when space is pressed
    // Detects if cannon is within raycast and fires cannonball if it is
    void DetectCannon() {
        RaycastHit[] hits = Physics.BoxCastAll(transform.position, Vector3.one * 2, Vector3.forward);
        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.CompareTag("Cannon"))
            {
                //Cannon cannon = hit.transform.GetComponent<Cannon>();
                //cannon.MoveCannon();
            }
        }
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
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundOffset;
                transform.position = movePos;

            }
        }
    }

    // Handles character movement on x and z axis
    private void Move()
    {
      

        // updating arguments for move animations
        if (!InCannonMode())
        { 
            // update inputX and inputY and move character
            inputX = Input.GetAxisRaw("Horizontal");
            inputZ = Input.GetAxisRaw("Vertical");

            Vector3 moveDirection = new Vector3(inputX, rb.velocity[1], inputZ);
            rb.velocity = moveDirection * moveSpeed;
            sp.flipX = inputX > 0 ? false : true; // tenary operator for flipping sprite horizontally
            animator.SetFloat("inputX", inputX);
            animator.SetFloat("inputZ", inputZ);
            animator.enabled = true;
        } else
        {
            animator.enabled = false;
            sp.sprite = frontSprite;
            inputX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector3(inputX * moveSpeed, rb.velocity[1], rb.velocity[2]);

        }
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

    public void CannonModeOn()
    {
        //rb.constraints = RigidbodyConstraints.FreezeAll;
        //mainCamera.gameObject.SetActive(false);
        //rb.constraints = RigidbodyConstraints.FreezePositionZ;
        inCannonMode = true;
    }

    public void CannonModeOff()
    {
        //rb.constraints = originalConstraints;
        //mainCamera.gameObject.SetActive(true);
        inCannonMode = false;
        Debug.Log("Cannon mode off");
    }

    public bool InCannonMode()
    {
        return inCannonMode;
    }

    public int ReturnCoinAmount()
    {
        return coinCount;
    }

    public void AddBalloonCount(int amount)
    {
        balloonCount += amount;
        Debug.Log("Ballon count: " + balloonCount);
    }
}
