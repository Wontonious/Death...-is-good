using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordContact : MonoBehaviour
{
    public int damage = 0;
    public Enemy enemy;
    private PolygonCollider2D pCollider;
    private Animator anim;
    void Start()
    {
        pCollider = GetComponent<PolygonCollider2D>();
        pCollider.enabled = false;
        enemy = gameObject.GetComponentInParent<Enemy>();
        anim = gameObject.GetComponentInParent<Animator>();
    }

    void Update()
    {
        if (enemy.IsAttacking())
        {
            pCollider.enabled = true;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            pCollider.enabled = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerV2 player = collision.gameObject.GetComponent<PlayerV2>();

        if (collision.gameObject.CompareTag("Player") && enemy.IsAttacking())
        {
            player.TakeDamage(damage);
        }
    }

}
