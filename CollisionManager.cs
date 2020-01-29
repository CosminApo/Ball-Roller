using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionManager : MonoBehaviour
{
    Rigidbody rb; //used to store the RB of the player
    HPManager hPManager;
    PointsManager pointsManager;
    GyroscopeMovement gyroscopeController;
    public Text powerUpText;
    public Image powerUpBg;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //intialise RigidBody
        hPManager = GetComponent<HPManager>(); //initialise hp manager
        pointsManager = GetComponent<PointsManager>(); //initialise points manager
        gyroscopeController = GetComponent<GyroscopeMovement>(); //initialise gyroscope controller manager
    }

    IEnumerator changeText(string text)
    {
        powerUpBg.gameObject.SetActive(true);//enable the background
        powerUpText.gameObject.SetActive(true); //activate powerup text
        powerUpText.text = text; //change text
        yield return new WaitForSeconds(3); //wait for x seconds to pass
        powerUpBg.gameObject.SetActive(false);//de activate text
        powerUpText.gameObject.SetActive(false);//disable background
    }

    void OnTriggerEnter(Collider other) //Triggered when the player collides with another object
    {
        //identify object based on tag
        if (other.gameObject.tag == "PickUp") //on collision with a coin
        {
            FindObjectOfType<AudioManager>().Play("pickUp");
            other.gameObject.SetActive(false); //make the object disappear
            pointsManager.modifyPointsValue(+1); //increase the points of the player
        }

        else if (other.gameObject.tag == "powerUp_ExtraHP") //on collision with an HP powerup
        {
            FindObjectOfType<AudioManager>().Play("powerup");
            StartCoroutine(changeText("Extra HP!"));
            other.gameObject.SetActive(false); //make the object disappear
            hPManager.modifyHPvalue(+1);
        }
        else if (other.gameObject.tag == "powerUp_2xMulti") //on collision with a 2x multiplier powerup
        {
            FindObjectOfType<AudioManager>().Play("powerup");
            StartCoroutine(changeText("2x Score Multiplier!"));
            other.gameObject.SetActive(false); //make the object disappear
            pointsManager.modifyMultiplierValue(+1); //update multiplier
            StartCoroutine(pointsManager.activateMultiplier()); //activate the multiplier bonus
        }
        else if (other.gameObject.tag == "powerUp_Speed") //on collision with a Speed powerup
        {
            FindObjectOfType<AudioManager>().Play("powerup");
            StartCoroutine(changeText("Extra Speed!"));
            other.gameObject.SetActive(false); //make the object disappear
            gyroscopeController.modifySpeedValue(+20); //update speed value
            StartCoroutine(gyroscopeController.activateSpeedBoost()); //activate the speed bonus
        }
        else if (other.gameObject.tag == "powerUp_Invuln") //on collision with a temporary invulnerability powerup
        {
            FindObjectOfType<AudioManager>().Play("powerup");
            StartCoroutine(changeText("Invulnerability!"));
            other.gameObject.SetActive(false); //make the object disappear
            hPManager.makePlayerInvuln(); //make the player invuln for a short period of time
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "DontPickUp") //on collision with the obstacle
        {
            if (!hPManager.isInvulnerable) //if the player is not invulnerable
            {
                FindObjectOfType<AudioManager>().Play("hit");
                hPManager.modifyHPvalue(-1); //decrease HP by 1
                StartCoroutine(hPManager.triggerIframes()); //trigger iFrames for the player
            }
        }
    }
}
