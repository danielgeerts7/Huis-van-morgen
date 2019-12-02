using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //Step variables
    public bool highlightOnStep;
    public bool highlightOnSelect;

    // Highlight, outline variables
    private bool hasOutline;
    private Outline outline;

    public abstract void OnActivate();
    public abstract void OnSelect();
    public abstract void OnDeselect();
    public abstract void OnStart();
    public abstract void OnUpdate();
    public abstract bool isActive();

    public void Start()
    {
        InitOutline();
        OnStart();
    }

    public void Update()
    {
        //if (hasStep && !stepActivated)
        //{
        //    if (step.IsRunning())
        //    {
        //        Debug.Log("check");
        //        stepActivated = true;
        //        if (hasOutline)
        //        {
        //            if (!outline.enabled && highlightOnStep)
        //            {
        //                outline.color = 0;
        //                outline.enabled = true;
        //            }
        //        }
        //    }
        //}

        OnUpdate();
    }
    public void Activate()
    {
        StepHandler stepHandler = GetComponent<StepHandler>();
        if (stepHandler != null)
            stepHandler.Activate();


        //if (hasStep)
        //{
        //    step.Activate();

        //    if (stepActivated && !step.IsRunning())
        //    {
        //        stepActivated = false;
        //        if (hasOutline && !highlightOnSelect)
        //        {
        //            outline.enabled = false;
        //        }
        //    }
        //}

        Debug.Log("Activating object");
        OnActivate();
    }

    public void Select()
    {
        if (hasOutline && highlightOnSelect)
        {
            SetOutline(true);
        }
        OnSelect();
    }

    public void Deselect()
    {
        if (hasOutline && highlightOnSelect)
            SetOutline(false);

        OnDeselect();
    }

    private void InitStep()
    {
        //// If there is a step object, get the step component from it.
        //hasStep = false;

        //step = GetComponent<StepComponent>();
        //if (step != null)
        //{
        //    hasStep = true;
        //}
    }

    private void InitOutline()
    {
        hasOutline = false;

        if (GetComponent<Outline>())
        {
            outline = GetComponent<Outline>();
            SetOutline(false);
            hasOutline = true;
        }
    }

    private void SetOutline(bool state)
    {
        outline.color = 1; // Set color in OutlineEffect Component of camera
        outline.enabled = state;

        //// If object is not selected, but step is active: give highlight of different color;
        //if (highlightOnStep && stepActivated && !state)
        //{
        //    outline.color = 0;
        //    outline.enabled = true;
        //}
    }
}