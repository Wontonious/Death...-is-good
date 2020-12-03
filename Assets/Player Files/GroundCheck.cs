using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded = false;
    /*
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isGrounded = true;
        }
    }
    */
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isGrounded = false;
        }
    }
    

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isGrounded = true;
        }
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}
