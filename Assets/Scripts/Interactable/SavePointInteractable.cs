using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointInteractable : Interactable
{
    public AudioSource audioSource;

    public Bond bond;

    public UpgradeObject upgrade;

    public string sceneName;

    public override void DoInteraction()
    {
        SaveLoad.Save(upgrade, bond, sceneName);
        audioSource.Play();
    }
}