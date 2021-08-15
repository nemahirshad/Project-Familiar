using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    public SaveSlot save;

    public GameObject player;

    public void Save()
    {
        save.sceneName = SceneManager.GetActiveScene().name;
        save.position = player.transform.position;
    }

    public void Load()
    {
        SceneManager.LoadScene(save.sceneName);
        player.transform.position = save.position;
    }
}
