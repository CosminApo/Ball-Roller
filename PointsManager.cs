using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointsManager : MonoBehaviour
{
    public Text scoreText;//object that displays the text
    int score; //store the score of the player
    int multiplier; //score multiplier
    int multiplierDuration = 3; //store the duration of the multiplier
    public int defaultMultiplier = 1; //the default multiplier value
    public Slider totalCoins; //bar to display the amount of coins collected
    int coinsCollected = 0; //amount of coins the player has collected
    int counter = 0; //counter for the coins in the level
    public GameObject endGameUI; //UI for when the level ends

    void Start()
    {
        scoreText.text = "Score: " + score; //intialise score Text
        multiplier = defaultMultiplier; //init the multiplier
        countCoins(); //count the total coins on the screen
    }

    /// <summary>
    /// Use this to change the amount of points of the player
    /// </summary>
    /// <param name="value"> The amount to increase or decrement the points by </param>
    public void modifyPointsValue(int value)
    {
        coinsCollected++;
        score += value * multiplier; //update the score value
        scoreText.text = "Score: " + score; //update the score text;
    }

    /// <summary>
    /// Use this to change the score multiplier
    /// </summary>
    /// <param name="value"> The amount to increase or decrement the multiplier by </param>
    public void modifyMultiplierValue(int value)
    {
        multiplier += value; //update multiplier
    }

    /// <summary>
    /// Start as Coroutine. Use this to make the multiplier auto disable after a period of time
    /// </summary>
    public IEnumerator activateMultiplier()
    {
        yield return new WaitForSeconds(multiplierDuration); //wait for x seconds to pass
        multiplier = defaultMultiplier; //reset the multiplier      
    }

    /// <summary>
    /// Use this function to count the amount of coins in the level
    /// </summary>
    void countCoins()
    {
        GameObject[] coins;
        coins = GameObject.FindGameObjectsWithTag("PickUp"); //find all the coins in the level
        foreach (var obj in coins)
        {
            counter++; //increment the counter for ever coin
        }
        totalCoins.maxValue = counter;
    }

    void Update()
    {
        totalCoins.value = coinsCollected;
        if (coinsCollected == counter) //when the player has collected all the coins
        {
            endGameUI.SetActive(true); //end the game
        }
    }


}
