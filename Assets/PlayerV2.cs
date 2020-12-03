using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerV2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float maxSpeed = 20f;

    GroundCheck grounded;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        grounded = GetComponent<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void FixedUpdate()
    {
        ProcessInputs();
    }

    void ProcessInputs()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            sprite.flipX = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            sprite.flipX = true;
        }

        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    void Move()
    {
        rb.AddForce(Vector2.right *moveDirection * moveSpeed);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && grounded.IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
