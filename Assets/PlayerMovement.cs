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
        
        // if (Input.GetKeyDown("ctrl"))
        // {
        //     print("shoot");
        // }

        // if (Input.GetKeyDown("alt"))
        // {
        //     print("jetpack");
        // }
    }

    private void UpdateAnimationState()
    {
        if (dirX > 0f)
        {
            anim.SetBool("Walking", true);
            sprite.flipX = false;
        }

        else if (dirX < 0f)
        {
            anim.SetBool("Walking", true);
            sprite.flipX = true;
        }

        else
        {
            anim.SetBool("Walking", false);
        }
    }
}
