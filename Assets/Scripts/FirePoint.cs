using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    bool occurOnce = false;
    Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Verrtical");
        if (moveDirection.x < 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 270f);
        }
        if (moveDirection.x > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 90f);
        }
    }
}
