using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkeletons : MonoBehaviour
{

    public GameObject skeleton1;
    public GameObject skeleton2;
    public GameObject skeleton3;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            skeleton1.SetActive(true);
            skeleton2.SetActive(true);
            skeleton3.SetActive(true);
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

