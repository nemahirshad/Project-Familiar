using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieQuest : MonoBehaviour
{
    public QuestObject quest;

    public List<GameObject> zombies;

    int count;

    // Start is called before the first frame update
    void Start()
    {
        count = zombies.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (zombies.Count < count) 
        {
            count = zombies.Count;
            quest.amount++;
        }

        for (int i = 0; i < zombies.Count; i++)
        {
            if (!zombies[i])
            {
                zombies.RemoveAt(i);
            }
        }
    }
}
