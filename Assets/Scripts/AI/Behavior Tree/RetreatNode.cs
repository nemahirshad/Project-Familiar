using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatNode : ActionNode
{
    public override NodeOutcome Execute(BehaviorTree bt)
    {
        if (bt.myStats.health <= 1)
        {
            bt.target = ((FamiliarAgent)bt).home;

            bt.transform.position = Vector2.MoveTowards(bt.transform.position, bt.target.transform.position, bt.myStats.speed * Time.deltaTime);

            if (Vector2.Distance(bt.target.transform.position, bt.transform.position) < bt.myStats.attackRange)
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
