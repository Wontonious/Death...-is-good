using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            if (other.CompareTag("Player"))
            {
                PlayerV2 player = other.gameObject.GetComponent<PlayerV2>();
                player.AddCoin();
                Destroy(gameObject);

            }
        }
    }

}
