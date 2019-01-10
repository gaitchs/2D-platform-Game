using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public float jumpPower = 20f;
    public Transform groundCheck;
    private bool onGround;
    public float groundCheckRadius = 0.1f;
    public LayerMask ground;
    private float moveInput;
    public float speed = 10f;
    private bool facingRight = true;
    public bool jumped;
    public Joystick joystick;
    public AudioClip audioJumpClip;
    private AudioSource audioSource;
    private bool cansecondjump;



    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {


        MoveScript();
        CheckFacing();


    }



    void MoveScript()
    {
        //checks for ground
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);
        

        //movement horizontal x axis
        // moveInput = Input.GetAxis("Horizontal"); //store input axis to a moveInput variable to use later


        if (joystick.Horizontal >= 0.2f || joystick.Horizontal <= -0.2f)
        {
            moveInput = joystick.Horizontal;
            
          
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);  //makes the input the new velocity 
        }


        if ( Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2( moveInput* speed, rb.velocity.y);

        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();

        }




    }


    void CheckFacing()
    {

        if (facingRight == false && moveInput > 0)// when not facing right and input is right 
        {
            flip();


        }
        else if (facingRight == true && moveInput < 0)// when facing right and input is left
        {
            flip();


        }
    }



    void flip()
    {
        facingRight = !facingRight;//when function run change variable
        Vector2 Scale = transform.localScale;
        Scale.x *= -1; //do the flip
        transform.localScale = Scale;

    }



    public void Jump()
    {

        if (onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            audioSource.PlayOneShot(audioJumpClip);
            cansecondjump = true;
        }


        if (!onGround && cansecondjump)
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpPower);
            audioSource.PlayOneShot(audioJumpClip);
            cansecondjump = false;
        }

    }





    

}
