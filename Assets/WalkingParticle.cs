using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingParticle : MonoBehaviour
{
    //public GameObject particleSystem;
    PlayerV2 playerV2;

    // Start is called before the first frame update
    void Start()
    {
        playerV2 = gameObject.GetComponentInParent<PlayerV2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerV2.GetMovement())
        {
            //Instantiate(particleSystem, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
