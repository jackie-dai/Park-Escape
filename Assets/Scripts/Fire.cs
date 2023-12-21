using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;
    private Vector3 aim;
    private bool inCannonMode;
    [SerializeField]
    private Camera turretCamera;
    public float projectileSpeed;
    [SerializeField]
    public GameObject daggerPrefab;
    private Vector3 offset;

    private void Awake()
    {
        inCannonMode = false;
        player = player.GetComponent<PlayerController>();
        if (player == null)
        {
            Debug.Log("Fire cant find reference to player");
        }
        projectileSpeed = 5f;
        offset = new Vector3(0.00f, 1.2f, 1.5f);
    }

    void Update()
    {


        if (player.InCannonMode())
        {
            turretCamera.gameObject.SetActive(true);
            Vector3 mousePos = Input.mousePosition;
            aim = turretCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, turretCamera.nearClipPlane));
      
            if (Input.GetMouseButtonDown(0))
            {
                ShootDagger(aim);
            }
            
        } else
        {
            turretCamera.gameObject.SetActive(false);
        }
    }

    void ShootDagger(Vector3 target)
    {
        GameObject dagger = Instantiate(daggerPrefab, transform.position + offset, Quaternion.identity);
        dagger.transform.rotation = new Quaternion(0f, 180f, 0f, 1);
        Rigidbody rb = dagger.GetComponent<Rigidbody>();
        Vector2 direction = (target - dagger.transform.position).normalized;
        rb.velocity = direction * projectileSpeed;
    }
}
