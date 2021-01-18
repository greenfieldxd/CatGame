using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] Transform effectPosition;
    [SerializeField] GameObject effect;
    [SerializeField] private AudioSource audio;

    private Rigidbody2D playerBody;
    private BoxCollider2D boxCollider2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private string sideCheck;
    private bool frictionCheck;


    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
        sideCheck = "";
    }

    void Update()
    {
        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {

            playerBody.velocity = Vector2.up * jumpForce;
            animator.SetTrigger("JumpTrigger");
            audio.Play();
        }

        HandleMovement();

    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 0.1f, groundLayerMask);
        return raycastHit.collider != null;
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            playerBody.velocity = new Vector2(-moveSpeed, playerBody.velocity.y);
            animator.SetFloat("InputHorizontal", (Mathf.Abs(playerBody.velocity.x)));
            spriteRenderer.flipX = playerBody.velocity.x < 0;
            sideCheck = "left";
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                playerBody.velocity = new Vector2(+moveSpeed, playerBody.velocity.y);
                animator.SetFloat("InputHorizontal", (Mathf.Abs(playerBody.velocity.x)));
                spriteRenderer.flipX = playerBody.velocity.x < 0;
                sideCheck = "right";
            }
            else
            {
                if (frictionCheck)
                {
                    if (sideCheck.Equals("right"))
                    {
                        playerBody.velocity = new Vector2(+moveSpeed, playerBody.velocity.y);
                    }
                    if (sideCheck.Equals("left"))
                    {
                        playerBody.velocity = new Vector2(-moveSpeed, playerBody.velocity.y);
                    }
                } else playerBody.velocity = new Vector2(0, playerBody.velocity.y);
                animator.SetFloat("InputHorizontal", (Mathf.Abs(playerBody.velocity.x)));
            }
        }
        
    }
    public void PlayEffect()
    {
        Instantiate(effect, effectPosition);
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.friction == 0)
        {
            frictionCheck = false;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.friction == 0)
        {
            frictionCheck = true;
        }

        playerBody.transform.SetParent(collision.transform);
    }

}
