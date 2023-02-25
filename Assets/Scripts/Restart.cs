using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    private Text score; 
    private ScoreManager sm;

    private void Start()
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        score = GameObject.Find("ScoreCenter").GetComponent<Text>();
        score.text = ("¬аш счет: ") + sm.score.ToString();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
