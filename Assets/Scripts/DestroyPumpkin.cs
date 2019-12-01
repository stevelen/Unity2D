using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPumpkin : MonoBehaviour
{
    private GameObject player;
    private float maxspeed;
    private float jumpForce;
    private GameObject GameManager;

    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameController");
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "magicBolt")
        {
            if (PlayerPrefs.HasKey("GotFirstUpgrade"))
            {
                if (PlayerPrefs.GetInt("GotFirstUpgrade") == 0)
                {
                    GameManager.GetComponent<achiPopup>().setSprite2();
                    GameManager.GetComponent<achiPopup>().popup();
                    PlayerPrefs.SetInt("GotFirstUpgrade", 1);
                    Debug.Log("first upgrade acquired");
                }
            }

            gameObject.SetActive(false);
            player.GetComponent<MovementController>().maxSpeed += 1;
            GameObject.
                FindGameObjectWithTag("GameController").
                    GetComponent<UpgradeManager>().
                        addSpeed(1);
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioManager>().PlaySound("Upgrade");
        }
        if(collision.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
        if(collision.gameObject.tag == "Special")
        {
            if (PlayerPrefs.HasKey("GotFirstUpgrade"))
            {
                if (PlayerPrefs.GetInt("GotFirstUpgrade") == 0)
                {
                    GameManager.GetComponent<achiPopup>().setSprite2();
                    GameManager.GetComponent<achiPopup>().popup();
                    PlayerPrefs.SetInt("GotFirstUpgrade", 1);
                    Debug.Log("first upgrade acquired");
                }
            }
            gameObject.SetActive(false);
            player.GetComponent<MovementController>().jumpForce += 1;
            GameObject.
                FindGameObjectWithTag("GameController").
                    GetComponent<UpgradeManager>().
                        addJump(1);
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioManager>().PlaySound("Upgrade");

        }
    }
}
