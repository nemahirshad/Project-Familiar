using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : States
{
    public override void UpdateState(EnemyAI Manager)
    {
        Manager.transform.position = Vector2.MoveTowards(Manager.transform.position, Manager.player.transform.position, Manager.myStats.speed * Time.deltaTime);

      
        if (Vector2.Distance(Manager.player.transform.position, Manager.transform.position) < Manager.attackRange)
        {
            Manager.SwitchState(new Attack());
        }
    }

}
