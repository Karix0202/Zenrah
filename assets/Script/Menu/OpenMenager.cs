using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenager : MonoBehaviour 
{

    #region CLASS_VARIAVLES

    #endregion

    void Start()
    {
        int isFirstOpened = PlayerPrefs.GetInt("IS_FIRST_TIME_PLAYED");

        if (isFirstOpened == 0)
        {
            PlayerPrefs.SetString("PLAYER_MOVING", "JOYSTICK");

            PlayerPrefs.SetFloat("EFFECTS_VOLUME", 1f);

            PlayerPrefs.SetFloat("MUSIC_VOLUME", 1f);

            PlayerPrefs.SetInt("IS_FIRST_TIME_PLAYED", 1);
        }

    }

}
