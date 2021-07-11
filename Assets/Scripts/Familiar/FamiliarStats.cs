using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FamiliarStats : MonoBehaviour
{
    public Text text;

    public int damage;
    public int health = 1;
    public int maxHealth = 1;
    public int bond = 0;

    public float speed;

    [SerializeField] HeartSystem hearthSystem;

    private void Start()
    {
        //hearthSystem.DrawHearts(health, maxHealth);
    }
    public void TakeDamage(int dmg)
    {
        health -= dmg;

        hearthSystem.DrawHearts(health, maxHealth);
    }

    private void Update()
    {
        text.text = "Bond: " + bond;
    }

    public void ChangeBond(int stats)
    {
        bond += stats;
    }
}
