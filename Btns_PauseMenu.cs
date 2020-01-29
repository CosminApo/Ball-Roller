using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Btns_PauseMenu : MonoBehaviour
{
    public AudioMixer audioMixer; //mixer controlling all audio
    public GameObject pauseMenu; //the current menu

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void mainMenu_btn()
    {
        FindObjectOfType<AudioManager>().Play("btnClick"); //play a sound
        SceneManager.LoadScene(0); //load the main menu scene
    }

    public void reload_btn()
    {
        FindObjectOfType<AudioManager>().Play("btnClick"); //play a sound
        Scene scene = SceneManager.GetActiveScene(); //get the current scene
        SceneManager.LoadScene(scene.name); //reload the current scene
    }

    public void close_btn()
    {
        FindObjectOfType<AudioManager>().Play("btnClick"); //play a sound
        pauseMenu.SetActive(false); //close the current menu
    }

}
