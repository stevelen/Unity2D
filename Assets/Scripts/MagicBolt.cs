using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBolt : MonoBehaviour
{
    public GameObject magicBoltProto;
    public Transform tipOfStaff;
    public float speed = 10.0f;

    public float cooldownTime = 1.0f;
    public float coolDown = 0;


    Transform tr;

    public int manaPoolSize = 20;
    private GameObject[] manaPool;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        animator = GetComponent<Animator>();

        manaPool = new GameObject[manaPoolSize];
        for (int i = 0; i < manaPoolSize; i++)
        {
            GameObject newMagicBolt = Instantiate(magicBoltProto);
            newMagicBolt.SetActive(false);
            manaPool[i] = newMagicBolt;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (coolDown <= 0)
            {
                Fire();
                coolDown = cooldownTime;
            }
        }

        if (coolDown > 0)
        {
            
            coolDown -= Time.deltaTime;
        }
    }

    public void Fire()
    {
        GameObject newMagicBolt = getInactiveMagicBolt();
        if (newMagicBolt == null)
        {
            Debug.Log("OutOfMana!");
            return;
        }

        animator.SetTrigger("magicBolt");

        newMagicBolt.GetComponent<Transform>().position = tipOfStaff.position;

        newMagicBolt.SetActive(true);
        
        Vector3 shootDirection;


        shootDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - tipOfStaff.position;
        shootDirection.Normalize();


        newMagicBolt.GetComponent<Rigidbody2D>().velocity = shootDirection * speed;
        if(transform.position.x < Camera.main.ScreenToWorldPoint(Input.mousePosition).x && !MovementController.facingRight)
        {
            gameObject.GetComponent<MovementController>().flip();
        }
        if (transform.position.x > Camera.main.ScreenToWorldPoint(Input.mousePosition).x && MovementController.facingRight)
        {
            gameObject.GetComponent<MovementController>().flip();
        }

    }

    GameObject getInactiveMagicBolt()
    {
        for (int i = 0; i < manaPoolSize; i++)
        {
            if (manaPool[i].activeSelf == false)
            {
                return manaPool[i];
            }
        }

        return null;
    }

}

