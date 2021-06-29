using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCombat : MonoBehaviour
{
 public Animator ani;



    private void Start()
    {
        ani.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ani.enabled = true;
        }
    }

   
}
