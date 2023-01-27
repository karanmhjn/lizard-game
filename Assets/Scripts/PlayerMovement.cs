
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    private float dirY = 0f;
    [SerializeField] private float JumpSpeed = 7f;
    [SerializeField] private float MoveSpeed = 5f;
    private bool jetMode = false;

    private enum MovementState {idle, walking, jumping, jet}
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        MovementState state = MovementState.idle;

        // Player Movement
        ControlMovement();

        // Jetpack Gravity controls
        if (Input.GetButtonDown("Fire2"))
        {
            if (jetMode == false)
            {
                // Do Jetpack movement`
                jetMode = true;
                rb.gravityScale = 0f;
            }
            else
            {
                // Stop Jetpack movement
                jetMode = false;
                rb.gravityScale = 1f;
            }
        }

        // Update Animation for Dave
        UpdateAnimationState(state, jetMode);
    }

    // Manages Player Movement
    private void ControlMovement()
    {
        // Horizontal Movement
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(MoveSpeed * dirX, rb.velocity.y);

        // Vertical Movement (Only works when JetPack is on)
        dirY = Input.GetAxis("Vertical");
        if (jetMode)
        {
            rb.velocity = new Vector2(rb.velocity.x, MoveSpeed * dirY);
        }

        // Jumping Movement
        if (Input.GetButtonDown("Jump") && IsGrounded() && !jetMode)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
        }
    }

    // Updates Animation for Dave
    private void UpdateAnimationState(MovementState state, bool jetMode)
    {
        // Walking Conditions
        if (dirX > 0f)
        {
            state = MovementState.walking;
            sprite.flipX = false;
        }

        else if (dirX < 0f)
        {
            state = MovementState.walking;
            sprite.flipX = true;
        }

        // Idle Conditions
        else
        {
            state = MovementState.idle;
        }

        // Jumping Conditions
        if (Mathf.Abs(rb.velocity.y) > 0.01f)
        {
            state = MovementState.jumping;
        }
        // Jet Conditions
        if (jetMode == true)
        {
            state = MovementState.jet;
        }

        // Set the correct state of Dave for the frame into animation
        anim.SetInteger("state", (int)state);
    }

    // Checks whether Dave is on the ground
    private bool IsGrounded()
    {
        // Creates a small box that is slightly below the collision box, and returns true when it goes inside any object in terrain layer.
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
