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
    
    private void Start()
    {
        currentstate = new Idle();
        myStats = GetComponent<EnemyStats>();
        countdown = attackCooldown;
    }

    public virtual void SwitchState(States newState)
    {
        currentstate = newState;
    }

  
    void Update()
    {
        currentstate.UpdateState(this);
    }
}
