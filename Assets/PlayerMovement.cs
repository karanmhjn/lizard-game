using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float JumpForce = 7f;
    public float MoveSpeed = 5f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(MoveSpeed * dirX, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x,JumpForce);
        }

        // if (Input.GetKeyDown("ctrl"))
        // {
        //     print("shoot");
        // }

        // if (Input.GetKeyDown("alt"))
        // {
        //     print("jetpack");
        // }

    }
}
