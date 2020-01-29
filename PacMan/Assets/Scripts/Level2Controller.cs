using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2Controller : MonoBehaviour
{
    //public static int score = 0;
    //public static int lives = 4;
    public static int newScore;
    public static int newLives;
    //public static int newLives2;

    public Text ScoreText;
    public Text Livestext;

    private bool gameOver = false;
    private bool win = false;
    private bool restart;
    private bool isPlaying = false;

    private GameObject scoreholder;

    public GameObject deathScreen;
    public GameObject winScreen;
    public AudioSource scoreSource2;
    public AudioSource levelSource2;
    public AudioClip loseMusicClip2;
    public AudioClip menuMusicClip2;
    public AudioClip winMusicClip2;
    public AudioClip levelMusicClip2;

    //public Score messHolder;
    //public PlayerController2 pCon2;


    void Awake(){

        Time.timeScale = 1f;
        newScore = Score.score;
        newLives = Score.lives + 1;
        //newLives2 = newLives;
        scoreholder = GameObject.FindGameObjectWithTag("Holder2");
        deathScreen = GameObject.FindGameObjectWithTag("LosePanel2");
        winScreen = GameObject.FindGameObjectWithTag("WinPanel2");

        
        levelSource2.clip = levelMusicClip2;
        levelSource2.Play();
        levelSource2.volume = 0.3f;


    }


    void Start(){

        UpdateScore();
        UpdateLives();
        restart = false;

        deathScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);

        //messHolder.GetComponent<Score>();
        //pCon2.GetComponent<PlayerController2>();


    }


    void Update(){
        
        if (newLives == 0){

            deathScreen.gameObject.SetActive(true);
            GameOver();
            restart = true;
            scoreSource2.clip = loseMusicClip2;
            scoreSource2.PlayOneShot(loseMusicClip2);
            scoreSource2.volume = 0.05f;

        }

        if (restart){

            if (Input.GetKeyDown(KeyCode.R)){
                SceneManager.LoadScene("PacMan");
                gameOver = false;
                win = false;
                restart = false;
                Time.timeScale = 1f;

            }

        }


        if (Input.GetKeyDown(KeyCode.Escape)){

            isPlaying = !isPlaying;

            if (isPlaying){

                levelSource2.Stop();

            }
            else{

                levelSource2.Play();

            }

        }
    }


    public void UpdateScore(){
        newScore = newScore + 10;
        ScoreText.text = "Score: " + newScore;
        //Debug.Log("Updating");

        if(newScore == 2040){

            winScreen.gameObject.SetActive(true);
            //winText.text = "You Win";
            GameOver();
            gameOver = true;
            win = true;
            restart = true;
            Time.timeScale = 0;
            scoreSource2.clip = winMusicClip2;
            scoreSource2.Play();

        }else if (newScore >= 4340){

            winScreen.gameObject.SetActive(true);
            //winText.text = "You Win";
            GameOver();
            gameOver = true;
            win = true;
            restart = true;
            Time.timeScale = 0;
            scoreSource2.clip = winMusicClip2;
            scoreSource2.Play();

        }

    }

    public void UpdateLives(){

        newLives = newLives - 1;
        Livestext.text = "Lives: " + newLives;

    }

    public void GameOver(){

        if (win == false){
            Time.timeScale = 0;
            

        }
        gameOver = true;

        levelSource2.clip = levelMusicClip2;
        levelSource2.Stop();
        
    }


}
