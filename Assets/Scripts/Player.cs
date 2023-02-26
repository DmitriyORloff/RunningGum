using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    private int track = 0; // 1 for up, 0 for middle and -1 for bottom
    public float YDisposition;
    public float speed;
    public int health = 5;

    public GameObject effect;
    public Text healthDisplay;
    public GameObject panel;

    private void Start()
    {
        UpdateHealthText();
        targetPos = transform.position;
    }

    private void SetTrack(int newTrack)
    {
        track = newTrack;
        targetPos = new Vector2(targetPos.x, YDisposition * track);
    }

    public void MovePlayer(bool up)
    {
        if (up)
        {
            if (track == 1) return;
            SetTrack(track + 1);
        }
        else
        {
            if (track == -1) return;
            SetTrack(track - 1);
        }
        GameObject.FindGameObjectWithTag("BG_EFFECTS_CREATED").GetComponent<AudioEffector>().Playback(AudioEffector.Clips.PlayerMove);
        Instantiate(effect, transform.position, Quaternion.identity);
    }

    private void UpdateHealthText() {
        healthDisplay.text = "Lives: " + health.ToString();
    }

    private void Damage(int damage)
    {
        health -= damage;
        UpdateHealthText();
        if (health <= 0)
        {
            panel.SetActive(true);
            Destroy(gameObject);
            Destroy(healthDisplay);

            GameObject.Find("Score").SetActive(false);
        }
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject.FindGameObjectWithTag("BG_EFFECTS_CREATED").GetComponent<AudioEffector>().Playback(AudioEffector.Clips.EnemyCollision);
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.Pop();
            Damage(enemy.damage);
        }
    }
}

