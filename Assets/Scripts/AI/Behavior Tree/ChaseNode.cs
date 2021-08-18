using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseNode : ActionNode
{
    public override NodeOutcome Execute(BehaviorTree bt)
    {
        if (((FamiliarAgent)bt).stats.bond <= Random.Range(0, 100))
        {
            return NodeOutcome.FAIL;
        }

        if (!bt.target)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(bt.transform.position, bt.range, ((FamiliarAgent)bt).enemyLayers);
            
            if (hitEnemies.Length >= 1)
            {
                bt.target = hitEnemies[Random.Range(0, hitEnemies.Length)].gameObject;
            }
        }

        bt.transform.position = Vector2.MoveTowards(bt.transform.position, bt.target.transform.position, bt.myStats.speed * Time.deltaTime);

        if (Vector2.Distance(bt.target.transform.position, bt.transform.position) < bt.myStats.attackRange)
        {
            return NodeOutcome.SUCCESS;
        }

        return NodeOutcome.RUNNING;
    }
}
