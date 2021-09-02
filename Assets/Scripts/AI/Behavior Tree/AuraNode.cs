using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraNode : ActionNode
{
    public override NodeOutcome Execute(BehaviorTree bt)
    {
        if (((FamiliarAgent)bt).stats.auraCountdown <= 0)
        {
            bt.StartCoroutine(bt.player.GetComponent<PlayerStats>().ActivateAura(((FamiliarAgent)bt).stats.auraDuration));

            ((FamiliarAgent)bt).stats.auraCountdown = ((FamiliarAgent)bt).stats.auraDuration * 5;

            return NodeOutcome.SUCCESS;
        }

        return NodeOutcome.FAIL;
    }
}
