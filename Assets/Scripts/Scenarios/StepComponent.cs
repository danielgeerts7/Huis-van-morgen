using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StepComponent : MonoBehaviour
{
    protected Step step;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsRunning()
    {
        return step.IsRunning();
    }

    internal void Activate()
    {
        step.Activate();
    }

    internal bool IsComplete()
    {
        return step.IsComplete();
    }

    internal void addStep(Step step)
    {
        this.step = step;
    }
}
