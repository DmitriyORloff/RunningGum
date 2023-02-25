using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwipeController : MonoBehaviour
{
    private Vector2 touchStart;
    public float sensitivityThreshold;
    public Player player;

    private void Update()
    {
        // For PC (keys):
        if (Input.GetKeyDown(KeyCode.W))
            player.MovePlayer(true);
        else if (Input.GetKeyDown(KeyCode.S))
            player.MovePlayer(false);
        // For PC (mouse):
        else if (Input.GetMouseButtonDown(0))
            touchStart = Input.mousePosition;
        else if (Input.GetMouseButtonUp(0)) 
            SubmitSwipe(Input.mousePosition);
        // For Mobiles (touch):
        else if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
                touchStart = Input.touches[0].position;
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
                SubmitSwipe(Input.touches[0].position);
        }
    }

    private void SubmitSwipe(Vector2 touchEnd)
    {
        Vector2 delta = touchEnd - touchStart;
        if (delta.magnitude > sensitivityThreshold)
        {
            if (Mathf.Abs(delta.y) > Mathf.Abs(delta.x))
            {
                player.MovePlayer(delta.y > 0);
            }
        }
    }
}
