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
    public float maxDistance;

    public Vector2 wayPoint;

    
   private void Start()
    {
        currentstate = new Patrol();
        myStats = GetComponent<EnemyStats>();
        countdown = attackCooldown;
        SetNewDestination();
    }

    public virtual void SwitchState(States newState)
    {
        currentstate = newState;
    }

  
    public void Update()
    {
        currentstate.UpdateState(this);
    }

    public void SetNewDestination()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
    }
}
