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



    
   public void Start()
    {
        waitTime = StartWaitTtime;
        currentstate = new Patrol();
        myStats = GetComponent<EnemyStats>();
        countdown = attackCooldown;
        randomSpot = Random.Range(0, moveSpots.Length);
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
        }
    }

    /*public void SetNewDestination()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
    }*/
}
