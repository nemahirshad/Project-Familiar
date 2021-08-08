using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonNode : ActionNode
{
    public override NodeOutcome Execute(BehaviorTree bt)
    {
        if (((BossAgent)bt).stats.zombies.Count >= 3)
        {
            return NodeOutcome.FAIL;
        }

        GameObject zombie = MonoBehaviour.Instantiate(((BossAgent)bt).stats.zombiePrefab);
        zombie.transform.position = ((BossAgent)bt).stats.spawnPoints[Random.Range(0, ((BossAgent)bt).stats.spawnPoints.Count)].position;
        zombie.GetComponent<EnemyAI>().player = bt.player;
        ((BossAgent)bt).stats.zombies.Add(zombie);

        return NodeOutcome.SUCCESS;
    }
}
