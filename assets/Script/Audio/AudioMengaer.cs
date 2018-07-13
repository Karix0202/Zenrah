using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioMengaer : MonoBehaviour
{
    public AudioSource[] effectsAudios;

    public AudioSource bgMusic;

    public Slider effectsSlider;
    public Slider musicSlider;

    private bool fading;

    private void Start()
    {
        effectsSlider.value = PlayerPrefs.GetFloat("EFFECTS_VOLUME");
        musicSlider.value = PlayerPrefs.GetFloat("MUSIC_VOLUME");
        fading = false;
    }

    private void Update()
    {
        float effectsVolume = PlayerPrefs.GetFloat("EFFECTS_VOLUME");
        foreach(AudioSource e in effectsAudios)
        {
            if(e != null)
            {
                e.volume = effectsVolume;
            }
        }

        if(fading == false)
        {
            bgMusic.volume = PlayerPrefs.GetFloat("MUSIC_VOLUME");
        }
    }

}
