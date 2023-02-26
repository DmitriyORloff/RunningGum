using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    public Sprite onMusic;
    public Sprite offMusic;
    void Start()
    {
        UpdateSprite();
    }
    public void UpdateSprite()
    {
        GetComponent<Image>().sprite = PlayerPrefs.GetInt("music") == 1 ? onMusic : offMusic;
    }
    public void HandleClick()
    {
        GameObject.FindGameObjectWithTag("BG_MUSIC_CREATED").GetComponent<Music>().ToggleMusic();
        UpdateSprite();
    }
}
