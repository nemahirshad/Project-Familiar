using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName1;
    public string sceneName2;
    public AudioSource playSound;

    public UpgradeObject upgrade;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (upgrade.level2)
            {
                SceneManager.LoadScene(sceneName2);
            }
            else
            {
                SceneManager.LoadScene(sceneName1);
            }
            playSound.Play();
        }
    }
}