using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeLevel2 : MonoBehaviour
{
    public UpgradeObject upgradeObject;

    // Start is called before the first frame update
    void Start()
    {
        upgradeObject.level2 = true;
    }
}
