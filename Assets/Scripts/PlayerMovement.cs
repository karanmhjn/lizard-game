using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private float dirX = 0f;
    [SerializeField] private float JumpSpeed = 7f;
    [SerializeField] private float MoveSpeed = 5f;

    private enum MovementState {idle, walking, jumping}
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(MoveSpeed * dirX, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x,JumpSpeed);
        }

        UpdateAnimationState();
        
    }

    private void UpdateAnimationState()
    {
        MovementState state;
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

        else
        {
            state = MovementState.idle;
        }

        if (Mathf.Abs(rb.velocity.y) > 0.01f)
        {
            state = MovementState.jumping;
        }

        anim.SetInteger("state", (int)state);
    }
}
