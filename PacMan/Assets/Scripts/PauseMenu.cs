using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour{

    
    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    private GameObject canvas;

    void Start(){

        pauseMenuUI.SetActive(false);

        canvas = GameObject.FindGameObjectWithTag("Canvas1");

    }

    void Update(){

        if (Input.GetKeyDown(KeyCode.Escape)){

            if (isPaused){

                Resume();

            }
            else{

                Pause();

            }

        }
        
    }

    public void Resume(){

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        canvas.SetActive(true);

    }

    void Pause(){

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        canvas.SetActive(false);
        Debug.Log("Deactivated");

    }

    public void quitToMenu(){

        SceneManager.LoadScene("Menu");
        Debug.Log("loading");

    }
}
