using UnityEngine;

public class Player : MonoBehaviour
{
    //Sugar and spice and everything that has to do with movement
    public float moveSpeed = 20f;
    private float movingSpeed;
    public float counterSpeed = 4f;
    public float maxSpeed = 50f;
    Vector2 gravityForceDirection;
    Vector3 moveDirection;
    Vector2 counterMove;

    //Jumping
    public float jumpDivide = 1.5f;
    public float jumpForce = 25f;
    public float gravity = -9.81f;
    private bool occurOnce = false;
    public bool isGrounded = false;

    //Player health
    float playerHealth = 50f;

    //Misc 
    public Rigidbody2D rb;
    //public Animator anim;
    public SpriteRenderer sprite;
    GroundCheck grounded;

    void Start()
    {
        movingSpeed = moveSpeed;
        grounded = GetComponent<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {

        Jump();

        
        if (rb.velocity.y > 0)
        {
            rb.AddForce(Vector2.up * gravity * 0.75f * Time.deltaTime);
        }
        
        gravityForceDirection.y += gravity * Time.deltaTime;
        if (grounded.IsGrounded())
        {
            gravityForceDirection.y = -2f;
        }

    }

    private void FixedUpdate()
    {
        ProcessInputs();


        //anim.SetFloat("MoveSpeed", Mathf.Abs(moveDirection.x));

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        //CounterMoves();
        Move();

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && (grounded.IsGrounded()))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    void ProcessInputs()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        transform.position += moveDirection * moveSpeed * Time.fixedDeltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            sprite.flipX = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            sprite.flipX = true;
        }

        if (grounded.IsGrounded())
        {
            moveDirection.y = -2f;
            moveSpeed = movingSpeed;
            occurOnce = true;
        }

        if ((!grounded.IsGrounded()) && occurOnce)
        {
            rb.AddForce(Vector2.down * gravity * Time.deltaTime);
            occurOnce = false;
            moveSpeed = moveSpeed / jumpDivide;
        }
    }

    void CounterMoves()
    {
        if (rb.velocity.x > 0)
        {
            counterMove.x = -counterSpeed;
        }
        if (rb.velocity.x < 0)
        {
            counterMove.x = counterSpeed;
        }
        rb.AddForce(counterMove * Time.deltaTime);
    }

    void Move()
    {
        rb.AddForce(gravityForceDirection);
    }


    void TakeDamage(float damage)
    {
        playerHealth -= damage;
        Debug.Log(playerHealth);
        if (playerHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("You died");
        Destroy(gameObject);
    }

}