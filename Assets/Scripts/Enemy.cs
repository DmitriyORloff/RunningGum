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
        transform.Translate(speedManager.Speed * Time.deltaTime * Vector2.left);
    }
    public void Pop()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
