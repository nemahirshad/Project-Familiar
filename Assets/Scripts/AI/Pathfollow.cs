using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfollow : MonoBehaviour
{
    public List<Transform> points;

    public float speed = 5;

    public bool loop;

    private int index = 0;

    private bool reverse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, points[index].position, speed * Time.deltaTime);

        if (reverse)
        {
            LoopBackwards();
        }
        else
        {
            LoopForward();
        }
    }

    void LoopForward()
    {
        if (Vector2.Distance(points[index].position, transform.position) < 0.2f)
        {
            index++;
        }

        if (index >= points.Count)
        {
            if (loop)
            {
                index = 0;
            }
            else
            {
                reverse = true;
                index--;
            }
        }
    }

    void LoopBackwards()
    {
        if (Vector2.Distance(points[index].position, transform.position) < 0.2f)
        {
            index--;
        }

        if (index <= 0)
        {
            reverse = false;
            index = 0;
        }
    }
}
