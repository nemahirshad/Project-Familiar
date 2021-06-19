using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public PlayerStats myStats;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 10f;

    private void Start()
    {
        myStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        bullet.GetComponent<Bullet>().damage = myStats.damage;
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

}
