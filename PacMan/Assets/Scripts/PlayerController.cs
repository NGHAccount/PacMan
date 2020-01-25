using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;

    private SpriteRenderer mySpriteRenderer;

    private GameObject seed;
    private GameObject blite;
    private static int newScore;
    
    public Score sHolder;

    Animator anim;


    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        seed = GameObject.FindGameObjectWithTag("Seed");
        blite = GameObject.FindGameObjectWithTag("Blite");
        anim = GetComponent<Animator>();

        sHolder.GetComponent<Score>();


    }

    void FixedUpdate()
    {
        

    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D)){

            rb2d.velocity = new Vector2(20,0);

            anim.SetInteger("State", 2);

        }

        if (Input.GetKeyUp(KeyCode.D)){

            rb2d.velocity = Vector2.zero;

        }


        if (Input.GetKeyDown(KeyCode.A)){

            rb2d.velocity = new Vector2(-20,0);

            anim.SetInteger("State", 3);

        }

        if (Input.GetKeyUp(KeyCode.A)){

            rb2d.velocity = Vector2.zero;

        }


        if (Input.GetKeyDown(KeyCode.W)){

            rb2d.velocity = new Vector2(0,20);

            anim.SetInteger("State", 1);

        }

        if (Input.GetKeyUp(KeyCode.W)){

            rb2d.velocity = Vector2.zero;

        }

        if (Input.GetKeyDown(KeyCode.S)){

            rb2d.velocity = new Vector2(0,-20);

            anim.SetInteger("State", 0);

        }

        if (Input.GetKeyUp(KeyCode.S)){

            rb2d.velocity = Vector2.zero;

        }


    }


    void OnTriggerEnter2D(Collider2D other){

        if (other.gameObject.CompareTag("LeftTransport")){

            transform.position = new Vector2(48.6f, -1.9f);
            rb2d.velocity = Vector2.zero;

        }

        if (other.gameObject.CompareTag("RightTransport")){

            transform.position = new Vector2(-49.7f, -4.4f);
            rb2d.velocity = Vector2.zero;

        }

        if (other.gameObject.CompareTag("Seed")){

            other.gameObject.SetActive(false);
            //Debug.Log("Hit");
            sHolder.UpdateScore();
            //Debug.Log("Scoring");


        }

        if (other.gameObject.CompareTag("Blite")){

            transform.position = new Vector2(0f, 16.28f);
            rb2d.velocity = Vector2.zero;
            sHolder.UpdateLives();

        }

    }

   
}
