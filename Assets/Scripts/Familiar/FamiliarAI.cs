using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamiliarAI : MonoBehaviour
{
    public enum States
    {
        Idle,
        Follow,
        Aura,
        Death
    }

    public States currentState;

    FamiliarStats myStats;

    public GameObject player;

    public float auraRange;
    
    public int auraDuration;
    public int stateDuration;

    float auraCountdown;
    float stateCountdown;

    // Start is called before the first frame update
    void Start()
    {
        currentState = States.Idle;
        myStats = GetComponent<FamiliarStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myStats.health <= 0)
        {
            currentState = States.Death;
        }

        switch (currentState)
        {
            case States.Idle:

                stateCountdown -= Time.deltaTime;

                if (stateCountdown <= 0 && Random.Range(0, 100) > myStats.bond)
                {
                    currentState = States.Follow;
                    stateCountdown = stateDuration;
                }

                break;

            case States.Follow:

                stateCountdown -= Time.deltaTime;

                if (stateCountdown <= 0 && Random.Range(0, 100) < myStats.bond)
                {
                    currentState = States.Idle;
                    stateCountdown = stateDuration;
                }

                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, myStats.speed * Time.deltaTime);

                if (Vector2.Distance(player.transform.position, transform.position) < auraRange)
                {
                    currentState = States.Aura;
                }

                break;

            case States.Aura:

                auraCountdown -= Time.deltaTime;

                if (auraCountdown <= 0 && Random.Range(0, 100) > myStats.bond)
                {
                    StartCoroutine(player.GetComponent<PlayerStats>().ActivateAura(auraDuration));
                    Debug.Log("Aura");
                    auraCountdown = auraDuration;
                }

                if (Vector2.Distance(player.transform.position, transform.position) > auraRange)
                {
                    currentState = States.Follow;
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
