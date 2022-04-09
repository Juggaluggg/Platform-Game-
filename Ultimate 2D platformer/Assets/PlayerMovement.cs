using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        // movement across X & Y axis 
        float dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * 7f, rb.velocity.y);


        //Jumping 
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 14f);
        }
    }
}