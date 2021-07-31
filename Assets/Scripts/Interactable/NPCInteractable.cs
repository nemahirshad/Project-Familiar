using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : Interactable
{
    public Conversation convo;

    public override void DoInteraction()
    {
        DialogueManager.instance.StartConversation(convo);
    }
}