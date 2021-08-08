using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeNode : Node
{
    public CompositeNode()
    {
        childrenNodes = new List<Node>();
    }
}
