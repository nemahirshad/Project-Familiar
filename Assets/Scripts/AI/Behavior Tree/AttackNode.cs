using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackNode : ActionNode
{
    public override NodeOutcome Execute(BehaviorTree bt)
    {
        if (bt.myStats.attackCountdown <= 0)
        {
            bt.player.GetComponent<PlayerStats>().TakeDamage(bt.myStats.damage);
            bt.myStats.attackCountdown = bt.myStats.attackCooldown;

            return NodeOutcome.SUCCESS;
        }

        return NodeOutcome.FAIL;
    }
}
