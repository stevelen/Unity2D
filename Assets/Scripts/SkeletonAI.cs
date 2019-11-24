using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAI : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public bool isGrounded = true;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    private GameObject wizard;
    private int speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        wizard = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(wizard.transform.position.x >= gameObject.transform.position.x - 5 && wizard.transform.position.x <= gameObject.transform.position.x + 5 && isGrounded && wizard.transform.position.y > gameObject.transform.position.y)
        {
            rigidbody.velocity = new Vector2(0, 4);
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        Vector2 targetPosition = new Vector2(wizard.transform.position.x, gameObject.transform.position.y);
        if (wizard.transform.position.x >= gameObject.transform.position.x - 5 && wizard.transform.position.x <= gameObject.transform.position.x + 5)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);
        }
    }
    
}
