using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;
    private SpeedManager speedManager;
    public GameObject effect;

    private void Start()
    {
        speedManager = GameObject.Find("SpeedManager").GetComponent<SpeedManager>();
    }
    private void Update()
    {
        transform.Translate(Vector2.left * speedManager.Speed * Time.timeScale);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("BG_EFFECTS_CREATED").GetComponent<AudioEffector>().Playback(AudioEffector.Clips.EnemyCollision);
            Instantiate(effect, transform.position, Quaternion.identity);
            other.GetComponent<Player>().health -= damage;
            Destroy(gameObject);
        }
    }
}
