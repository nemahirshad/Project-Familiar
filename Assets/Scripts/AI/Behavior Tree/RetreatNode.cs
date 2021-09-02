using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatNode : ActionNode
{
    public override NodeOutcome Execute(BehaviorTree bt)
    {
        if (bt.myStats.health <= 1)
        {
            bt.transform.position = Vector2.MoveTowards(bt.transform.position, ((FamiliarAgent)bt).home.transform.position, bt.myStats.speed * Time.deltaTime);
            
            if (Vector2.Distance(((FamiliarAgent)bt).home.transform.position, bt.transform.position) < bt.myStats.attackRange)
            {
                return NodeOutcome.SUCCESS;
            }

            return NodeOutcome.RUNNING;
        }
        else
        {
            return NodeOutcome.FAIL;
        }
    }
}
