using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public BalloonManager balloonManager;
    private string[] colorOptions = { "Red", "Blue", "Yellow" };
    private float moveSpeed;
    private Vector3 startPosition;
    private bool destroyed = false;
    [SerializeField]
    public Sprite[] balloonSprites = new Sprite[3];
    private SpriteRenderer sp;
    [SerializeField] private GameObject toyPrefab;
    private string color;
    public string Color
    {
        get
        {
            return color;
        }
    }

    void Awake()
    {
        
        sp = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        System.Random rand = new System.Random();
        int randomNum = rand.Next(colorOptions.Length);
        color = colorOptions[randomNum];
        sp.sprite = balloonSprites[randomNum];
        transform.gameObject.tag = "Balloon";
        balloonManager.AddColorCount(randomNum, 1);
        balloonManager.AddBalloon(1);
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
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime); // Vec
    }

    void OnTriggerEnter(Collider other) 
    {
       
        if (other.tag == "CannonBall" && !destroyed)
        {
           
            if (balloonManager.CurrentColor != color)
            {
                Debug.Log("entered1");
                Instantiate(toyPrefab, transform.position, Quaternion.identity);
            } 
            else
            {
                Debug.Log("entered2");
                balloonManager.ReduceCount();
            }
            Debug.Log("done");
            destroyed = true;
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
