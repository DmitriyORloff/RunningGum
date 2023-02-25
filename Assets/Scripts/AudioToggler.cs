using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioToggler : MonoBehaviour
{
    public Sprite onSound;
    public Sprite offSound;
    void Start()
    {
        UpdateSprite();
    }
    private void UpdateSprite()
    {
        GetComponent<Image>().sprite = PlayerPrefs.GetInt("effects") == 1 ? onSound : offSound;
    }
    public void OnOffSound()
    {
        GameObject.FindGameObjectWithTag("BG_EFFECTS_CREATED").GetComponent<AudioEffector>().ToggleSound();
        UpdateSprite();
    }
}
