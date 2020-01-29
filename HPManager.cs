using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    int hp = 3; //used to store the current HP of the player
    public float iframeDuration; //store the duration of iframes after being hit (in seconds)
    Renderer rend; //used to change colour during iframes
    Color defaultColor; //used to store the default colour of the object
    public bool isInvulnerable = false; //if the player can take damage or not
    public int invulnDuration = 5; //duration of the invuln period
    public Text hpText; //object that displays the text
    public GameObject endGameUI; //UI for when the level ends

    void Start()
    {
        hpText.text = "x " + hp; //set HP text 
        rend = GetComponent<Renderer>(); //init renderer
        defaultColor = rend.material.color; //get default colour
    }

    /// <summary>
    /// Use this to change the amount of HP of the player
    /// </summary>
    /// <param name="value"> The amount to increase or decrement the HP by </param>
    public void modifyHPvalue(int value)
    {   
        hp += value;
        hpText.text = "x " + hp; //update HP tracker text
    }

    /// <summary>
    /// Start as Coroutine. Use this to trigger iFrames for the player
    /// </summary>
    public IEnumerator triggerIframes()
    {
        isInvulnerable = true; //make the player invuln
        rend.material.color = Color.red;  
        yield return new WaitForSeconds(iframeDuration); //wait for x seconds to pass
        isInvulnerable = false; //make the player vuln
        rend.material.color = defaultColor;
    }

    /// <summary>
    /// Use this to make the player invulnerable
    /// </summary>
    public void makePlayerInvuln()
    {
        isInvulnerable = true;
        activateInvuln();
        StartCoroutine(activateInvuln());
    }

    /// <summary>
    /// Start as Coroutine. Use this to make the player invulnerability end after a short period of time
    /// </summary>
    IEnumerator activateInvuln()
    {
        isInvulnerable = true; //make the player invuln
        rend.material.color = Color.yellow;
        yield return new WaitForSeconds(invulnDuration); //wait for x seconds to pass
        rend.material.color = defaultColor;
        isInvulnerable = false; //make the player vuln
    }

    void Update()
    {
        if (hp <= 0) //when the player has no more hp
        {
            endGameUI.SetActive(true); //end the game
        }
    }
}
