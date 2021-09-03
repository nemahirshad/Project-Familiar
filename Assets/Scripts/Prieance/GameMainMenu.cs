using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMainMenu : MonoBehaviour
{
    public UpgradeObject upgrade;

    public Bond bond;

    public void NewGame()
    {
        SceneManager.LoadScene("Greybox"); //goes to the scene with the specific name
        Debug.Log("Loading to level 1");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exiting");
    }

    public void ContinueScene()
    {
        SaveSlot data = SaveLoad.Load();

        upgrade.melee = data.melee;
        upgrade.ranged = data.ranged;
        upgrade.armor = data.armor;
        upgrade.health1 = data.health1;
        upgrade.health2 = data.health2;
        upgrade.health3 = data.health3;
        upgrade.level2 = data.level2;
        upgrade.canPass = data.canPass;

        bond.bond = data.bond;

        SceneManager.LoadScene(data.sceneName);
        Debug.Log("Loading Game Screen");
    }
}
