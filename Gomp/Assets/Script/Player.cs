using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Camera;

    public GameObject playerModel;
    private Rigidbody2D rb;
    private SpriteRenderer rbSprite;
    public Animator rbAnimator;

    public bool Active = false;
    public bool isMoving = false;

    public bool isGrounded = true;
    private float JumpPower = 20f;

    private float cyoteTime = 0.2f;
    private float cyoteCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>();
        rbAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(rb.velocity.x > 0.8 || rb.velocity.x < -0.8)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isGrounded)
        {
            cyoteCounter = cyoteTime;
        }
        else
        {
            cyoteCounter -= Time.deltaTime;
        }
        
        if (Input.GetKeyDown("space")) 
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else 
        {
            jumpBufferCounter -= Time.deltaTime;
        }



        float moveHorizontal = Input.GetAxis("Horizontal");
        
        rb.velocity = new Vector2(moveHorizontal * 10, rb.velocity.y);
        Flip();
        rbAnimator.SetFloat("speed", Mathf.Abs(moveHorizontal));
        rbAnimator.SetFloat("fallSpeed", rb.velocity.y);
        rbAnimator.SetBool("isGrounded", isGrounded);
        

        if (jumpBufferCounter > 0f && cyoteCounter > 0f)
        {
            rb.velocity = new Vector2( rb.velocity.x, JumpPower);

            jumpBufferCounter = 0f;
        }

        if (Input.GetKeyUp("space") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.35f);
            cyoteCounter = 0f;
        }


        //dessa e bare t testing
        //-------------------------
        if (Input.GetKeyDown("e"))
        {
            rb.AddForce(Vector2.up * -7.5f, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown("q"))
        {
            Active = !Active;
        }

        if (Input.GetKeyDown("w"))
        {
            rb.AddForce(Vector2.up * 7.5f, ForceMode2D.Impulse);
        }
        //-------------------------


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void Flip()
    {
        if(rb.velocity.x > 0f)
        {
            rbSprite.flipX = false;
        }

        if (rb.velocity.x < 0f)
        {
            rbSprite.flipX = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Zone-Left" && rb.velocity.x < 0f)
        {
            Camera.transform.position = Camera.transform.position + new Vector3(-30.49f, 0, 0f);
            
        }

        if (collision.tag == "Zone-Right" && rb.velocity.x > 0f)
        {
            Camera.transform.position = Camera.transform.position + new Vector3(30.49f, 0, 0f);
        }
        
        if (collision.tag == "Zone-Top" && rb.velocity.y > 0f)
        {
            Camera.transform.position = Camera.transform.position + new Vector3(0, 16.06f, 0f);
        }

        if (collision.tag == "Zone-Bot" && rb.velocity.y < 0f)
        {
            Camera.transform.position = Camera.transform.position + new Vector3(0, -16.06f, 0f);
        }
        
        

        
    }

   
}
