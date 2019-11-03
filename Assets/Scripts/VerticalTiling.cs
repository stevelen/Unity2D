using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]

public class VerticalTiling : MonoBehaviour
{


    public int offsetY = 2;
    public bool hasAnUpperBuddy = false;

    public bool reverseScale = false;   

    private float spriteHeight = 0f;
    private Camera cam;
    private Transform myTransform;

    void Awake()
    {
        cam = Camera.main;
        myTransform = transform;
    }

    void Start()
    {
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
        spriteHeight = sRenderer.sprite.bounds.size.y;
    }

    void Update()
    {

        if (!hasAnUpperBuddy)
        {

            float camVerticalExtend = cam.orthographicSize;


            float edgeVisiblePosition = (myTransform.position.y + spriteHeight / 2) - camVerticalExtend;


            if (cam.transform.position.y >= edgeVisiblePosition - offsetY && !hasAnUpperBuddy)
            {
                makeNewBuddy();
                hasAnUpperBuddy = true;
            }
        }
    }

    void makeNewBuddy()
    {

        Vector3 newPosition = new Vector3(myTransform.position.x, myTransform.position.y + spriteHeight, myTransform.position.z);

        Transform newBuddy = Instantiate(myTransform, newPosition, myTransform.rotation) as Transform;

        if (reverseScale == true)
        {
            newBuddy.localScale = new Vector3(newBuddy.localScale.x, newBuddy.localScale.y *-1, newBuddy.localScale.z);
        }

        newBuddy.parent = myTransform.parent;
        newBuddy.GetComponent<VerticalTiling>().hasAnUpperBuddy = false;
    }
}
