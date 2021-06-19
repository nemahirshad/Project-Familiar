using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject Player;
    private Transform playerPos;
    private Vector2 currentPos;
    public float Speed;
    public float ReturnToDistance;


    // Start is called before the first frame update
    void Start()
    {
        playerPos = Player.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, playerPos.position) < ReturnToDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, Speed * Time.deltaTime);
        }
        else
        {
            if (Vector2.Distance(transform.position, currentPos) <= 0)

            {

            }

            else
            {
                transform.position = Vector2.MoveTowards(transform.position, currentPos, Speed * Time.deltaTime);
            }

        }
    }


}
