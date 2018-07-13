using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour 
{
    public void ValueChangeCheck(float value)
    {
        PlayerPrefs.SetFloat("EFFECTS_VOLUME", value);
        Debug.Log(PlayerPrefs.GetFloat("EFFECTS_VOLUME"));
    }
}
