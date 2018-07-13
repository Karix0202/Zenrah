using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour 
{

	public void Play()
    {
        Application.LoadLevel("Main");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Bye");
        Time.timeScale = 1;
    }

    public void GoToMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    public void GoToOptions()
    {
        Application.LoadLevel("Options");
    }

}
