using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonArrow : MonoBehaviour
{
    public float lifetime = 3;

    public EnemyStats myStats;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().TakeDamage(myStats.damage);
        }
    }
}