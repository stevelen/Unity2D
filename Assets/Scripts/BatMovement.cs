using UnityEngine;
using System.Collections;

public class BatMovement : MonoBehaviour
{

    public float speed = 10f;
    private Transform target;
    private Vector2 startPos;
    private Animator animator;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = gameObject.GetComponent<Animator>();
        startPos = gameObject.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < 7f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            //gameObject.GetComponent<Rigidbody2D>().velocity = (target.position - transform.position) * speed; //alternative
            if (transform.position.x > target.position.x)
            {
                animator.SetBool("facingRight", false);
                animator.SetBool("facingLeft", true);
            }
            else
            {
                animator.SetBool("facingRight", true);
                animator.SetBool("facingLeft", false);
            }
        } else
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
            if (transform.position.x > startPos.x)
            {
                animator.SetBool("facingRight", false);
                animator.SetBool("facingLeft", true);
            }
            else
            {
                animator.SetBool("facingRight", true);
                animator.SetBool("facingLeft", false);
            }
            if (transform.position.x == startPos.x)
            {
                animator.SetBool("facingRight", false);
                animator.SetBool("facingLeft", false);
            }
        }
        
    }
}
