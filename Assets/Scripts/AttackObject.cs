using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObject : MonoBehaviour
{
    public int damage = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            if (collision.gameObject.CompareTag("Enemy"))
            {
                enemy.TakeDamage(damage);
            }
        }
    }

    void Update()
    {
        Destroy(gameObject, 5f);
    }
}
