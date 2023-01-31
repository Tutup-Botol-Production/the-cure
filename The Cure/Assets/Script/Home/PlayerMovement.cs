using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D coll;
    private int doubleJump = 0;
    private float dirX;
    private enum MovementState { Idle, Running, Jumping, Falling }
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForced;
    [SerializeField] private LayerMask ground;
    private bool moveLeft;
    private bool moveRight;
    private bool isGrounded;
    private bool isFacingRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        player = GetComponent<Transform>();
        isFacingRight = true;
    }

    void Update()
    {

        Move();
        UpdateAnimation();
        CekGrounded();
        
        if(isGrounded)
        {
            doubleJump = 0;
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    // Movement Horizontal
    void Move()
    {
        if(moveLeft)
        {
            dirX = -moveSpeed;
        } else if(moveRight)
        {
            dirX = moveSpeed;
        } else
        {
            dirX = 0;
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        player.Rotate(0, 180, 0);
    }

    public void pointerDownLeft()
    {
        moveLeft = true;
        if(isFacingRight)
        {
            Flip();
        }
    }
    public void pointerUpLeft()
    {
        moveLeft = false;
    }
    public void pointerDownRight()
    {
        moveRight = true;
        if(!isFacingRight)
        {
            Flip();
        }
    }
    public void pointerUpRight()
    {
        moveRight = false;
    }

    // Jumping
    public void Jump()
    {
        if(doubleJump < 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForced);
            doubleJump++;
        }
    }

    // Player Animation
    private void UpdateAnimation()
    {
        MovementState state;

        if(dirX > 0)
        {
            state = MovementState.Running;
        } else if(dirX < 0)
        {
            state = MovementState.Running;
        }
        else
        {
            state = MovementState.Idle;
        }

        if(rb.velocity.y > .1f)
        {
            state = MovementState.Jumping;
        } else if(rb.velocity.y < -.1f)
        {
            state = MovementState.Falling;

        }

        anim.SetInteger("state", (int)state);
    }

    void CekGrounded()
    {
        isGrounded = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .01f, ground);
    }

}
