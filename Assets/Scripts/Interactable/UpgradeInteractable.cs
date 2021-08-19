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

    void Start()
    {
        switch (quest.questName)
        {
            case "Zombies":
                if (upgrade.melee)
                {
                    npc.SetActive(true);
                    gameObject.SetActive(false);
                }
                break;

            case "Skeletons":
                if (upgrade.ranged)
                {
                    npc.SetActive(true);
                    gameObject.SetActive(false);
                }
                break;

            case "Hat":
                if (upgrade.armor)
                {
                    npc.SetActive(true);
                    gameObject.SetActive(false);
                }
                break;
        }
    }

    public override void DoInteraction()
    {
        if (quest.amount >= amountNeeded)
        {
            switch (type)
            {
                case UpgradeType.MELEE:
                    if (!upgrade.melee)
                    {
                        stats.UpgradeMelee();
                        stats.UpgradeHealth();
                        upgrade.melee = true;
                        upgrade.health1 = true;
                    }
                    break;

                case UpgradeType.RANGED:
                    if (!upgrade.ranged)
                    {
                        stats.UpgradeRanged();
                        stats.UpgradeHealth();
                        upgrade.ranged = true;
                        upgrade.health2 = true;
                    }
                    break;

                case UpgradeType.ARMOR:
                    if (!upgrade.armor)
                    {
                        stats.UpgradeArmor();
                        stats.UpgradeHealth();
                        upgrade.armor = true;
                        upgrade.health3 = true;
                    }
                    break;
            }
            npc.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
