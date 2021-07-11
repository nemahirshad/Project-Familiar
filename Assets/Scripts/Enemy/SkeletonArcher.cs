using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonArcher : MonoBehaviour
{
    Transform SkeletenArcher;
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
   
    


    // Update is called once per frame
    void Awake()
    {
        SkeletenArcher = GameObject.FindWithTag("Player").transform;

    }
    private void Start()
    {
        arrowshootCooldown = arrowshootRate;
        myStats = GetComponent<EnemyStats>();
    }
    

   void   ShootArrow()
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


        if(distanceFromPlayer <= LineOfSight)
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;

            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -moveSpeed * Time.deltaTime);
            }
        }


        //Make Enemy look at player
        transform.LookAt(SkeletenArcher.position);
        transform.Rotate(new Vector3(0, 90, 0), Space.Self);



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
