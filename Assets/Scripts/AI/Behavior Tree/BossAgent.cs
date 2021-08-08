using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAgent : BehaviorTree
{
    public EnemyStats stats;

    // Start is called before the first frame update
    void Start()
    {
        rootNode = new SelectorNode();
        rootNode.childrenNodes.Add(new SummonNode());
        rootNode.childrenNodes.Add(new LeapNode());
        rootNode.childrenNodes.Add(new FireballNode());
        rootNode.childrenNodes.Add(new SequenceNode());
        rootNode.childrenNodes[3].childrenNodes.Add(new ChaseNode());
        rootNode.childrenNodes[3].childrenNodes.Add(new AttackNode());

        myStats = stats;
    }

    // Update is called once per frame
    public override void Update()
    {
        rootNode.Execute(this);

        stats.fireballCooldown -= Time.deltaTime;
    }
}
