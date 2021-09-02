using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAgent : BehaviorTree
{
    public EnemyStats stats;

    public bool phase2;

    // Start is called before the first frame update
    void Start()
    {
        if (!phase2)
        {
            rootNode = new SelectorNode();
            rootNode.childrenNodes.Add(new SummonNode());
            rootNode.childrenNodes.Add(new AttackNode());
            rootNode.childrenNodes.Add(new FireballNode());
        }
        else
        {
            rootNode = new SelectorNode();
            rootNode.childrenNodes.Add(new LeapNode());
            rootNode.childrenNodes.Add(new SequenceNode());
            rootNode.childrenNodes[1].childrenNodes.Add(new ChaseNode());
            rootNode.childrenNodes[1].childrenNodes.Add(new AttackNode());
        }

        myStats = stats;
    }

    // Update is called once per frame
    public override void Update()
    {
        rootNode.Execute(this);

        stats.fireballCountdown -= Time.deltaTime;
        myStats.attackCountdown -= Time.deltaTime;
        stats.zombieCountdown -= Time.deltaTime;

        for (int i = 0; i < stats.zombies.Count; i++)
        {
            if (!stats.zombies[i])
            {
                stats.zombies.RemoveAt(i);
            }
        }
    }
}
