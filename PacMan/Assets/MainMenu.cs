using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{

    public void levelOne(){

        SceneManager.LoadScene("PacMan");

    }

    public void levelTwo()
    {

        SceneManager.LoadScene("Level2");

    }
    
    public void quitGame(){

        Application.Quit();
        Debug.Log("Quitting");

    }

}
