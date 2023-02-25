using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioToggler : MonoBehaviour
{

    public Sprite onSound;
    public Sprite offSound;

    private void Start()
    {
        UpdateSprite();
    }

    public void OnOffSound()
    {
        GameObject.FindGameObjectWithTag("BG_EFFECTS_CREATED").GetComponent<AudioEffector>().ToggleSound();
        UpdateSprite();
    }
    private void UpdateSprite()
    {
        if (PlayerPrefs.GetInt("effects") == 1)
            GetComponent<Image>().sprite = onSound;
        else
            GetComponent<Image>().sprite = offSound;
    }
}
