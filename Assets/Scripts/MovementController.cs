using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    
    public float maxSpeed = 2f;
    public float jumpForce = 2f;

    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public bool isGrounded = true;
    private Animator animator;
    public GameObject bossHealthbar;

    public static bool facingRight = true;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        this.rigidbody.velocity = new Vector2(move * maxSpeed, this.rigidbody.velocity.y);

        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }


        if (Input.GetButton("Jump") && isGrounded)
        {
            rigidbody.velocity = new Vector2(0, jumpForce);

        }

        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        animator.SetFloat("speed", rigidbody.velocity.magnitude);

        if (!isGrounded)
        {
            
            animator.SetBool("isJumping", true);
        }

        if (isGrounded)
        {
            animator.SetBool("isJumping", false);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Special" || collision.gameObject.tag == "FireBall")
        {
            GameObject
                .FindGameObjectWithTag("GameController")
                    .GetComponent<RespawnController>()
                        .respawn();
            bossHealthbar.SetActive(false);
        }

        if (collision.gameObject.tag == "Trophy")
        {
            collision.gameObject.SetActive(false);
            Debug.Log("You won!");
            GameObject
                .FindGameObjectWithTag("GameController")
                    .GetComponent<RespawnController>()
                        .respawn();
            bossHealthbar.SetActive(false);
        }
        

    }

    public void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
