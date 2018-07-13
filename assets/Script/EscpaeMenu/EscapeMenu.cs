using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    private bool isDisplayed = false;

    public GameObject menuUI;
    public GameObject optionsUI;

    public GameObject pauseButtonUI;

    private void Update()
    {        
        if(DeviceController.isMobile == false)
        {
            GameObject dropdown = GameObject.Find("Dropdown (1)");
            if(dropdown != null)
            {
                Destroy(dropdown);
                Destroy(GameObject.Find("Text (1)"));
            }
        }else
        {

        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        menuUI.SetActive(false);
        pauseButtonUI.SetActive(true);
        isDisplayed = false;
        Time.timeScale = 1;
    }

    public void Show()
    {
        menuUI.SetActive(true);
        pauseButtonUI.SetActive(false);
        isDisplayed = true;
        Time.timeScale = 0;
    }

    public void ShowOptions()
    {
        optionsUI.SetActive(true);
    }

    public void HideOptions()
    {
        optionsUI.SetActive(false);
    }

    public void GoToMenu()
    {
        Application.LoadLevel("MainMenu");
        Time.timeScale = 1;
    }

    public void OnEffectsSliderChanged(float value)
    {
        PlayerPrefs.SetFloat("EFFECTS_VOLUME", value);
    }

    public void OnMusicSliderChanged(float value)
    {
        PlayerPrefs.SetFloat("MUSIC_VOLUME", value);
    }

}
