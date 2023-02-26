using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    private SoundVolumeControllerComponent volumeControl;
    private Slider slider;
    private TextMeshProUGUI textLabel;
    void Start()
    {
        volumeControl = GameObject.FindGameObjectWithTag("BG_MUSIC_CREATED").GetComponent<SoundVolumeControllerComponent>();
        slider = GetComponent<Slider>();
        textLabel = GameObject.FindGameObjectWithTag("BG_MUSIC_VOLUME_TEXT").GetComponent<TextMeshProUGUI>();
        slider.value = volumeControl.Volume;
        UpdateTextLabel(slider.value);
    }
    private void UpdateTextLabel(float value) {
        textLabel.text = Mathf.Round(f: value * 100) + "%";
    }
    void LateUpdate()
    {
        float volume = slider.value;
        volumeControl.SetVolume(volume);
        UpdateTextLabel(volume);
    }
}
