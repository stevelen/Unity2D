using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPumpkin : MonoBehaviour
{
    private GameObject player;
    private float maxspeed;
    private float jumpForce;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "magicBolt")
        {
            gameObject.SetActive(false);
            player.GetComponent<MovementController>().maxSpeed += 1;
            GameObject.
                FindGameObjectWithTag("GameController").
                    GetComponent<UpgradeManager>().
                        addSpeed(1);
        }
        if(collision.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
        if(collision.gameObject.tag == "Special")
        {
            gameObject.SetActive(false);
            player.GetComponent<MovementController>().jumpForce += 1;
            GameObject.
                FindGameObjectWithTag("GameController").
                    GetComponent<UpgradeManager>().
                        addJump(1);

        }
    }
}
