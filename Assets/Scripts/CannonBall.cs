using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField]
    public float launchSpeed = 10f; // The launch speed
    public float launchAngle = 0f; // The launch angle in degrees
    public float launchArc = 1f;
    public float bounceIntensity = 0.8f;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Applies a forward force launching the cannon ball
    public void Launch()
    {
        Debug.Log("Launch");


        float radians = launchAngle * Mathf.Deg2Rad;
        Vector3 launchDirection = new Vector3(Mathf.Sin(radians), 0, Mathf.Cos(radians));
        Vector3 arc = new Vector3(0, launchArc, 0); // Adjust the arc here
        rb.velocity = (launchDirection + arc).normalized * launchSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Horse")) // Assuming you have walls tagged as "Wall"
        {
            // Launch the ball along the Z-axis.
            rb.AddForce(Vector3.forward * launchSpeed, ForceMode.VelocityChange);
        }
    }
}
