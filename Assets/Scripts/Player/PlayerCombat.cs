using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public UpgradeObject upgradeObject;

    public PlayerStats myStats;

    public Transform firePoint;
    public Transform attackPoint;
    
    public GameObject bulletPrefab;

    public Animator animator;
    public AudioSource playSoundShoot;
    public AudioSource playSoundMelee;

    public LayerMask enemyLayers;

    public float bulletForce = 10f;
    public float attackRange = 0.5f;

    float cooldown;

    private void Start()
    {
        myStats = GetComponent<PlayerStats>();
        cooldown = myStats.spellCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        
        if (Input.GetMouseButtonDown(1) && cooldown <= 0)
        {
            Shoot();

            playSoundShoot.Play();
            Debug.Log("hi");

            cooldown = myStats.spellCooldown;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            playSoundMelee.Play();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        bullet.GetComponent<Bullet>().damage = myStats.spellDamage;
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyStats>().TakeDamage(myStats.staffDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
