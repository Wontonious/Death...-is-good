﻿using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 0;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
