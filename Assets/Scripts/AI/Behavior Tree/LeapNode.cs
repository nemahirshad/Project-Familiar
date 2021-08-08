using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapNode : ActionNode
{
    public override NodeOutcome Execute(BehaviorTree bt)
    {
        bt.transform.position = Vector2.MoveTowards(bt.transform.position, ((BossAgent)bt).stats.playerLast, ((BossAgent)bt).myStats.speed * 5 * Time.deltaTime);

        if (!((BossAgent)bt).stats.lept)
        {
            bt.anim.SetBool("Leap", true);
            ((BossAgent)bt).stats.lept = true;
        }
        else
        {
            bt.anim.SetBool("Leap", false);
        }

        if (Vector2.Distance(((BossAgent)bt).stats.playerLast, bt.transform.position) < 5)
        {
            bt.anim.SetBool("Leap", false);
            ((BossAgent)bt).stats.lept = false;
            return NodeOutcome.SUCCESS;
        }

        return NodeOutcome.RUNNING;
    }
}
