using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveSlot
{
    public string sceneName;

    public int bond;

    public bool melee, ranged, armor, health1, health2, health3, level2, canPass;

    public SaveSlot(UpgradeObject upgrade, Bond bond, string sceneName)
    {
        melee = upgrade.melee;
        ranged = upgrade.ranged;
        armor = upgrade.armor;
        health1 = upgrade.health1;
        health2 = upgrade.health2;
        health3 = upgrade.health3;
        level2 = upgrade.level2;
        canPass = upgrade.canPass;

        this.sceneName = sceneName;

        this.bond = bond.bond;
    }
}
