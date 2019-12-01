using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBolt : MonoBehaviour
{

    public float moveSpeed = 20f;
    private Transform target;
    private Animator animator;
    private float animLength;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = gameObject.GetComponent<Animator>();
        animLength = GetAnimationClipLength(animator, 0);
        GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioManager>().PlaySound("EnemyBolt");

    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        Destroy(gameObject, animLength);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    float GetAnimationClipLength(Animator animator, int clipIndex)
    {
        return animator.runtimeAnimatorController.animationClips[clipIndex].length;
    }

}