using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialHolder : MonoBehaviour
{
    public GameObject tBox;
    private TutorialManager tMAn;
    public string[] tutorialLines;
    
    void Start()
    {
        tMAn = FindObjectOfType<TutorialManager>();
    }
     void Update()
    {
        if (Input.GetKey(KeyCode.Backspace))
        {
            Debug.Log("backspace");
            Destroy(tMAn);
            Destroy(tBox);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        
        if(other.gameObject.name == "Player")
        {
            if (!tMAn.tutorialActive)
            {
                tMAn.tuTorialLines = tutorialLines;
                tMAn.currentLine = 0;
                tMAn.ShowLine();
            }
            if (Input.GetKey(KeyCode.Backspace))
            {
                Debug.Log("backspace");
                Destroy(tMAn);
                Destroy(tBox);
            }
        }
    }
}
