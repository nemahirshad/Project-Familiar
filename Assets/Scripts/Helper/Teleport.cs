using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public string sceneName;

    public UpgradeObject upgrade;

    public bool badge;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!badge)
        {
            if (upgrade.level2)
            {
                SceneManager.LoadScene(sceneName);
                upgrade.level2 = false;
            }
        }
        else
        {
            if (upgrade.canPass)
            {
                SceneManager.LoadScene(sceneName);
                upgrade.level2 = false;
            }
        }
    }
}