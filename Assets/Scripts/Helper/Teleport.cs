using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public string sceneName;

    public UpgradeObject upgrade;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (upgrade.level2)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}