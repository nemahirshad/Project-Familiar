using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    enum States
    {
        Chase,
        Attack,
        Leap,
        Fireball,
        Summon,
        Death
    }

    States currentState;

    public List<Transform> spawnPoints;

    public Transform firePoint;

    public GameObject player;
    public GameObject zombiePrefab;
    public GameObject fireballPrefab;

    public float attackRange;
    public float leapRange;
    public float attackCooldown;
    public float fireballCooldowm;
    public float fireballSpeed = 10f;

    EnemyStats myStats;

    Animator anim;

    List<GameObject> zombies = new List<GameObject>();

    Vector3 playerLast;

    float attackCountdown;
    float fireballCountdown;

    bool lept;

    // Start is called before the first frame update
    void Start()
    {
        currentState = States.Chase;
        myStats = GetComponent<EnemyStats>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myStats.health <= 0)
        {
            currentState = States.Death;
        }

        transform.LookAt(player.transform.position);
        transform.Rotate(new Vector3(0, 90, 0), Space.Self);

        switch (currentState)
        {
             case States.Chase:

                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, myStats.speed * Time.deltaTime);

                if (zombies.Count <= 2)
                {
                    currentState = States.Summon;
                }

                if (Vector2.Distance(player.transform.position, transform.position) < leapRange && Random.Range(0, 100) <= 10)
                {
                    if (!lept)
                    {
                        playerLast = player.transform.position;
                    }
                    currentState = States.Leap;
                }

                if (Vector2.Distance(player.transform.position, transform.position) > leapRange && Random.Range(0, 100) <= 50)
                {
                    currentState = States.Fireball;
                }

                if (Vector2.Distance(player.transform.position, transform.position) < attackRange)
                {
                    currentState = States.Attack;
                }

                break;

            case States.Attack:

                attackCountdown -= Time.deltaTime;

                if (attackCountdown <= 0)
                {
                    player.GetComponent<PlayerStats>().TakeDamage(myStats.damage);
                    attackCountdown = attackCooldown;
                }

                if (Vector2.Distance(player.transform.position, transform.position) > attackRange)
                {
                    currentState = States.Chase;
                }

                break;

            case States.Summon:

                GameObject zombie = Instantiate(zombiePrefab);
                zombie.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
                zombie.GetComponent<EnemyAI>().player = player;
                zombies.Add(zombie);

                if (zombies.Count >= 3)
                {
                    currentState = States.Chase;
                }

                break;

            case States.Fireball:

                fireballCooldowm -= Time.deltaTime;

                if (fireballCountdown <= 0)
                {
                    GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);

                    fireball.GetComponent<Fireball>().myStats = myStats;
                    Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
                    rb.AddForce(firePoint.up * fireballSpeed, ForceMode2D.Impulse);

                    fireballCountdown = fireballCooldowm;
                }

                if (Random.Range(0, 100) <= 50)
                {
                    currentState = States.Chase;
                }

                if (Vector2.Distance(player.transform.position, transform.position) < attackRange)
                {
                    currentState = States.Attack;
                }

                break;

            case States.Leap:

                transform.position = Vector2.MoveTowards(transform.position, playerLast, myStats.speed * 5 * Time.deltaTime);

                if (!lept)
                {
                    anim.SetBool("Leap", true);
                    lept = true;
                }
                else
                {
                    anim.SetBool("Leap", false);
                }

                if (Vector2.Distance(playerLast, transform.position) < 5)
                {
                    currentState = States.Chase;
                    anim.SetBool("Leap", false);
                    lept = false;
                }

                break;

            case States.Death:

                Destroy(gameObject);

                break;

            default:
                break;
        }
    }
}
