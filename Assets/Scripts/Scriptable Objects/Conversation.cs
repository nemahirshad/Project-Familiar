using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Line
{
    public string character;

    public Color color;

    [TextArea(2, 5)]
    public string text;
}

[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")]
public class Conversation : ScriptableObject
{
    public Line[] lines;

    public Question question;

    public bool sceneChange;

    public string scene;
}
