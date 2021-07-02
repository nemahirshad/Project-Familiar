using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonArcher : MonoBehaviour
{
    Transform SkeletenArcher;
    public float moveSpeed;
    public float minDistance;
    private float range;
    public Transform firePoint;
    public GameObject arrowPrefab;
    public float arrowSpeed = 20f;
    private float arrowshootCooldown;
    public float arrowshootRate = 10f;


    // Update is called once per frame
    void Awake()
    {
        SkeletenArcher = GameObject.FindWithTag("Player").transform;

    }
    private void Start()
    {
        arrowshootCooldown = arrowshootRate;
    }
    

   void   ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * arrowSpeed, ForceMode2D.Impulse);
        
       
    }


    void Update()
    {
        //Make Enemy look at player
        transform.LookAt(SkeletenArcher.position);
        transform.Rotate(new Vector3(0, 90, 0), Space.Self);

        //Checks the range 
        range = Vector2.Distance(transform.position, SkeletenArcher.position);

        if(arrowshootCooldown > 0)
        {
            arrowshootCooldown -= Time.deltaTime;
        }


        if (range < minDistance && arrowshootCooldown < Time.deltaTime)
        {
            ShootArrow();
            arrowshootCooldown = arrowshootRate;
        }

    }
}
