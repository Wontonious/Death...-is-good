using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordContact : MonoBehaviour
{
    public int damage = 0;
    private Enemy enemy;
    private PolygonCollider2D pCollider;
    private Animator anim;

    public float knockbackStrength;

    [SerializeField] private float delay = 1.5f;
    private float delayOrigin;
    void Start()
    {
        pCollider = GetComponent<PolygonCollider2D>();
        pCollider.enabled = false;
        enemy = gameObject.GetComponentInParent<Enemy>();
        anim = gameObject.GetComponentInParent<Animator>();

        delayOrigin = delay;
    }

    void Update()
    {
        //Debug.Log(enemy.IsAttacking());
        if (enemy.IsAttacking())
        {
            pCollider.enabled = true;
        }

        if(delay <= delayOrigin)
        {
            delay -= Time.deltaTime;
        }
        if(!enemy.IsAttacking() && delay <= 0)
        {
            pCollider.enabled = false;
            delay = delayOrigin;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerV2 player = collision.gameObject.GetComponent<PlayerV2>();

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("BAM");
            player.TakeDamage(damage);

            Vector3 direction = collision.transform.position - transform.position;

            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            rb.AddForce(direction.normalized * knockbackStrength, ForceMode2D.Impulse);
        }
    }

}
