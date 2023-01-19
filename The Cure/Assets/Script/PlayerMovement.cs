using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer player;
    private int doubleJump = 0;

    private enum MovementState { Idle, Running, Jumping }
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForced;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        MovementState state;

        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveSpeed * dirX, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && doubleJump < 2)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForced);
            doubleJump++;
        }

        if(dirX > 0) 
        {
            state = MovementState.Running;
            player.flipX = false;
        } else if(dirX < 0)
        {
            state = MovementState.Running;
            player.flipX = true;
        } else
        {
            state = MovementState.Idle;
        }

        if(rb.velocity.y > .1f || rb.velocity.y < -.1f)
        {
            state = MovementState.Jumping;
        }

        anim.SetInteger("state", (int)state);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground")){
            doubleJump = 0;
        }
    }

}
