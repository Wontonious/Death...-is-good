using UnityEngine;

public class PlayerV2 : MonoBehaviour
{
    public int health = 0;

    public float moveSpeed = 5f;
    public float rotationSpeed = 1f;
    public Rigidbody2D rb;

    private Vector2 moveDirection;
    private Vector2 mousePos;

    public bool isMoving = false;

    public Camera cam;

    private Animator anim;

    public int coins = 0;

    Vector2 lookDir;
    //Invicibility Frames
    public float invincibilityFrames;
    private float invincibilityLength;
    void Start()
    {
        anim = GetComponent<Animator>();
        invincibilityLength = invincibilityFrames;
        invincibilityFrames = 0f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.contacts[0];
        Enemy badGuy = collision.gameObject.GetComponent<Enemy>();
        if (collision.gameObject.tag == "Enemy")
        {
            rb.MovePosition(contact.normal * 500f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log(lookDir.x);
        ProcessInputs();

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //Invicibility Frames
        if (invincibilityFrames >= 0)
        {
            invincibilityFrames -= Time.deltaTime;
        }
    }
    //Good for physics calculations
    void FixedUpdate()
    {
        Move();
        //Aim();
    }

    void ProcessInputs()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        if (moveDirection.x != 0f || moveDirection.y != 0f)
        {
            isMoving = true;
            anim.SetBool("isRunning", true);
        }

        lookDir = -(mousePos - rb.position);
        if (lookDir.x >= 0)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        if (lookDir.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (moveDirection == Vector2.zero)
        {
            anim.SetBool("isRunning", false);
            transform.position = new Vector3(rb.position.x, rb.position.y, 0);

        }
        if(moveDirection.x == 0f && moveDirection.y == 0f)
        {
            isMoving = false;
        }
    }

    void Move()
    {
        rb.MovePosition(new Vector3(rb.position.x + moveDirection.x * moveSpeed * Time.fixedDeltaTime, rb.position.y + moveDirection.y * moveSpeed * Time.fixedDeltaTime, 100f));
        //rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void Aim()
    {
        lookDir = -(mousePos - rb.position);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    public void TakeDamage(int damage)
    {
        if (invincibilityFrames <= 0)
        {
            health -= damage;
            invincibilityFrames = invincibilityLength;
        }
        
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public bool GetMovement()
    {
        return isMoving;
    }

    public void AddCoin()
    {
        coins++;
    }

    public int WispCount()
    {
        return coins;
    }
}