using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btns_MainMenu : MonoBehaviour
{
    public GameObject levelSelectorMenu; //menu that allows you to select a level
    public GameObject mainMenu; //this menu
    public GameObject settingsMenu; //menu that allows you to change settings

    public void playButton()
    {
        FindObjectOfType<AudioManager>().Play("btnClick"); //play a sound
        mainMenu.SetActive(false); //disable this menu
        levelSelectorMenu.SetActive(true); //enable the selector menu
    }
    public void settingsButton()
    {
        FindObjectOfType<AudioManager>().Play("btnClick"); //play a sound
        mainMenu.SetActive(false); //disable this menu
        settingsMenu.SetActive(true); //enable the settings menu
    }

}
