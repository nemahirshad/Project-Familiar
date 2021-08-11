using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Conversation convo;

    private void Update()
    {
        if (DialogueManager.instance.lineIndex >= convo.lines.Length)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DialogueManager.instance.StartConversation(convo);
    }
}
