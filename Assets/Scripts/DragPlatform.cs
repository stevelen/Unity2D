using UnityEngine;
using System.Collections;


public class DragPlatform : MonoBehaviour
{
    private Vector3 offset;
    private bool empty = true;
    private Animator animator;
    private GameObject player;
    private SpriteRenderer spriterenderer;
    private Color originalColor;
    private Color newColor;
    public bool isDragging = false;

    public Texture2D originalCursor;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
        originalColor = spriterenderer.color;
        newColor = new Color(0.79f, 0.37f, 0.34f);



    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(originalCursor, hotSpot, cursorMode);
    }

    void OnMouseDown()
    {

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 6.31f));
        isDragging = true;
        if(gameObject.tag == "Moveable")
        {
            spriterenderer.color = newColor;
        }
        

    }



    void OnMouseDrag()
    {
        if (empty)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 6.31f);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
            animator.SetTrigger("leviTrigger");
            animator.SetBool("isDoingMagic", true);
            if (player.transform.position.x > transform.position.x && MovementController.facingRight)
            {
                player.GetComponent<MovementController>().flip();
            }
            if (player.transform.position.x < transform.position.x && !MovementController.facingRight)
            {
                player.GetComponent<MovementController>().flip();
            }
            if (Input.GetButtonDown("Fire3")){
                gameObject.transform.Rotate(0f, 0f, 90f);
            }
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        } else
        {
            player.GetComponent<MovementController>().isGrounded = false;
        }
    }

    private void OnMouseUp()
    {
        animator.SetBool("isDoingMagic", false);
        isDragging = false;
        if (gameObject.tag == "Moveable")
        {
            spriterenderer.color = originalColor;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            empty = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            empty = true;
        }
    }

}