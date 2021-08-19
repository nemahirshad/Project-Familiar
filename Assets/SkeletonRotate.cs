using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonRotate : MonoBehaviour
{

    public GameObject player;
    public Rigidbody2D rb;

    public Transform guide;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDir = (Vector2)player.transform.position - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -225f;
        rb.rotation = angle;

        transform.position = guide.position;


    }
}
