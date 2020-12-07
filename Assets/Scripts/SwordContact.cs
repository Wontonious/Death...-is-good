using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordContact : MonoBehaviour
{
    public int damage = 0;
    public Enemy enemy;
    private PolygonCollider2D collider;
    private Animator anim;
    void Start()
    {
        collider = GetComponent<PolygonCollider2D>();
        collider.enabled = false;
        enemy = gameObject.GetComponentInParent<Enemy>();
        anim = gameObject.GetComponentInParent<Animator>();
    }

    void Update()
    {
        if (enemy.IsAttacking())
        {
            collider.enabled = true;
            Debug.Log("YES");
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            collider.enabled = false;
            Debug.Log("NO");
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
