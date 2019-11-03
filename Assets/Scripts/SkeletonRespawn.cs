using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonRespawn : Respawner
{
    private EnemyDeath enemyDeath;
    private float currentHealth;
    private float maxHealth;
    protected override void Start()
    {
        base.Start();
        enemyDeath = gameObject.GetComponent<EnemyDeath>();
        maxHealth = enemyDeath.maxHealth;

    }

    public override void respawn()
    {
        base.respawn();
        enemyDeath.currentHealth = maxHealth;
        enemyDeath.spriterenderer.color = new Color(1f, 1f, 1f, 1f);
        enemyDeath.g = 1f;
        enemyDeath.b = 1f;
    }
}
