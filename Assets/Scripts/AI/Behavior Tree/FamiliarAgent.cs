using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamiliarAgent : BehaviorTree
{
    
    public FamiliarStats stats;

    public GameObject home;

    public LayerMask enemyLayers;

    public Vector2 newDir;

    public float animationTimer;
    public float wanderTimer;
    public float followCountdown;
    public float chaseCountdown;

    public bool chasing;
    public bool following;

    Vector2 currentPosition;
    Vector2 endPosition;
    
    float animationCountdown;
    float wanderCountdown;

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
        rootNode.childrenNodes[2].childrenNodes.Add(new ChaseNode());
        rootNode.childrenNodes[2].childrenNodes.Add(new AttackNode());

        myStats = stats;

        stats.healCountdown = stats.healSpeed;
        stats.attackCountdown = stats.attackCooldown;
        stats.auraCountdown = stats.auraDuration;

        followCountdown = stats.bond / 10;
    }

    public override void Update()
    {
        rootNode.Execute(this);

        stats.auraCountdown -= Time.deltaTime;
        stats.healCountdown -= Time.deltaTime;
        stats.attackCountdown -= Time.deltaTime;

        wanderCountdown -= Time.deltaTime;
        animationCountdown -= Time.deltaTime;

        if (wanderCountdown <= 0)
        {
            GetNewHeading();
            wanderCountdown = wanderTimer;
        }

        if (animationCountdown <= 0)
        {
            endPosition = transform.position;
            animationCountdown = animationTimer;
        }

        if (following)
        {
            followCountdown -= Time.deltaTime;

            if (followCountdown <= 0)
            {
                following = false;
                followCountdown = stats.bond / 10;
            }
        }

        if (chasing)
        {
            chaseCountdown -= Time.deltaTime;

            if (chaseCountdown <= 0)
            {
                chasing = false;
                chaseCountdown = stats.bond / 10;
            }
        }

        currentPosition = transform.position;

        Vector2 direction = endPosition - currentPosition;

        if (direction.x > -1 || direction.x < 1)
        {
            anim.SetFloat("x", -direction.x);
        }
        if (direction.y > -1 || direction.y < 1)
        {
            anim.SetFloat("y", -direction.y);
        }
    }

    void GetNewHeading()
    {
        newDir = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
    }
}
