using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : States
{
    public override void UpdateState(EnemyAI Manager)
    {
        Destroy(gameObject);
    }
}
