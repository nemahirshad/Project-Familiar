using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialConvo : MonoBehaviour
{
    public Conversation convo;

    // Start is called before the first frame update
    void Start()
    {
        DialogueManager.instance.StartConversation(convo);
    }
}
