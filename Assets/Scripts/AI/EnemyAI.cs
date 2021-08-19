using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;

    public float chaseRange;
    public float attackRange;
    public EnemyStats myStats;
    public float attackCooldown;

    public float countdown;
    States currentstate;

    public float rangeToPatrol;
    public float StartWaitTtime;
    public float waitTime;

    public Transform[] moveSpots;
    public int randomSpot;

    public Rigidbody2D rb;
    public Animator anim;
    private Vector2 currentPosition;
    private Vector2 endPosition;
    public float timer;
    private float countDown;

    public GameObject deathEffect;

   public void Start()
    {
        waitTime = StartWaitTtime;
        currentstate = new Patrol();
        myStats = GetComponent<EnemyStats>();
        countdown = attackCooldown;
        randomSpot = Random.Range(0, moveSpots.Length);
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void SwitchState(States newState)
    {
        currentstate = newState;
    }

  
    public void Update()
    {
        currentstate.UpdateState(this);

        if (myStats.health <= 0)
        {
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        countDown -= Time.deltaTime;
        if(countDown <= 0)
        {
            endPosition = transform.position;
            countDown = timer;
        }
        currentPosition = transform.position;

        Vector2 direction = endPosition - currentPosition;

        if(direction.x > -1 || direction.x < 1)
        {
            anim.SetFloat("x", direction.x);
        }
        if(direction.y > -1 || direction.y < 1)
        {
            anim.SetFloat("y", direction.y);
        }
    }

    
}
