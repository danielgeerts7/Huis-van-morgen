using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Put on a trigger object to activate a Light controller.
/// Turns lights on when player enters trigger, turns lights of after waitTime has expired.
/// 
/// @Version: 1.0
/// @Authors: Leon Smit
/// </summary>
public class LightSensor : MonoBehaviour
{
    public LightController lightController;
    public int waitTime = 5;

    private float lastTime;
    private bool countingDown;

    // Update is called once per frame
    void Update()
    {
        if (countingDown)
        {
            if (Time.time > lastTime + waitTime)
            {
                lightController.TurnOff();
                countingDown = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        countingDown = false;
        lightController.TurnOn();
    }

    private void OnTriggerExit(Collider other)
    {
        lastTime = Time.time;
        countingDown = true;
    }
}
