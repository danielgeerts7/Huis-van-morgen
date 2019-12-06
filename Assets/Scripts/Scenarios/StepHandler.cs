using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepHandler : MonoBehaviour
{
    public List<Step> steps;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        foreach(Step step in steps)
        {
            step.Activate();
        }
    }

    public void AddStep(Step step)
    {
        if (steps == null)
        {
            steps = new List<Step>();
        }
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
