using System.Collections.Generic;
using UnityEngine;

public class StepHandler : MonoBehaviour
{
    private List<Step> steps;

    private void Awake()
    {
        steps = new List<Step>();
    }

    public void Activate()
    {
        foreach (Step step in steps)
        {
            step.Activate();
        }
    }

    public void AddStep(Step step)
    {
        steps.Add(step);
    }

    public bool IsActive()
    {
        foreach (Step step in steps)
            if (step.getState() == State.RUNNING)
                return true;

        return false;
    }
}