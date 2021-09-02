using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballNode : ActionNode
{
    public override NodeOutcome Execute(BehaviorTree bt)
    {
        if (((BossAgent)bt).stats.fireballCount <= 0)
        {
            return NodeOutcome.FAIL;
        }

        if (((BossAgent)bt).stats.fireballCountdown <= 0)
        {
            GameObject fireball = Object.Instantiate(((BossAgent)bt).stats.fireballPrefab, ((BossAgent)bt).stats.firePoint.position, ((BossAgent)bt).stats.firePoint.rotation);

            fireball.GetComponent<Fireball>().myStats = ((BossAgent)bt).stats;
            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
            rb.AddForce((bt.player.transform.position - bt.transform.position).normalized * ((BossAgent)bt).stats.fireballSpeed, ForceMode2D.Impulse);

            ((BossAgent)bt).stats.fireballCountdown = ((BossAgent)bt).stats.fireballCooldown;

            return NodeOutcome.SUCCESS;
        }

        return NodeOutcome.FAIL;
    }
}
