using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public GameObject stepObject;
    public Step step;
    private bool checkedStep;

    public abstract void Select();
    public abstract void Deselect();
    public abstract void OnActivate();

    public void Activate()
    {
        if (!checkedStep)
        {
            SetStep();
        }

        if (step)
        {
            step.Activate();
        }

        OnActivate();
    }

    private void SetStep()
    {
        step = stepObject.GetComponent<Step>();
        step.GetComponentInParent<Interactable>();

        Debug.Log(step);
        if (step == null)
        {
            Debug.LogError($"The following step does not contain a Step Component: {stepObject.name}");
        }

        checkedStep = true;
    }
}