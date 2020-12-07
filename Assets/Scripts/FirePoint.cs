using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    Vector2 moveDirection;

    // Update is called once per frame
    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        if (moveDirection.x < 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 90f);
        }
        if (moveDirection.x > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 270f);
        }
    }
}
