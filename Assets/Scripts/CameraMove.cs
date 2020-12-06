using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    Vector3 position;
    void Update()
    {
        if (player != null)
        {
            position = player.transform.position;
            position.z = -200f;

            transform.position = position;
            transform.rotation = Quaternion.identity;
        }
    }
}
