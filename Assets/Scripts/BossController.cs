using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject pumpkins;
    public GameObject trophy;
    private GameObject BossCeiling;
    public GameObject DeathBolt;
    public GameObject FirePoint;
    public float maxHealth = 5f;
    public float currentHealth;
    public float maxSpeed = 5f;
    public float currentSpeed;
    private Rigidbody2D rigidbody;
    private float nextFire;
    private float fireRate;


    private void OnEnable()
    {
        BossCeiling = GameObject.FindGameObjectWithTag("BossCeiling");
        currentHealth = maxHealth;
        currentSpeed = maxSpeed;
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        fireRate = 2f;
        nextFire = Time.time;



    }

    private void FixedUpdate()
    {
        if (gameObject.activeSelf)
        {
            this.rigidbody.velocity = new Vector2(-currentSpeed, this.rigidbody.velocity.y);
            
        }
    }

    private void Update()
    {
        CheckIfTimeToFire();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pillar" || collision.gameObject.tag == "Moveable")
        {
            flip();
        }

        if (collision.gameObject.tag == "magicBolt" || collision.gameObject.tag == "Special" || collision.gameObject.tag == "Pumpkin")
        {
            currentHealth -= 1f;
            if (currentHealth == 0f)
            {
                this.gameObject.SetActive(false);
                BossCeiling.SetActive(false);
                trophy.SetActive(true);
                pumpkins.SetActive(true);
                currentHealth = maxHealth;
            }
            if (collision.gameObject.tag == "magicBolt")
            {
                collision.gameObject.SetActive(false);
            }

        }
    }

    void CheckIfTimeToFire()
    {
        
        if (Time.time > nextFire)
        {
            Instantiate(DeathBolt, FirePoint.transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }

    }



    public void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        this.currentSpeed *= -1;
        transform.localScale = theScale;
    }
}

