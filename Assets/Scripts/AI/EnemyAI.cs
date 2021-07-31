using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    enum States
    {
        Idle,
        Chase,
        Attack,
        Death
    }

    States currentState;

    EnemyStats myStats;

    public GameObject player;

    public float chaseRange;
    public float attackRange;
    public float attackCooldown;
    
    float countdown;

    // Start is called before the first frame update
    void Start()
    {
        currentState = States.Idle;
        myStats = GetComponent<EnemyStats>();
        countdown = attackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (myStats.health <= 0)
        {
            currentState = States.Death;
        }

        switch (currentState)
        {
            case States.Idle:

                if (Vector2.Distance(player.transform.position, transform.position) < chaseRange)
                {
                    currentState = States.Chase;
                }

                break;

            case States.Chase:

                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, myStats.speed * Time.deltaTime);

                if (Vector2.Distance(player.transform.position, transform.position) > chaseRange)
                {
                    currentState = States.Idle;
                }

                if (Vector2.Distance(player.transform.position, transform.position) < attackRange)
                {
                    currentState = States.Attack;
                }

                break;

            case States.Attack:

                countdown -= Time.deltaTime;

                if (countdown <= 0)
                {
                    player.GetComponent<PlayerStats>().TakeDamage(myStats.damage);
                    countdown = attackCooldown;
                }

                if (Vector2.Distance(player.transform.position, transform.position) > attackRange)
                {
                    currentState = States.Chase;
                }

                break;

            case States.Death:

                Destroy(gameObject);

                break;

            default:
                break;
        }
    }
}
