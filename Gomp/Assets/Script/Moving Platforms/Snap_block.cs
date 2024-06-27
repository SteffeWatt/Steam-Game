using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Snap_block : MonoBehaviour
{

    public Player player;

    public GameObject startPoint;
    public GameObject endPoint;

    public float speed;
    private Vector2 StartPos;
    private Vector2 EndPos;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = new Vector2(0 + startPoint.transform.position.x, startPoint.transform.position.y);
        EndPos = new Vector2(0 + endPoint.transform.position.x, startPoint.transform.position.y);

    }

    // Update is called once per framea
    void Update()
    {
        if (player.Active)
        {
            this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, StartPos, speed * Time.deltaTime);
        }
        else
        {
            this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, EndPos, speed * Time.deltaTime);
        }
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
