using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public AudioSource ad;

    void Start()
    {
        ad.enabled = PlayerPrefs.GetInt("music") == 1;
    }

    public void ToggleMusic()
    {
        PlayerPrefs.SetInt("music", ad.enabled ? 0 : 1);
        ad.enabled = !ad.enabled;
    }
}
