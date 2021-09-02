using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackNode : ActionNode
{
    public override NodeOutcome Execute(BehaviorTree bt)
    {
        if (bt.myStats.enemy)
        {
            if (Vector2.Distance(bt.transform.position, bt.player.transform.position) < bt.range && bt.myStats.attackCountdown <= 0)
            {
                bt.player.GetComponent<PlayerStats>().TakeDamage(bt.myStats.damage);
                bt.myStats.attackCountdown = bt.myStats.attackCooldown;

                return NodeOutcome.SUCCESS;
            }
            else
            {
                return NodeOutcome.FAIL;
            }
        }

        if (bt.myStats.attackCountdown <= 0)
        {
            bt.target.GetComponent<Stats>().TakeDamage(bt.myStats.damage);
            bt.myStats.attackCountdown = bt.myStats.attackCooldown;

            if (((FamiliarAgent)bt).stats.bond >= Random.Range(0, 100))
            {
                ((FamiliarAgent)bt).stats.TakeDamage(1);
            }

            return NodeOutcome.SUCCESS;
        }
        else
        {
            return NodeOutcome.FAIL;
        }        
    }
}
