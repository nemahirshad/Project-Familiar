using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //quits the game
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

}
 