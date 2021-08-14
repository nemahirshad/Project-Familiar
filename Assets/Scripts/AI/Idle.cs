using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : States
{
    public override void UpdateState(EnemyAI Manager)
    {
         if (Vector2.Distance(Manager.player.transform.position, Manager.transform.position) < Manager.chaseRange)
         {
             Manager.SwitchState(new Follow());
         }
        
       
    }
}
