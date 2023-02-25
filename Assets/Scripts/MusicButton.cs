using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    public Sprite onMusic;
    public Sprite offMusic;
    // Start is called before the first frame update
    void Start()
    {
        UpdateSprite();
    }
    public void UpdateSprite()
    {
        if (PlayerPrefs.GetInt("music") == 1)
            GetComponent<Image>().sprite = onMusic;
        else
            GetComponent<Image>().sprite = offMusic;
    }
    public void HandleClick()
    {
        GameObject.FindGameObjectWithTag("BG_MUSIC_CREATED").GetComponent<Music>().offSound();
        UpdateSprite();
    }
}
