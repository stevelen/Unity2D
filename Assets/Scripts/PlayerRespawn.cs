using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : Respawner
{
    private MovementController movement;
    private float maxSpeed;
    private float jumpForce;
    protected override void Start()
    {
        base.Start();
        movement = gameObject.GetComponent<MovementController>();
        maxSpeed = movement.maxSpeed;
        jumpForce = movement.jumpForce;

    }

    public override void respawn()
    {
        base.respawn();
        movement.maxSpeed = maxSpeed;
        movement.jumpForce = jumpForce;
    }
}
