
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    Vector2 moveDirection;
    private Vector2 mousePos;
    Quaternion rotation;

    public Camera cam;
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePos);
    }

    void FixedUpdate()
    {
        Aim();
    }

    void Aim()
    {
        Vector2 aimDir = mousePos - rb.position;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        rotation.eulerAngles = new Vector3(0, 0, -angle - 90);
        transform.rotation = rotation;
    }
}
