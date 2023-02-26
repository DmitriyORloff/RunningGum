using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed;

    public float endX;
    public float startX;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.left);

        if(transform.position.x <= endX)
        {
            transform.position = new Vector2(startX, transform.position.y);
        }
    }
}
