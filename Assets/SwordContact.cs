using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordContact : MonoBehaviour
{
    public int damage = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerV2 player = collision.gameObject.GetComponent<PlayerV2>();

        if (collision.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(damage);
        }
    }
}
