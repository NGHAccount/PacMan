using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2Controller : MonoBehaviour
{
    public static int score = 0;
    public static int lives = 4;

    public Text ScoreText;
    public Text Livestext;

    private bool gameOver = false;
    private bool win = false;
    private bool restart;

    private GameObject scoreholder;

    public GameObject deathScreen;
    public GameObject winScreen;


    void Awake(){

        Time.timeScale = 1f;
        score = 0;
        lives = 4;
        scoreholder = GameObject.FindGameObjectWithTag("Holder2");
        deathScreen = GameObject.FindGameObjectWithTag("LosePanel2");
        winScreen = GameObject.FindGameObjectWithTag("WinPanel2");

    }


    void Start(){

        UpdateScore();
        UpdateLives();
        restart = false;

        deathScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);


    }


    void Update(){
        
        if (lives == 0)
        {

            deathScreen.gameObject.SetActive(true);
            GameOver();
            restart = true;

        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Level2");
                gameOver = false;
                win = false;
                restart = false;
                Time.timeScale = 1f;

            }

        }
    }


    public void UpdateScore()
    {
        score = score + 10;
        ScoreText.text = "Score: " + score;
        //Debug.Log("Updating");

        if (score >= 200)
        {

            winScreen.gameObject.SetActive(true);
            //winText.text = "You Win";
            gameOver = true;
            win = true;
            restart = true;
            Time.timeScale = 0;

        }

    }

    public void UpdateLives()
    {

        lives = lives - 1;
        Livestext.text = "Lives: " + lives;

    }

    public void GameOver()
    {

        if (win == false)
        {

            //gameOverText.text = "Game Over!";
            Time.timeScale = 0;

        }
        gameOver = true;

    }
}
