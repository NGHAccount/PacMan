using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public static int score = 0;
    public static int lives = 4;

    public Text ScoreText;
    public Text Livestext;
    public Text gameOverText;
    public Text winText;

    private bool gameOver;
    private bool win = false;

    private GameObject scoreholder;
    

    void Awake(){

        scoreholder = GameObject.FindGameObjectWithTag("Holder");

        DontDestroyOnLoad(this.scoreholder);

        gameOver = false;
        

    }


    void Start(){

        UpdateScore();

        UpdateLives();

        gameOverText.text = "";
        winText.text = "";

    }

    
    void Update(){

        if (Input.GetKey("escape"))
            Application.Quit();

        if (lives == 0){

            GameOver();

        }
        

    }


    public void UpdateScore()
    {
        score = score + 10;
        ScoreText.text = "Score: " + score;
        //Debug.Log("Updating");

        if (score >= 200){

            winText.text = "You Win";
            gameOver = true;
            win = true;
            Time.timeScale = 0;

        }

    }

    public void UpdateLives(){

        lives = lives - 1;
        Livestext.text = "Lives: " + lives;
        

    }

    public void GameOver(){

        if (win == false){

            gameOverText.text = "Game Over!";
            Time.timeScale = 0;

        }
        gameOver = true;

    }
}
