using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FamiliarStats : Stats
{
    public Bond bondSO;

    public Text text;

    public int bond = 0;
    public int auraDuration;

    public float healSpeed;
    public float healCountdown;
    public float auraCountdown;

    public bool levelZero;

    public override void Start()
    {
        if (!levelZero)
        {
            heartSystem.DrawHearts(health, maxHealth);
        }

        bond = bondSO.bond;
    }
    

    public override void Update()
    {
        text.text = "Bond: " + bond;

        bondSO.bond = bond;
    }

    public void ChangeBond(int stats)
    {
        bond += stats;
    }
}
