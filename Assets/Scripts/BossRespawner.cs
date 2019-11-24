using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossRespawner : Respawner
{
    private BossController bossController;
    private float currentHealth;
    private float maxHealth;
    public Image healthbar;
    public GameObject bossSpawner;
    protected override void Start()
    {
        base.Start();
        bossController = gameObject.GetComponent<BossController>();
        maxHealth = bossController.maxHealth;

    }

    public override void respawn()
    {
        base.respawn();
        bossController.currentHealth = maxHealth;
        healthbar.fillAmount = 1;
        bossSpawner.SetActive(true);

    }
}
