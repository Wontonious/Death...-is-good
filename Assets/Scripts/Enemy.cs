using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 0;

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwAttacks;
    public float startTimeBtwAttacks;
    //private Animator anim;

    //public GameObject projectile; // For enemies that shoot
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwAttacks = startTimeBtwAttacks;
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (player != null)
        {
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

            if (timeBtwAttacks <= 0)
            {
                //Instantiate(projectile, transform.position, Quaternion.identity); // For enemies with projectiles
                //anim.SetBool("IsAttacking", true);
            }
            else
            {
                timeBtwAttacks -= Time.deltaTime;
                //anim.SetBool("IsAttacking", false);
            }
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

}
