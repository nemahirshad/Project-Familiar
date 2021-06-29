using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMainMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); //goes to the scene with the specific name
        Debug.Log("Loading to level1");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exiting");
    }
}
