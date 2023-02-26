using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolumeControllerComponent : MonoBehaviour
{
    private new AudioSource audio;

    [SerializeField] private string saveVolumeKey;

    public float Volume { get => audio.volume; }

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey(saveVolumeKey))
        {
            audio.volume = PlayerPrefs.GetFloat(saveVolumeKey);
        }
        else
        {
            SetVolume(0.5f);
        }
    }

    public void SetVolume(float newVolume)
    {
        audio.volume = newVolume;
        PlayerPrefs.SetFloat(saveVolumeKey, newVolume);
    }
}
