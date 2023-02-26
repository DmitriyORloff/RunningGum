using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    private AudioSource ad;

    void Start()
    {
        // Similar to other sound toggle scripts
        ad = GetComponent<AudioSource>();
        ad.mute = PlayerPrefs.GetInt("music") == 0;
    }

    public void ToggleMusic()
    {
        ad.mute = !ad.mute;
        PlayerPrefs.SetInt("music", ad.mute ? 0 : 1);
    }
}
