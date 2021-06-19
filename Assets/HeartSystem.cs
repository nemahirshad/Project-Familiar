using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    [SerializeField] GameObject HeartPrefab;
    [SerializeField] GameObject BrokenHeartPrefab;

    public void DrawHearts(int Hearts, int maxHearts)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < maxHearts; i++)
        {
            if(i + 1 <= Hearts)
            {
                GameObject heart = Instantiate(HeartPrefab, transform.position, Quaternion.identity);
                heart.transform.parent = transform;
            }
            else
            {
                GameObject heart = Instantiate(BrokenHeartPrefab, transform.position, Quaternion.identity);
                heart.transform.parent = transform;
            }

        }

    }
}
