using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPad : MonoBehaviour
{
    // Start is called before the first frame update


    public float jumpforce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject.CompareTag("SpringLeft"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("hårruheite");
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * jumpforce, ForceMode2D.Impulse);
            }

        }

        if (this.gameObject.CompareTag("SpringRight"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * jumpforce, ForceMode2D.Impulse);
            }

        }

        if (this.gameObject.CompareTag("SpringUp"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            }

        }

        if (this.gameObject.CompareTag("SpringDown"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * jumpforce, ForceMode2D.Impulse);
            }

        }

    }
}
