using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateStep : Step
{

    public List<GameObject> activators;

    public override void OnActivate()
    {
        SetOutlines(false);
        state = State.COMPLETED;
    }

    public override void OnRun()
    {
        SetOutlines(true);
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

    private void SetOutlines(bool state)
    {
        foreach (GameObject activator in activators)
        {
            Debug.Log(activator.name);

            Outline outline = activator.GetComponent<Outline>();

            if (outline == null)
            {
                Debug.Log("In if");
                Debug.Log(activator.AddComponent<Outline>());
                outline = activator.AddComponent<Outline>();
            }


            //Debug.Log(state);
            //Debug.Log(outline);
            outline.enabled = state;
        }

    }
}
