using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyStats : Stats
{
    public List<Transform> spawnPoints;
    public List<GameObject> zombies = new List<GameObject>();

    public Vector3 playerLast;

    public GameObject fireballPrefab;
    public GameObject zombiePrefab;

    public Transform firePoint;

    public float fireballSpeed;
    public float leapRange;
    public float fireballCooldown;
    public float fireballCountdown;

    public int fireballCount;

    public bool lept;

    public override void Start()
    {
        base.Start();
    }
}
