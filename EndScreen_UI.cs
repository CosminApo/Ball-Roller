using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen_UI : MonoBehaviour
{
    public GameObject player;
    PointsManager pointsManager;
    public Slider totalCoins; //bar to display the amount of coins collected
    public Object mainMenuScene; //the scene containing the main menu
    public GameObject winScreen; //screen to show if the player has cleared the level
    public GameObject loseScreen; //screen to show if the player has lost
    public GameObject nextLevelBtn; //buttons used for a special case
    public GameObject reloadBtn;
    public Text ingameScoreText;
    public Text menuScoreText;
    public GameObject inGameUI;


    void OnEnable()
    {
        inGameUI.SetActive(false);
        pointsManager = player.GetComponent<PointsManager>(); //get the points info from the player obj       
        totalCoins.maxValue = pointsManager.totalCoins.maxValue;
        totalCoins.value = pointsManager.totalCoins.value;
        decideUI(); //figure out if the player has won or not
        menuScoreText.text = ingameScoreText.text;
        Time.timeScale = 0;
    }

    void decideUI()
    {
        if (totalCoins.value < totalCoins.maxValue) //if the player has not collected all coins
        {
            loseScreen.SetActive(true); 
        }
        else
        {
            winScreen.SetActive(true);
            Scene scene = SceneManager.GetActiveScene(); //get the current scene
            if (!(scene.buildIndex < SceneManager.sceneCountInBuildSettings - 1)) //if there isnt a next scene
            {
                //replace the next level button with the reload button
                nextLevelBtn.SetActive(false);
                reloadBtn.SetActive(true);
            }
        }
    }

    public void levelSelectorButton()
    {
        FindObjectOfType<AudioManager>().Play("btnClick"); //play a sound
        SceneManager.LoadScene(0); //load the main menu scene
    }

    public void nextLevelButton()
    {
        FindObjectOfType<AudioManager>().Play("btnClick"); //play a sound
        Scene scene = SceneManager.GetActiveScene(); //get the current scene
        SceneManager.LoadScene(scene.buildIndex + 1); //load the next scene if available
    
    }
    public void restartLevelButton()
    {
        FindObjectOfType<AudioManager>().Play("btnClick"); //play a sound
        Scene scene = SceneManager.GetActiveScene(); //get the current scene
        SceneManager.LoadScene(scene.name); //reload the current scene
    }
}
