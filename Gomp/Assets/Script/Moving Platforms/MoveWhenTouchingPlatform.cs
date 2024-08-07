using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWhenTouchingPlatform : MonoBehaviour
{

    public Transform platform;
    public Transform startPos;
    public Transform endPos;
    public float speed = 3f;
    int direction = 1;




    // Start is called before the first frame update
    void Start()
    {
        //startPos = this.gameObject.transform.position;
        //endPos = startPos + new Vector2(0, 6f);
    }


    Vector2 currentMovementTarget()
    {
        if (this.direction == 1)
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

        //if (player.Active)
        //{
        //    this.gameObject.transform.position = Vector2()
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        this.direction = -1;

        collision.gameObject.transform.SetParent(this.gameObject.transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        this.direction = 1;

        collision.gameObject.transform.SetParent(null);
    }
}

