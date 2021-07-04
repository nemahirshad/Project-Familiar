using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseUI;
    // Start is called before the first frame update
    void Start()
    {
       pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        Debug.Log("Resuming Game");
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        Debug.Log("Menu Popping Up");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Going to Main Menu");
    }
}
