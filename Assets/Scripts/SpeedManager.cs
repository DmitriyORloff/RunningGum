using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    private float speed;
    public float Speed { get => speed; }

    private float clock = 0;
    public float speedAcceleration;
    public float speedInitial;
    public float speedLimit;

    public float spawnRateAcceleration;
    public float spawnRateInitial;
    public float spawnRateLimit;


    private float GetSpeed()
    {
        float y = speedAcceleration * clock + speedInitial;
        if (y > speedLimit)
        {
            y = speedLimit;
        }
        return y;
    }
    public float GetSpawnRate()
    {
        float y = spawnRateAcceleration * clock + spawnRateInitial;
        if (y > spawnRateLimit)
        {
            y = spawnRateLimit;
        }
        return y;
    }

    private void FixedUpdate()
    {
        clock += Time.fixedDeltaTime;
        speed = GetSpeed();
    }
}
