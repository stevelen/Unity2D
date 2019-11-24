using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeath : MonoBehaviour
{
    public float maxHealth;
    private float r = 1f;
    public float g = 1f;
    public float b = 1f;
    private float a = 1f;
    public float currentHealth;
    public SpriteRenderer spriterenderer;

    public Image healthBar = null;


    private void OnEnable()
    {
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
        maxHealth = Mathf.Floor(transform.localScale.x);
        currentHealth = maxHealth;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="magicBolt" || collision.gameObject.tag == "Special" || collision.gameObject.tag == "Pumpkin")
        {
            currentHealth -= 1f;
            if(currentHealth == 0f)
            {
                this.gameObject.SetActive(false);
                currentHealth = maxHealth;
                if(healthBar != null)
                {
                    healthBar.fillAmount = currentHealth / maxHealth;
                }
                
                spriterenderer.color = new Color(1f, 1f, 1f, 1f);
            } else
            {
                g = currentHealth/maxHealth;
                b = currentHealth / maxHealth;
                spriterenderer.color = new Color(r, g, b, a);
                if (healthBar != null)
                {
                    healthBar.fillAmount = currentHealth / maxHealth;
                }
            }
            if(collision.gameObject.tag == "magicBolt")
            {
                collision.gameObject.SetActive(false);
            }
            
        }
    }
}
