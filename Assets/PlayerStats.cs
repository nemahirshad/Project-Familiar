using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float Speed;
    public float Health;
    public float Damage;

    void TakeDamage(int amount)
    {
        Health -= amount;
}
}
