using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoodlerBehavior : MonoBehaviour
{
    public float jumpForce = 4f;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground") 
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            isGrounded = false;
        }
    }
}
