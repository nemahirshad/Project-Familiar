using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowNode : ActionNode
{
    public override NodeOutcome Execute(BehaviorTree bt)
    {
        if (((FamiliarAgent)bt).stats.bond <= Random.Range(0, 100))
        {
            return NodeOutcome.FAIL;
        }

        bt.transform.position = Vector2.MoveTowards(bt.transform.position, bt.player.transform.position, ((FamiliarAgent)bt).myStats.speed * Time.deltaTime);

        if (Vector2.Distance(bt.player.transform.position, bt.transform.position) < ((FamiliarAgent)bt).range/2)
        {
            return NodeOutcome.SUCCESS;
        }

        return NodeOutcome.RUNNING;
    }
}
