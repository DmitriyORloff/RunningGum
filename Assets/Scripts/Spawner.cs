using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyVariants;
    public SpeedManager speedManager;

    public float countdown = 0;

    private void Update()
    {
        if(countdown <= 0)
        {
            int rand = Random.Range(0, enemyVariants.Length);
            Instantiate(enemyVariants[rand], transform.position, Quaternion.identity);
            countdown = 1 / speedManager.GetSpawnRate();
        }
        else
        {
            countdown -= Time.deltaTime;
        }
    }
}
