using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeInteractable : Interactable
{
    public enum UpgradeType
    {
        MELEE,
        RANGED,
        ARMOR
    }

    public UpgradeType type;

    public GameObject npc;

    public QuestObject quest;
    public UpgradeObject upgrade;

    public PlayerStats stats;
    public PlayerCombat combat;

    public int amountNeeded;

    public override void DoInteraction()
    {
        if (quest.amount >= amountNeeded)
        {
            switch (type)
            {
                case UpgradeType.MELEE:
                    stats.UpgradeMelee();
                    stats.UpgradeHealth();
                    upgrade.melee = true;
                    upgrade.health1 = true;
                    break;

                case UpgradeType.RANGED:
                    stats.UpgradeRanged();
                    stats.UpgradeHealth();
                    upgrade.ranged = true;
                    upgrade.health2 = true;
                    break;

                case UpgradeType.ARMOR:
                    stats.UpgradeArmor();
                    stats.UpgradeHealth();
                    upgrade.armor = true;
                    upgrade.health3 = true;
                    break;
            }
        }
    }
}
