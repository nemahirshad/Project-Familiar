using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int damage;
    public int health = 1;
    public int maxHealth = 1;
    
    public float speed;
    public float attackRange;
    public float attackCooldown;
    public float attackCountdown;

    public HeartSystem heartSystem;

    // Start is called before the first frame update
    public virtual void Start()
    {
        heartSystem.DrawHearts(health, maxHealth);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;

        heartSystem.DrawHearts(health, maxHealth);
    }
}
