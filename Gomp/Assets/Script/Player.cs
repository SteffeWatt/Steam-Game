using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Camera;

    public GameObject playerModel;
    private Rigidbody2D rb;
    private SpriteRenderer rbSprite;
    public Animator rbAnimator;
    private CapsuleCollider2D colider;

    public bool Active = false;
    public int Jumps = 0;
    public bool isMoving = false;
    public bool isGrounded = false;
    public ParticleSystem jumpDust;
    public ParticleSystem runDust;

    
    [SerializeField] private LayerMask groundLayer;
    private float JumpPower = 20f;

    private float cyoteTime = 0.2f;
    private float cyoteCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    private float moveHorizontal;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>();
        rbAnimator = GetComponent<Animator>();
        colider = transform.GetComponent<CapsuleCollider2D>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {

        moveHorizontal = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveHorizontal * 10f, rb.velocity.y);

        Flip();
    }

    // Update is called once per frame
    void Update()
    {

        rbAnimator.SetFloat("speed", Mathf.Abs(moveHorizontal));
        rbAnimator.SetFloat("fallSpeed", rb.velocity.y);
        rbAnimator.SetBool("isGrounded", IsGrounded());



        if (rb.velocity.x > 0.8 || rb.velocity.x < -0.8)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving && isGrounded)
        {
            CreateRunDust();
        }

        if (IsGrounded())
        {
            cyoteCounter = cyoteTime;
        }
        else
        {
            cyoteCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            
            jumpBufferCounter = jumpBufferTime;
        }

        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }


        if (jumpBufferCounter > 0f && cyoteCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpPower);
            CreateJumpDust();
            Active = !Active;
            Jumps++;
            if(Jumps == 4) { Jumps = 0; }

            jumpBufferCounter = 0f;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.35f);
            cyoteCounter = 0f;
        }


        //dessa e bare t testing
        //-------------------------
        if (Input.GetButtonDown("Fire2"))
        {
            rb.AddForce(Vector2.up * -7.5f, ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire3"))
        {
            rb.AddForce(Vector2.up * 7.5f, ForceMode2D.Impulse);
        }       
        //-------------------------


    }

    private bool IsGrounded()
    {
        float height = 0.2f;

        RaycastHit2D hit = Physics2D.BoxCast(colider.bounds.center, colider.bounds.size - new Vector3(0.2f,0.15f,0f), 0f, Vector2.down, height, groundLayer);
        Color ray;
        if (hit.collider != null)
        {
            ray = Color.green;
            isGrounded = true;
        } else
        {
            ray = Color.red;
            isGrounded = false;
        }

        Debug.DrawRay(colider.bounds.center + new Vector3(colider.bounds.extents.x, 0), Vector2.down * (colider.bounds.extents.y + height), ray);
        Debug.DrawRay(colider.bounds.center - new Vector3(colider.bounds.extents.x, 0), Vector2.down * (colider.bounds.extents.y + height), ray);
        Debug.DrawRay(colider.bounds.center - new Vector3(colider.bounds.extents.x, colider.bounds.extents.y + height), Vector2.right * (colider.bounds.extents.x * 2f), ray);

        

        return hit.collider != null;
    }

    private void Flip()
    {
        if (rb.velocity.x > 0f)
        {
            rbSprite.flipX = false;
        }

        if (rb.velocity.x < 0f)
        {
            rbSprite.flipX = true;
        }
    }

    private void CreateJumpDust()
    {
        jumpDust.Play();
    }

    private void CreateRunDust()
    {
        runDust.Play();
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
            Camera.transform.position = Camera.transform.position + new Vector3(0, 17.8f, 0f);
        }

        if (collision.tag == "Zone-Bot" && rb.velocity.y < 0f)
        {
            Camera.transform.position = Camera.transform.position + new Vector3(0, -17.8f, 0f);
        }

        //safe checks incase player goes outside of camera zone, this also fixes issue when player is on moving platform

        if (collision.tag == "Safe-Left")
        {
            Camera.transform.position = Camera.transform.position + new Vector3(-30.49f, 0, 0f);
        }

        if (collision.tag == "Safe-Right")
        {
            Camera.transform.position = Camera.transform.position + new Vector3(30.49f, 0, 0f);
        }


        if (collision.tag == "Safe-Top")
        {
            Camera.transform.position = Camera.transform.position + new Vector3(0, 17.8f, 0f);
        }

        if (collision.tag == "Safe-Bot")
        {
            Camera.transform.position = Camera.transform.position + new Vector3(0, -17.8f, 0f);
        }



    }


}
