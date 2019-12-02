using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scenario : MonoBehaviour
{
    public int scenarioID;
    // Strings to be displayed
    public string introText;
    public string introDescription;
    public string outroText;
    public string outroDescription;

    public List<Step> steps;

    private State state;
    private int activeStepIndex;
    private Step step;

    void Start()
    {
        state = State.WAITING;
    }

    public void Run()
    {
        if (!(state == State.WAITING))
            return;

        activeStepIndex = 0;
        step = steps[activeStepIndex];
        step.Run();
        state = State.RUNNING;
    }

    public string GetStepDescription()
    {
        return steps[activeStepIndex].GetStepName();
    }

    public bool StepCompleted()
    {
        if (step)
            return (step.getState() == State.COMPLETED);
        else
            return false;
    }

    public bool HasNextStep()
    { 
        return !(activeStepIndex + 1 >= steps.Count);
    }

    public void NextStep()
    {
        activeStepIndex++;
        step = steps[activeStepIndex];
        step.Run();
    }


}
