using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMainMenu : MonoBehaviour
{
    public SaveSlot save;

    public void NewGame()
    {
        SceneManager.LoadScene("0"); //goes to the scene with the specific name
        Debug.Log("Loading to level1");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exiting");
    }

    public void LoadGreybox()
    {
        SceneManager.LoadScene("Greybox");
        Debug.Log("Loading Greybox");
    }

    public void ContinueScene()
    {
        SceneManager.LoadScene(save.sceneName);
        Debug.Log("Loading Game Screen");
    }
}
