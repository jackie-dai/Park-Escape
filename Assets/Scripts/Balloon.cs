using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    private string[] colorOptions = { "Red", "Blue", "Yellow" };
    private float moveSpeed;
    private Vector3 startPosition;
    private string color;
    [SerializeField]
    public Sprite[] balloonSprites = new Sprite[3];
    private SpriteRenderer sp;
    [SerializeField]
    private PlayerController player;
    


    void Awake()
    {
        player = player.gameObject.GetComponent<PlayerController>();
        sp = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        System.Random rand = new System.Random();
        int randomNum = rand.Next(colorOptions.Length);
        color = colorOptions[randomNum];
        sp.sprite = balloonSprites[randomNum];
        //transform.gameObject.tag = color;


        moveSpeed = 2f;
        startPosition = new Vector3(441f, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (transform.position.x > 466)
        {
            transform.position = startPosition;
        }
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) 
    {
        Debug.Log("adsf");
        if (other.tag == "CannonBall")
        {
            player.AddBalloonCount(1);
            Destroy(transform.gameObject);
        }
    }

/*    void OnTriggerEnter(Collider other)
    {
        Debug.Log("adsf");
        if (other.tag == "CannonBall")
        {
            Destroy(transform.gameObject);
        }
    }*/
}
