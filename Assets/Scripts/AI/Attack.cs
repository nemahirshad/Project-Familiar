using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : States
{
    public override void UpdateState(EnemyAI Manager)
    {
        Manager.countdown -= Time.deltaTime;

        if (Manager.countdown <= 0)
        {
            Manager.player.GetComponent<PlayerStats>().TakeDamage(Manager.myStats.damage);
            Manager.countdown = Manager.attackCooldown;
        }

        if (Vector2.Distance(Manager.player.transform.position, Manager.transform.position) > Manager.attackRange)
        {
            Manager.SwitchState(new Follow());
        }


    }
}
