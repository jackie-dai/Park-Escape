using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    private float moveSpeed = 2f;
    private float invincibilityTimer;
    private float timeInvincible = 1f;

    void Awake()
    {
        invincibilityTimer = timeInvincible;
    }

    void Update()
    {
         if (transform.position.x > 466)
        {
            transform.position = new Vector3(441f, transform.position.y, transform.position.z);
        }
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);

  
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CannonBall" && invincibilityTimer <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }

}
