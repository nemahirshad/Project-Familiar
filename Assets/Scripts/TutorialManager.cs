using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{

    public GameObject tBox;
    public Text tText;
    public bool tutorialActive;
    public string [] tuTorialLines;
    public int currentLine;

   
    void Update()
    {
        if(tutorialActive && Input.GetKeyDown(KeyCode.Space))
        {
           currentLine++;
        }

        if(currentLine >= tuTorialLines.Length)
        {
            tBox.SetActive(false);
            tutorialActive = false;
            currentLine = 0;
        }
        tText.text = tuTorialLines[currentLine];
    }
    public void ShowBox(string tutorial)
    {
        tutorialActive = true;
        tBox.SetActive(true);
        tText.text = tutorial;
    }

    public void ShowLine()
    {
        tutorialActive = true;
        tBox.SetActive(true);
    }
}
