using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    private float maxSpeed = 13f;
    private float minSpeed = 5f;
    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartingSpeed();
    }

    public void StartingSpeed()
    {
        SpeedValues.PlayerSpeed = 5f;
        SpeedValues.CameraSpeed = 5f;
        SpeedValues.BackgroundSpeed = 0.5f;
        SpeedValues.ScoreSpeed = 0.0001f;
        currentSpeed = 5f;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            IncreaseSpeed();
        }else if(Input.GetKey(KeyCode.LeftArrow))
        {
            DecreaseSpeed();
        }
    }

    private void IncreaseSpeed()
    {
        if (currentSpeed < maxSpeed)
        {
            Debug.Log(SpeedValues.PlayerSpeed);
            SpeedValues.PlayerSpeed += 0.5f;
            SpeedValues.CameraSpeed += 0.5f;
            SpeedValues.BackgroundSpeed += 0.1f;
            SpeedValues.ScoreSpeed += 0.0001f;
            currentSpeed += 0.5f;
        }
    }

    private void DecreaseSpeed()
    {
        if (currentSpeed > minSpeed)
        {
            SpeedValues.PlayerSpeed -= 0.5f;
            SpeedValues.CameraSpeed -= 0.5f;
            SpeedValues.BackgroundSpeed -= 0.1f;
            SpeedValues.ScoreSpeed -= 0.0001f;
            currentSpeed -= 0.5f;
            Debug.Log(SpeedValues.PlayerSpeed);
        }
    }
}
