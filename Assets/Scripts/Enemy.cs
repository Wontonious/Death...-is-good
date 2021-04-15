using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 0;

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private bool isAttacking;
    private float timeBtwAttacks;
    public float startTimeBtwAttacks;
    public float attackingDistance = 2f;
    public float attackTimer;
    private float attackLength;

    private Rigidbody2D rb;
    private Animator anim;

    public GameObject wisp; //Wisp enemy drops

    //public GameObject projectile; // For enemies that shoot
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        timeBtwAttacks = startTimeBtwAttacks;
        timeBtwAttacks = 0.2f;

        attackLength = attackTimer;
    }

    void Update()
    {
        if (player != null)
        {
            AnimationPlayer();

            //Enemy Tracking
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }


            //Enemy sprite flip
            if (transform.position.x - player.position.x < 0)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            if (transform.position.x - player.position.x > 0)
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }

            //Enemy Attacking
            if (Vector2.Distance(transform.position, player.position) <= attackingDistance && timeBtwAttacks <= 0)
            {
                //Instantiate(projectile, transform.position, Quaternion.identity); // For enemies with projectiles
                isAttacking = true;
                timeBtwAttacks = startTimeBtwAttacks;
            }
            else if (timeBtwAttacks <= startTimeBtwAttacks && timeBtwAttacks > 0)
            {
                timeBtwAttacks -= Time.deltaTime;
                isAttacking = false;
                
            }
        }
    }
        void AnimationPlayer()
        {
            /*
            Parameters:
            Bool IsAttacking
            Bool IsRunning
            */

        if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
            if (Vector2.Distance(transform.position, player.position) <= attackingDistance)
            {
                anim.SetBool("IsRunning", false);
            }
            else if (Vector2.Distance(transform.position, player.position) > attackingDistance)
            {
                anim.SetBool("IsRunning", true);
            }

            if (isAttacking)
            {
                anim.SetBool("IsAttacking", true);
            }
            if(!isAttacking && attackTimer <= 0)
            {
                anim.SetBool("IsAttacking", false);
            attackTimer = attackLength;
            }
            if (player == null)
            {
                anim.SetBool("IsRunning", false);
            }
        }

public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Instantiate(wisp, transform.position, Quaternion.identity);
    }

    public bool IsAttacking()
    {
        return isAttacking;
    }
}
