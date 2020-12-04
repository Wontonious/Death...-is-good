using UnityEngine;

public class PlayerV2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 1f;
    public Rigidbody2D rb;

    private Vector2 moveDirection;
    private Vector2 mousePos;

    public Camera cam;


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
        ProcessInputs();

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    //Good for physics calculations
    void FixedUpdate()
    {
        Move();
        Aim();
    }

    void ProcessInputs()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
    }

    void Move()
    {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void Aim()
    {
        Vector2 lookDir = -(mousePos - rb.position);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

}