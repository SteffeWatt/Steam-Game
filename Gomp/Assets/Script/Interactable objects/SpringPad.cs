using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPad : MonoBehaviour
{
    // Start is called before the first frame update


    public float jumpforce;

    public float bumpForce;
    public float fieldOfImpact;
    public LayerMask layerToBump;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject.CompareTag("SpringLeft"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * jumpforce, ForceMode2D.Impulse);

                Vector2 direction = collision.gameObject.transform.position - transform.position;

                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * bumpForce);

            }

        }

        if (this.gameObject.CompareTag("SpringRight"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-1,0) * jumpforce, ForceMode2D.Impulse);
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
