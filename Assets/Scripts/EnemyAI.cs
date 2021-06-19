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

    public GameObject player;

    public int hp;
    public int damage;

    public float chaseRange;
    public float attackRange;
    public float attackCooldown;
    public float moveSpeed;

    float countdown;

    // Start is called before the first frame update
    void Start()
    {
        currentState = States.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
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

                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

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
                    //player.GetComponent<PlayerStats>().TakeDamage(damage);
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
