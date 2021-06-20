using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamiliarStats : MonoBehaviour
{
    public int damage;
    public int health = 1;
    public int maxHealth = 1;
    public int bond = 75;

    public float speed;

    public bool familiar;

    [SerializeField] HeartSystem hearthSystem;

    private void Start()
    {
        hearthSystem.DrawHearts(health, maxHealth);
    }
    public void TakeDamage(int dmg)
    {
        health -= dmg;

        hearthSystem.DrawHearts(health, maxHealth);
    }
}
