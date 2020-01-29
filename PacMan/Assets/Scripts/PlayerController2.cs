using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d2;

    private SpriteRenderer mySpriteRenderer;

    private GameObject seed2;
    private GameObject blite2;
    private static int newScore2;
    //private bool isPlaying = false;
    
    public AudioSource playerSource2;
    //public AudioSource levelSource2;
    public AudioSource pickupSource2;
    public AudioClip pickupClip2;
    //public AudioClip levelMusicClip2;
    public AudioClip playerHitClip2;
    public AudioClip powerupClip2;
    public AudioClip powerupMusicClip2;

    public Level2Controller s2Holder;

    Animator anim;


    void Start(){

        rb2d2 = GetComponent<Rigidbody2D>();
        seed2 = GameObject.FindGameObjectWithTag("Seed2");
        blite2 = GameObject.FindGameObjectWithTag("Blite2");
        anim = GetComponent<Animator>();

        s2Holder.GetComponent<Level2Controller>();
        playerSource2 = GetComponent<AudioSource>();


    }

    void Awake(){
        /*
        levelSource2.clip = levelMusicClip2;
        levelSource2.Play();
        levelSource2.volume = 0.3f;
        */
    }

    void FixedUpdate(){




    }


    void Update(){

        if (Input.GetKeyDown(KeyCode.D)){

            rb2d2.velocity = new Vector2(20, 0);

            anim.SetInteger("State", 2);

        }

        if (Input.GetKeyUp(KeyCode.D)){

            rb2d2.velocity = Vector2.zero;

        }


        if (Input.GetKeyDown(KeyCode.A)){

            rb2d2.velocity = new Vector2(-20, 0);

            anim.SetInteger("State", 3);

        }

        if (Input.GetKeyUp(KeyCode.A)){

            rb2d2.velocity = Vector2.zero;

        }


        if (Input.GetKeyDown(KeyCode.W)){

            rb2d2.velocity = new Vector2(0, 20);

            anim.SetInteger("State", 1);

        }

        if (Input.GetKeyUp(KeyCode.W)){

            rb2d2.velocity = Vector2.zero;

        }

        if (Input.GetKeyDown(KeyCode.S)){

            rb2d2.velocity = new Vector2(0, -20);

            anim.SetInteger("State", 0);

        }

        if (Input.GetKeyUp(KeyCode.S)){

            rb2d2.velocity = Vector2.zero;
        
        }
        
        /*
        if (Input.GetKeyDown(KeyCode.Escape)){

            isPlaying = !isPlaying;

            if (isPlaying){

                levelSource2.Stop();

            }
            else{

                levelSource2.Play();

            }

        }*/
        

    }


    void OnTriggerEnter2D(Collider2D other){

        if (other.gameObject.CompareTag("LeftTransport2")){

            transform.position = new Vector2(49.2f, -1.86f);
            rb2d2.velocity = Vector2.zero;

        }

        if (other.gameObject.CompareTag("RightTransport2")){

            transform.position = new Vector2(-45.7f, -4.5f);
            rb2d2.velocity = Vector2.zero;

        }

        if (other.gameObject.CompareTag("Seed2")){

            other.gameObject.SetActive(false);
            //Debug.Log("Hit");
            s2Holder.UpdateScore();
            //Debug.Log("Scoring");
            playerSource2.clip = pickupClip2;
            playerSource2.Play();


        }

        if (other.gameObject.CompareTag("Blite2")){

            transform.position = new Vector2(1.8f, -40.2f);
            rb2d2.velocity = Vector2.zero;
            s2Holder.UpdateLives();
            playerSource2.clip = playerHitClip2;
            playerSource2.Play();

        }

        if (other.gameObject.CompareTag("tree")){

            other.gameObject.SetActive(false);
            //Debug.Log("powering");
            //rb2d.velocity *= 2;
            Level2Controller.newLives = Level2Controller.newLives + 2;
            s2Holder.UpdateLives();
            pickupSource2.clip = powerupClip2;
            pickupSource2.Play();
            pickupSource2.volume = 0.3f;


        }

    }
}
