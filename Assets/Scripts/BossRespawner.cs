using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRespawner : Respawner
{
    private BossController bossController;
    private float currentHealth;
    private float maxHealth;
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
    }
}
