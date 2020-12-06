using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public SpriteRenderer sprite;
    bool occurOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sprite.flipX && occurOnce)
        {
            transform.localPosition = new Vector2(-transform.localPosition.x, transform.localPosition.y);
            occurOnce = false;
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);

        }
        if (!sprite.flipX && !occurOnce)
        {
            transform.localPosition = new Vector2(-transform.localPosition.x, transform.localPosition.y);
                occurOnce = true;
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
    }
}
