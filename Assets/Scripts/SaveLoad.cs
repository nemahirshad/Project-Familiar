using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    public SaveSlot save;

    public void Save()
    {
        save.sceneName = SceneManager.GetActiveScene().name;
    }

    public void Load()
    {
        SceneManager.LoadScene(save.sceneName);
    }
}
