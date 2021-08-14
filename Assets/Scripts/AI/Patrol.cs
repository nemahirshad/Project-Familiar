using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : States
{
    
    public override void UpdateState(EnemyAI Manager)
    {

        Manager.transform.position = Vector2.MoveTowards(Manager.transform.position, Manager.wayPoint, Manager.myStats.speed * Time.deltaTime);
        if (Vector2.Distance(Manager.transform.position, Manager.wayPoint) < Manager.rangeToPatrol)
        {
            Manager.SetNewDestination();
        }

        if (Vector2.Distance(Manager.player.transform.position, Manager.transform.position) < Manager.chaseRange)
        {
            Manager.SwitchState(new Follow());
        }
    }
}
