using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    private Vector3 startPos;
    private Quaternion startRot;
    private bool startActive;
    
    protected virtual void Start()
    {
        GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<RespawnController>()
                .register(this);
        startPos = transform.position;
        startRot = transform.rotation;
        startActive = gameObject.activeSelf;
    }

    public virtual void respawn()
    {
        transform.position = startPos;
        transform.rotation = startRot;
        gameObject.SetActive(startActive);
    }
}
