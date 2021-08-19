using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointInteractable : Interactable
{
    public SaveLoad save;

    public AudioSource audioSource;

    public override void DoInteraction()
    {
        save.Save();
        audioSource.Play();
    }
}
