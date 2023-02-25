using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    public float Yincrement;
    public float speed;
    public float maxHeight;
    public float minHeight;
    public int health = 5;

    public GameObject effect;
    public Text healthDisplay;
    public GameObject panel;

    private void Start()
    {
        targetPos = transform.position;
    }

    public void MovePlayer(bool up)
    {
        if (up)
        {
            if (targetPos.y >= maxHeight) return;
            targetPos = new Vector2(targetPos.x, targetPos.y + Yincrement);
        }
        else
        {
            if (targetPos.y <= minHeight) return;
            targetPos = new Vector2(targetPos.x, targetPos.y - Yincrement);
        }
        GameObject.FindGameObjectWithTag("BG_EFFECTS_CREATED").GetComponent<AudioEffector>().Playback(AudioEffector.Clips.PlayerMove);
        Instantiate(effect, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        healthDisplay.text = "Lives: " + health.ToString();
        if (health <= 0)
        {
            panel.SetActive(true);
            Destroy(gameObject);
            Destroy(healthDisplay);
        
            GameObject.Find("Score").SetActive(false);
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {
            GameObject.FindGameObjectWithTag("BG_EFFECTS_CREATED").GetComponent<AudioEffector>().Playback(AudioEffector.Clips.EnemyCollision);
            Enemy enemy = other.GetComponent<Enemy>();
            health -= enemy.damage;
            enemy.Pop();
        }
    }
}

