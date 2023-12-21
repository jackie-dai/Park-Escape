using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    private float moveSpeed = 2f;

    void Update()
    {
         if (transform.position.x > 466)
        {
            transform.position = new Vector3(441f, transform.position.y, transform.position.z);
        }
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CannonBall")
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }

}
