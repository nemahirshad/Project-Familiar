using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Choice
{
    public Conversation conversation;
    
    [TextArea(2, 5)]
    public string text;

    public int familiarBond;
}

[CreateAssetMenu(fileName = "New Question", menuName = "Question")]
public class Question : ScriptableObject
{
    [TextArea(2, 5)]
    public string text;
    public string character;

    public Color color;

    public Choice[] choices;
}
