using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 0;

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private bool isAttacking;
    private float timeBtwAttacks = 0f;
    public float startTimeBtwAttacks = 4f;
    public float attackingDistance = 2f;

    private Rigidbody2D rb;
    private Animator anim;
    //private Animator anim;

    //public GameObject projectile; // For enemies that shoot
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player != null)
        {
            AnimationPlayer();

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

            if (Vector2.Distance(transform.position, player.position) > attackingDistance)
            {
                anim.SetBool("IsRunning", true);
            }

            if (transform.position.x - player.position.x < 0)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            if (transform.position.x - player.position.x > 0)
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }


            if (Vector2.Distance(transform.position, player.position) < 0)
            {
                //transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
            if (Vector2.Distance(transform.position, player.position) > 0)
            {
                //transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            
            if (Vector2.Distance(transform.position, player.position) <= attackingDistance && timeBtwAttacks <= 0)
            {
                //Instantiate(projectile, transform.position, Quaternion.identity); // For enemies with projectiles
                isAttacking = true;
                //anim.SetBool("IsAttacking", true);
                timeBtwAttacks = startTimeBtwAttacks;
            }
            else
            {
                Debug.Log(timeBtwAttacks);
                timeBtwAttacks -= Time.deltaTime;
                isAttacking = false;
                //anim.SetBool("IsAttacking", false);
            }
            
        }

        void AnimationPlayer()
        {
            /*
            Parameters:
            Bool IsAttacking
            Bool IsRunning
            */
            if(Vector2.Distance(transform.position, player.position) <= attackingDistance)
            {
                anim.SetBool("IsRunning", false);
            } else if(Vector2.Distance(transform.position, player.position) > attackingDistance)
            {
                anim.SetBool("IsRunning", true);
            }

            if(Vector2.Distance(transform.position, player.position) <= attackingDistance && timeBtwAttacks <= 0)
            {
                anim.SetBool("IsAttacking", true);
            }
            else
            {
                anim.SetBool("IsAttacking", false);
            }
        }
        if (player == null)
        {
            anim.SetBool("IsRunning", false);
        }
    }
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

    public bool IsAttacking()
    {
        return isAttacking;
    }
}
