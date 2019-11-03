using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{

    public GameObject boss;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            boss.SetActive(true);

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            this.gameObject.SetActive(false);
        }
    }
}

