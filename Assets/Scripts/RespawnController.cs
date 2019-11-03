using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    private List<Respawner> respawnableObjects;

    // Start is called before the first frame update
    void Awake()
    {
        respawnableObjects = new List<Respawner>();
    }

    public void register(Respawner x)
    {
        respawnableObjects.Add(x);
    }

    public void respawn()
    {
        foreach(Respawner x in respawnableObjects)
        {
            x.respawn();
        }
    }
}
