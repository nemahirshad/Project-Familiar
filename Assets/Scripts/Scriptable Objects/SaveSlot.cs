using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SaveSlot : ScriptableObject
{
    public string sceneName;

    public Vector3 position;

    public int bond;

    public bool level2;
}
