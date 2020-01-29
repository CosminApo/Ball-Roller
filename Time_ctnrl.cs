using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_ctnrl : MonoBehaviour
{

    public GameObject endGameUI;
    public GameObject pauseUI;

    // Update is called once per frame
    void Update()
    {
        if (endGameUI.active == true || pauseUI.active == true) // if the end game menu or the pause menu is active
        {
            Time.timeScale = 0; //freeze time
        }
        else
        {
            Time.timeScale = 1; //unfreeze time
        }
    }
}
