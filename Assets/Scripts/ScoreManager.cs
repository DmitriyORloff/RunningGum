using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;
    public Text HighScoreText; // это добавил
    private Player player;

    private void Start()
    {
        UpdateHighScoreText();
        player = GameObject.Find("character").GetComponent<Player>();
        scoreDisplay = GameObject.Find("Score").GetComponent<Text>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && player.health > 0)
        {
            score++;
            if (PlayerPrefs.GetInt("highscore") < score) //эту и дальше вписал после
                PlayerPrefs.SetInt("highscore", score);
            scoreDisplay.text = "Score: " + score; // это как было, когда работало
            UpdateHighScoreText();
        }
    }
    private void UpdateHighScoreText()
    {
        UpdateHighScoreText(PlayerPrefs.GetInt("highscore"));
    }
    private void UpdateHighScoreText(int newHighScore)
    {
        HighScoreText.text = "HIGHSCORE: " + newHighScore;
    }
}
