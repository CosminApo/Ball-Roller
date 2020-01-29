using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btns_InGameUI : MonoBehaviour
{
    public GameObject pauseMenu; //store the game menu here
  

    public void pauseButton()
    {
        FindObjectOfType<AudioManager>().Play("btnClick"); //play a sound
        pauseMenu.SetActive(true);
    }



}
