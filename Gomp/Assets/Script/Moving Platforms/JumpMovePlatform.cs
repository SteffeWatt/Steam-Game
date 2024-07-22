using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class JumpMovePlatform : MonoBehaviour
{


    public Player player;
    public Transform platform;
    public Transform startPos;
    public Transform endPos;
    public float speed = 3f;

    Vector2 currentMovementTarget()
    {
        if (player.Active)
        {
            return startPos.position;
        }

        else
        {
            return endPos.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = currentMovementTarget();
        platform.position = Vector2.MoveTowards(platform.position, target, speed * Time.deltaTime);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    collision.gameObject.transform.SetParent(this.gameObject.transform);
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    collision.gameObject.transform.SetParent(null);
    //}
}
