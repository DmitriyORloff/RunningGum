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

    private AudioSource ad;

    void Start()
    {
        ad = GetComponent<AudioSource>();
        ad.mute = PlayerPrefs.GetInt("effects") == 0;
    }

    public void ToggleSound()
    {
        ad.mute = !ad.mute;
        PlayerPrefs.SetInt("effects", ad.mute ? 0 : 1);
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
