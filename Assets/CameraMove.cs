using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    Vector3 position;
    void Update()
    {
        position = player.transform.position;
        position.z = -15f;

        transform.position = position;
        transform.rotation = Quaternion.identity;
    }
}
