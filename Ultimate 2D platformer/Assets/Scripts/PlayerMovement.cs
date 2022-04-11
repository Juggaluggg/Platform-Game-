using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    private float dirX = 0;

   [SerializeField] private float moveSpeed = 7f;
   [SerializeField] private float jumpForce = 14f;
   [SerializeField] private LayerMask jumpableGround;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    private enum MovementState { idle, Running,Jumping, Falling}
    
    private void Update()
    {
        // movement across X & Y axis 
         dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);


        //Jumping 
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState State;

        if (dirX > 0f)
        {
            State = MovementState.Running;
            sprite.flipX = false;
        }
        else if (dirX < 0F)
        {
            State = MovementState.Running;
            sprite.flipX = true;
        }
        else
        {
            State = MovementState.idle;

        }

        if(rb.velocity.y > .1f)
        {
            State = MovementState.Jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            State = MovementState.Falling;
        }

        anim.SetInteger("State", (int)State);
    }
    private bool IsGrounded()
    {
     return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}