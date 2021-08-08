using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealNode : ActionNode
{
    public override NodeOutcome Execute(BehaviorTree bt)
    {
        if (((FamiliarAgent)bt).myStats.health >= ((FamiliarAgent)bt).myStats.maxHealth)
        {
            ((FamiliarAgent)bt).myStats.health = ((FamiliarAgent)bt).myStats.maxHealth;
            return NodeOutcome.SUCCESS;
        }

        if (((FamiliarAgent)bt).stats.healCountdown <= 0)
        {
            ((FamiliarAgent)bt).myStats.health++;
            ((FamiliarAgent)bt).stats.healCountdown = ((FamiliarAgent)bt).stats.healSpeed;
        }

        return NodeOutcome.RUNNING;
    }
}
