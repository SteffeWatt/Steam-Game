using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 endPos;
    public bool Active = false;

    public GameObject player;

    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.gameObject.transform.position;
        endPos = startPos + new Vector2(0, -2.8f);

    }

    // Update is called once per frame
    void Update()
    {

       

        
        

            

            Active = !Active;

            if (Active)
            {
                //this.gameObject.transform.position = Vector2.Lerp(startPos, endPos, 2);
                transform.position = Vector2.Lerp(startPos, endPos, speed / 5);
            }
            else
            {
                //this.gameObject.transform.position = Vector2.Lerp(endPos, startPos, 2);
                transform.position = Vector2.Lerp(endPos, startPos, speed / 5);
            }
        
    }

    
}
