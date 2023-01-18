using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float JumpForce = 7f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // if (Input.GetKeyDown("space"))
        // {
        //     rb.velocity = new Vector2(rb.velocity.x,JumpForce);
        // }

        if (Input.GetButton("Jump"))
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
