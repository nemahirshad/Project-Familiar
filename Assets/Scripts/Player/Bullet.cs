using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemies"))
        {
            collision.transform.GetComponent<EnemyStats>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Knight"))
        {
            Destroy(gameObject);
        }
    }
}
