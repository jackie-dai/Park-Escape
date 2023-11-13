using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toy : MonoBehaviour
{
    #region Variables
    private Rigidbody rb;
    private bool canPickup;
    private GameObject claw;
    private CapsuleCollider collider;
    private bool isHolding = false;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
    }

    // Handle pick up detection
    void Update()
    {
        if (Input.GetKeyDown("e") && canPickup)
        {
            if (!isHolding)
            {
                rb.isKinematic = true;
                transform.parent = claw.transform;
                collider.enabled = false;
                isHolding = true;
                Debug.Log("Pickup");
            } else
            {
                rb.isKinematic = false;
                transform.parent = null;
                collider.enabled = true;
                isHolding = false;
                Debug.Log("Drop");
            }
        }
    }

    /* To check if claw is in range */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Claw")
        {
            canPickup = true;
            claw = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.tag == "Claw")
        {
            canPickup = false;
        }
    }
}
