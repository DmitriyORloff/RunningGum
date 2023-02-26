using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyVariants;
    public SpeedManager speedManager;
    public GameObject enemyPrefab;

    private readonly float YDisposition = 3.15f;

    public float countdown = 0;

    private void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0)
        {
            SpawnRandom();
            countdown = 1 / speedManager.GetSpawnRate();
        }
    }

    private void SpawnRandom()
    {
        switch(Random.Range(0, 3))
        {
            case 0:
                SpawnAt(1);
                SpawnAt(0);
                break;
            case 1:
                SpawnAt(-1);
                SpawnAt(0);
                break;
            case 2:
                SpawnAt(1);
                SpawnAt(-1);
                break;
        }

    }
    private void SpawnAt(int track)
    {
        Vector2 enemySpawnPosition = new(transform.position.x, YDisposition * track);
        Instantiate(enemyPrefab, enemySpawnPosition, Quaternion.identity);
    }
}
