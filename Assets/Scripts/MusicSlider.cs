using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    void Start()
    {
        float vol = GameObject.FindGameObjectWithTag("BG_MUSIC_CREATED").GetComponent<SoundVolumeControllerComponent>().Volume;
        GetComponent<Slider>().value = vol;
    }
}
