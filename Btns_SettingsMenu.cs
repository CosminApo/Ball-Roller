using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Btns_SettingsMenu : MonoBehaviour
{
    public GameObject settingsMenu; //this menu
    public GameObject mainMenu; //the main menu
    public AudioMixer audioMixer;
    public void setVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void backButton()
    {
        FindObjectOfType<AudioManager>().Play("btnClick"); //play a sound
        settingsMenu.SetActive(false); //disable this menu
        mainMenu.SetActive(true); //enable main menu
    }
}
