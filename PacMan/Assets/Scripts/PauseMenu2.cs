using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu2 : MonoBehaviour{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    private AudioSource[] allAudioSources2;

    private GameObject canvas2;

    void Start(){

        pauseMenuUI.SetActive(false);
        
        canvas2 = GameObject.FindGameObjectWithTag("Canvas2");

    }

    void Awake(){

        allAudioSources2 = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

    }

    void Update(){

        if (Input.GetKeyDown(KeyCode.Escape)){

            if (isPaused){

                Resume();

            }
            else{
                StopAllAudio2();
                Pause();

            }

        }

    }

    public void Resume(){

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        canvas2.SetActive(true);

    }

    void Pause(){

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        canvas2.SetActive(false);
        Debug.Log("Deactivated");

    }

    public void quitToMenu(){

        SceneManager.LoadScene("Menu");
        Debug.Log("loading");

    }

    public void StopAllAudio2(){

        foreach (AudioSource audioS in allAudioSources2){
            audioS.Stop();

        }
    }
}
