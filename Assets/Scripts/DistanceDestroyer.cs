using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDestroyer : MonoBehaviour
{
    public float MaxDistance = 10;
    private GameObject player;
    private Vector3 playerPos;

    // Start is called before the first frame update
    void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = GetComponent<Transform>().position;
        playerPos = player.GetComponent<Transform>().position;
        Vector3 movement = currentPos - playerPos;
        float distance = movement.magnitude;

        if(distance > MaxDistance)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
}
