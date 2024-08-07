using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformInASquare : MonoBehaviour
{
   
    public Transform platform;

    public Transform startPos;
    public Transform secondPos;
    public Transform thirdPos;
    public Transform endPos;

    public float speed = 3f;
    int direction = 1;

    Vector2 currentMovementTarget()
    {
        if (this.direction == 1)
        {
            return secondPos.position;
        }
        
        if (this.direction == 2)
        {
            return thirdPos.position;
        }

        if (this.direction == 3)
        {
            return endPos.position;
        }

        else
        {
            return startPos.position;
        }
    }

    // Update is called once per frame
    void Update()
    {




        if (this.gameObject.transform.position.y == startPos.position.y)
        {
            this.direction = 1;
        }
        else if (this.gameObject.transform.position.y == secondPos.position.y)
        {
            this.direction = 2;
        }
        else if (this.gameObject.transform.position.y == thirdPos.position.y)
        {
            this.direction = 3;
        }
        else if (this.gameObject.transform.position.y == endPos.position.y)
        {
            this.direction = 4;
        }


        Vector2 target = currentMovementTarget();
        platform.position = Vector2.MoveTowards(platform.position, target, speed * Time.deltaTime);

  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.transform.SetParent(this.gameObject.transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.transform.SetParent(null);
    }
}

