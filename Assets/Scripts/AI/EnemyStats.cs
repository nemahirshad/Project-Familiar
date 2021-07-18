using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyStats : MonoBehaviour
{
    public int damage;
    public int health = 3;
    public int maxHealth = 3;

    public float speed;

    private void Start()
    {

    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
    }
}
