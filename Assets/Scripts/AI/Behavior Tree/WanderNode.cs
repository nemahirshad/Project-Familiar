using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderNode : ActionNode
{
    public override NodeOutcome Execute(BehaviorTree bt)
    {
        bt.transform.position = Vector2.MoveTowards(bt.transform.position, ((FamiliarAgent)bt).newDir + (Vector2)bt.transform.position, ((FamiliarAgent)bt).myStats.speed * Time.deltaTime);

        return NodeOutcome.SUCCESS;
    }
}
