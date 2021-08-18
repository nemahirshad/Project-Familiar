using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonQuest : MonoBehaviour
{
    public QuestObject quest;

    public List<GameObject> archer;
    public List<GameObject> knight;

    int archerCount;
    int knightCount;

    // Start is called before the first frame update
    void Start()
    {
        archerCount = archer.Count;
        knightCount = archer.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (archer.Count < archerCount)
        {
            archerCount = archer.Count;
            quest.amount++;
        }

        if (archer.Count < knightCount)
        {
            knightCount = archer.Count;
            quest.amount++;
        }

        for (int i = 0; i < archer.Count; i++)
        {
            if (!archer[i])
            {
                archer.RemoveAt(i);
            }
        }

        for (int i = 0; i < archer.Count; i++)
        {
            if (!archer[i])
            {
                archer.RemoveAt(i);
            }
        }
    }
}
