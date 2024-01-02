using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField]
    public float launchSpeed = 10f; // The launch speed
    public float launchAngle = 180f; // The launch angle in degrees
    public float launchArc = 0f;
    public float bounceIntensity = 0.8f;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Applies a forward force launching the cannon ball
    public void Launch(Vector3 direction)
    {
        Debug.Log("Launch");


        float radians = launchAngle * Mathf.Deg2Rad;
        //Vector3 launchDirection = new Vector3(Mathf.Sin(radians), 0, Mathf.Cos(radians));
        Vector3 launchDirection = direction;
        Vector3 arc = new Vector3(0, launchArc, 0); // Adjust the arc here
        rb.velocity = (launchDirection + arc).normalized * launchSpeed;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Toy")
        {
            Debug.Log("You suck jesus christ");
        }
        
        if (other.transform.tag == "Balloon")
        {
            Debug.Log("hit a balloon colored: " + other.transform.GetComponent<Balloon>().Color);

        }
        Debug.Log("Hitting : " + other.gameObject.tag);
    }
}
