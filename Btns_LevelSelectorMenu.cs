using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btns_LevelSelectorMenu : MonoBehaviour
{
    public GameObject levelSelectorMenu; //this menu
    public GameObject mainMenu; //the main menu

    public void level1Button()
    {
        FindObjectOfType<AudioManager>().Play("btnClick"); //play a sound
        SceneManager.LoadScene(1); //load the scene based on its name
    }
    public void level2Button()
    {
        FindObjectOfType<AudioManager>().Play("btnClick"); //play a sound
        SceneManager.LoadScene(2); //load the scene based on its name
    }
    public void level3Button()
    {
        FindObjectOfType<AudioManager>().Play("btnClick"); //play a sound
        SceneManager.LoadScene(3); //load the scene based on its name
    }
    public void level4Button()
    {
        FindObjectOfType<AudioManager>().Play("btnClick"); //play a sound
        SceneManager.LoadScene(4); //load the scene based on its name
    }
    public void backButton()
    {
        FindObjectOfType<AudioManager>().Play("btnClick"); //play a sound
        levelSelectorMenu.SetActive(false); //disable this menu
        mainMenu.SetActive(true); //enable main menu
    }


}
