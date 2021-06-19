using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public int damage;

    public float speed;

    public void TakeDamage(int amount)
    {
        health -= amount;
}
}
