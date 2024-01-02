using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingSaw : MonoBehaviour
{
    #region Variables 
    private Rigidbody rb;
    [SerializeField]
    private float moveSpeed = 1f; 
    [SerializeField]
    private float strafeAmount = 6f; // change this to adjust strafe amount


    private float leftBound = -1;
    private float rightBound = 1;
    private Vector3 moveDirection = Vector3.right;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        leftBound = transform.position.x - strafeAmount;
        rightBound = transform.position.x + strafeAmount;
        StartCoroutine(Move());
    }

    // Update is called once per frame

    IEnumerator Move()
    {
        while (true)
        {
            if (transform.position.x < leftBound)
            {
                moveDirection = Vector3.right;
            }
            if (transform.position.x > rightBound)
            {
                moveDirection = Vector3.left;
            }
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Toy")
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene("LoseScreen");
        }
    }
}
