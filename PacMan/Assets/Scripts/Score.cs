using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{

    public static int score = -10;
    public static int lives = 4;

    public Text ScoreText;
    public Text Livestext;

    private bool gameOver = false;
    private bool win = false;
    private bool restart;
    private bool isPlaying = false;

    private GameObject scoreholder;

    public GameObject deathScreen;
    public GameObject winScreen;
    public GameObject menu;
    public AudioSource scoreSource;
    public AudioSource levelSource;
    public AudioClip loseMusicClip;
    public AudioClip menuMusicClip;
    public AudioClip levelMusicClip;



    void Awake(){

        Time.timeScale = 1f;
        score = -10;
        lives = 4;
        scoreholder = GameObject.FindGameObjectWithTag("Holder");
        deathScreen = GameObject.FindGameObjectWithTag("LosePanel");
        winScreen = GameObject.FindGameObjectWithTag("WinPanel");
        menu = GameObject.FindGameObjectWithTag("Menu1");
        
        levelSource.clip = levelMusicClip;
        levelSource.Play();
        levelSource.volume = 0.5f;
        

    }


    void Start(){

        UpdateScore();
        UpdateLives();

        restart = false;

        deathScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
        

    }

    
    void Update(){
        
        if (lives == 0){

            deathScreen.gameObject.SetActive(true);
            GameOver();
            restart = true;
            scoreSource.clip = loseMusicClip;
            scoreSource.PlayOneShot(loseMusicClip);
            scoreSource.volume = 0.05f;

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

                levelSource.Stop();

            }
            else{

                levelSource.PlayOneShot(levelMusicClip);

            }

        }


    }


    public void UpdateScore()
    {
        score = score + 10;
        ScoreText.text = "Score: " + score;
        //Debug.Log("Updating");

        if (score >= 2290){
            
            SceneManager.LoadScene("Level2");

        }

    }

    public void UpdateLives(){

        lives = lives - 1;
        Livestext.text = "Lives: " + lives;

    }

    public void GameOver(){

        if (win == false){
            
            Time.timeScale = 0;

        }


        gameOver = true;

    }
}
