using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeMovement : MonoBehaviour
{
    private bool hasGyro; //used to check if device supports Gyroscope
    private Gyroscope gyro; //used to store the gyroscope
    Rigidbody rb; //store Rigidbody of player
    float dirX; //used for velocity calculation
    float dirZ; //used for velocity calculaiton
    float movementSpeed; //the current movementspeed of the player
    public Vector3 defaultAcceleration; //the default acceleration of the player
    public int speedBoostDuration = 10; //duration of the speed boost
    public float defaultMovementSpeed; //default movement speed of the player
     

    void Start()
    {
        hasGyro = checkGyro(); //validate gyro
        rb = GetComponent<Rigidbody>();
        movementSpeed = defaultMovementSpeed;
        Time.timeScale = 1; //make sure the time is unfrozen
    }

    private bool checkGyro()
    {
        if (SystemInfo.supportsGyroscope) //if the system supports Gyroscope
        {
            gyro = Input.gyro; //set the gyroscope up
            gyro.enabled = true; //tell the system you have a gyroscope
            defaultAcceleration = Input.gyro.userAcceleration; //use this to chanmge the default position of the phone
            return true; 
        }
        return false; //if the system doesn't support Gyroscope
    }

    /// <summary>
    /// Use this to change the speed of the player
    /// </summary>
    /// <param name="value"> The amount to increase or decrement the speed by </param>
    public void modifySpeedValue(int value)
    {
        movementSpeed += value; //update multiplier
    }

    /// <summary>
    /// Start as Coroutine. Use this to make the speed boost auto disable after a period of time
    /// </summary>
    public IEnumerator activateSpeedBoost()
    {
        yield return new WaitForSeconds(speedBoostDuration); //wait for x seconds to pass
        movementSpeed = defaultMovementSpeed; //reset the speed
    }

    void Update()
    {
        dirX = (Input.acceleration.x - defaultAcceleration.x) * movementSpeed; //increase x position based on how tilted the phone is
        dirZ = (Input.acceleration.y - defaultAcceleration.y) * movementSpeed; //increase z position based on how tilted the phone is
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z); //move the player on screen
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector3(dirX, 0f, dirZ); //update the velocity of the player
    }


}
