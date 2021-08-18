using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamiliarAgent : BehaviorTree
{
    
    public FamiliarStats stats;

    public GameObject home;

    public LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start()
    {
        rootNode = new SelectorNode();
        rootNode.childrenNodes.Add(new SequenceNode());
        rootNode.childrenNodes.Add(new SequenceNode());
        rootNode.childrenNodes.Add(new SequenceNode());
        rootNode.childrenNodes.Add(new WanderNode());
        rootNode.childrenNodes[0].childrenNodes.Add(new RetreatNode());
        rootNode.childrenNodes[0].childrenNodes.Add(new HealNode());
        rootNode.childrenNodes[1].childrenNodes.Add(new FollowNode());
        rootNode.childrenNodes[1].childrenNodes.Add(new AuraNode());
        rootNode.childrenNodes[1].childrenNodes.Add(new ChaseNode());
        rootNode.childrenNodes[1].childrenNodes.Add(new AttackNode());

        myStats = stats;

        stats.healCountdown = stats.healSpeed;
        stats.attackCountdown = stats.attackCooldown;
        stats.auraCountdown = stats.auraDuration;
    }

    public override void Update()
    {
        rootNode.Execute(this);

        stats.auraCountdown -= Time.deltaTime;
        stats.healCountdown -= Time.deltaTime;
        stats.attackCountdown -= Time.deltaTime;
    }
}
