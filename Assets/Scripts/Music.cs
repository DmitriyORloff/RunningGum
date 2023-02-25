using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public bool isOn;
    public AudioSource ad;

    void Start()
    {
        if (PlayerPrefs.GetInt("music") == 1)
            AtSoundOn();
        else
            AtSoundOff();
    }

    public void offSound()
    {
        if (isOn)
        {
            PlayerPrefs.SetInt("music", 0);
            AtSoundOff();
        }
        else 
        { 
            PlayerPrefs.SetInt("music", 1);
            AtSoundOn();
        }
    }
    private void AtSoundOff()
    {
        ad.enabled = false;
        isOn = false;
    }
    private void AtSoundOn()
    {
        ad.enabled = true;
        isOn = true;
    }
}
