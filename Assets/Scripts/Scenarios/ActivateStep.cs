using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A step that is completed by activating one interactable in the list of activators
/// @Version: 1.0
/// @Authors: Leon Smit
/// </summary>
public class ActivateStep : Step
{

    public List<GameObject> activators;

    public override void OnActivate()
    {
        state = State.COMPLETED;
    }

    public override void OnRun()
    {
    }

    public override void OnStart()
    {
        AddToGameObjects();
    }

    public override void OnUpdate()
    {

    }

    private void AddToGameObjects()
    {
        foreach (GameObject go in activators)
        {
            StepHandler stepHandler = go.GetComponent<StepHandler>();

            if (stepHandler == null)
                stepHandler = go.AddComponent<StepHandler>();

            stepHandler.AddStep(GetComponent<Step>());
        }
    }
}
