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
    private bool pickedUp = false;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        Debug.Log("Start");

    }
   
    // Handle pick up detectiona
    void Update()
    {
        Debug.Log("Can PIckup: " + isHolding);
        if (Input.GetKeyDown(KeyCode.E) && pickedUp)
        {
            rb.isKinematic = false;
            transform.parent = null;
            collider.enabled = true;
            Debug.Log("Drop");
        }
    }

    /* To check if claw is in range */
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Claw")
        {
            if (!pickedUp)
            {
                canPickup = true;
                claw = other.gameObject;
                rb.isKinematic = true;
                transform.parent = claw.transform;
                collider.enabled = false;
                isHolding = true;
                pickedUp = true;
                Debug.Log("Pickup");
            }
        }
        Debug.Log("colliding");
    }

    void OnTriggerExit(Collider other)
    {
        
        if (other.tag == "Claw")
        {
            canPickup = false;
        }
    }
}
