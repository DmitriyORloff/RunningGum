using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffector : MonoBehaviour
{
    public AudioClip playerMove;
    public AudioClip enemyCollision;
    public AudioClip buttonTap;

    public enum Clips
    {
        PlayerMove,
        EnemyCollision,
        ButtonTap
    }

    public bool isOn;
    private AudioSource ad;

    void Start()
    {
        ad = GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("effects") == 1)
            AtSoundOn();
        else
            AtSoundOff();
    }

    public void ToggleSound()
    {
        if (isOn)
        {
            PlayerPrefs.SetInt("effects", 0);
            AtSoundOff();
        }
        else
        {
            PlayerPrefs.SetInt("effects", 1);
            AtSoundOn();
        }
    }
    private void AtSoundOff()
    {
        ad.mute = true;
        isOn = false;
    }
    private void AtSoundOn()
    {
        ad.mute = false;
        isOn = true;
    }
    public void Playback(Clips clipTag)
    {
        switch (clipTag)
        {
            case Clips.PlayerMove:
                PlaybackClip(playerMove);
                break;
            case Clips.EnemyCollision:
                PlaybackClip(enemyCollision);
                break;
            case Clips.ButtonTap:
                PlaybackClip(buttonTap);
                break;
        }

    }
    public void PlaybackClip(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
