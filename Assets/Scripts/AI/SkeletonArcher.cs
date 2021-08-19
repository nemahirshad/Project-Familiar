using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonArcher : MonoBehaviour
{
    public float moveSpeed;
    public Transform firePoint;
    public Transform player;
    public GameObject arrowPrefab;
    public float arrowSpeed = 20f;
    private float arrowshootCooldown;
    public float arrowshootRate = 10f;
    public float stoppingDistance;
    public float retreatDistance;
    public float LineOfSight;

    private EnemyStats myStats;
    public Transform followKnight;
    
    


   
    private void Start()
    {
        arrowshootCooldown = arrowshootRate;
        myStats = GetComponent<EnemyStats>();
    }
    

   void  ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        arrow.GetComponent<SkeletonArrow>().myStats = myStats;
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * arrowSpeed, ForceMode2D.Impulse);
        
       
    }




    void Update()
    {
        if (myStats.health <= 0)
        {
            Destroy(gameObject);
        }


        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceFromPlayer <= LineOfSight)
        {

            if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -moveSpeed * Time.deltaTime);
            }

        }
        else
        {
           
            if (Vector2.Distance(transform.position, followKnight.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, followKnight.position, moveSpeed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, followKnight.position) < stoppingDistance && Vector2.Distance(transform.position, followKnight.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
        }




        if (distanceFromPlayer < LineOfSight && arrowshootCooldown < Time.deltaTime)
        {
            ShootArrow();
            arrowshootCooldown = arrowshootRate;
          
        }
        if (arrowshootCooldown > 0)
        {
            arrowshootCooldown -= Time.deltaTime;
        }



    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, LineOfSight);
    }
}
