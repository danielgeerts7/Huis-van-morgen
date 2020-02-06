using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Use on a trigger object to make it active a Step
/// @Version: 1.0
/// @Authors: Leon Smit
/// </summary>
public class StepTrigger : MonoBehaviour
{
    private StepHandler stepHandler;

    private void Awake()
    {
        stepHandler = gameObject.AddComponent<StepHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        stepHandler.Activate();
    }
}
