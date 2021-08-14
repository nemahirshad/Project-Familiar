using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHeartUI : MonoBehaviour
{
    public List<GameObject> enemyUI;

    GameObject uiUse;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < enemyUI.Count; i++)
        {
            if (!enemyUI[i].activeInHierarchy)
            {
                enemyUI[i].SetActive(true);
                GetComponent<Stats>().heartSystem = enemyUI[i].GetComponent<HeartSystem>();
                uiUse = enemyUI[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        uiUse.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }
}
