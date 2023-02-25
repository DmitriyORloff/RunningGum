using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTapEffect : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Tapped);
    }
    public void Tapped()
    {
        GameObject.FindGameObjectWithTag("BG_EFFECTS_CREATED").GetComponent<AudioEffector>().Playback(AudioEffector.Clips.ButtonTap);
    }
}
