using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestCounter : MonoBehaviour
{
    public Text counter;

    public QuestObject questObject;

    public int maxAmount;

    // Update is called once per frame
    void Update()
    {
        counter.text = questObject.questName + " " + questObject.amount + " / " + maxAmount;
    }
}
