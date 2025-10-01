using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float MovementSpeed = 5f;
    public float JumpForce = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Jump
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        // Set X velocity directly, keep Y from physics
        rb.velocity = new Vector2(move * MovementSpeed, rb.velocity.y);
    }
}
