using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeInteractable : Interactable
{
    public enum UpgradeType
    {
        Melee,
        Ranged,
        Armor
    }

    public UpgradeType type;

    public PlayerStats stats;

    public override void DoInteraction()
    {
        switch (type)
        {
            case UpgradeType.Melee:
                stats.UpgradeMelee();
                break;

            case UpgradeType.Ranged:
                stats.UpgradeRanged();
                break;

            case UpgradeType.Armor:
                stats.UpgradeArmor();
                break;
        }
    }
}
