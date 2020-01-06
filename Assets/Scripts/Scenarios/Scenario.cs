using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scenario : MonoBehaviour
{
    public GameObject startingPoint;

    public int scenarioID;
    // Strings to be displayed
    [TextArea]
    public string introText;
    [TextArea]
    public string introDescription;
    [TextArea]
    public string outroText;
    [TextArea]
    public string outroDescription;

    public bool startWithCurtainsOpen = false;
    public bool startWithLightsOn = false;
    public bool startInNightTime = false;

    public List<Step> steps;

    private State state;
    private int activeStepIndex;
    private Step step;

    private void Awake()
    {
        GameObject player = FindObjectOfType<PlayerController>().GetPlayer();
        player.transform.SetPositionAndRotation(startingPoint.transform.position, startingPoint.transform.rotation);
    }

    void Start()
    {
        state = State.WAITING;

        GameObject player = FindObjectOfType<PlayerController>().GetPlayer();
        player.transform.SetPositionAndRotation(startingPoint.transform.position, startingPoint.transform.rotation);
    }

    public void InitializeScenario()
    {
        DomoticaController dom = GameObject.FindObjectOfType<DomoticaController>();
        dom.SwitchCurtainsWithoutAnimation(startWithCurtainsOpen);
        dom.SwitchLights(startWithLightsOn);

        GameObject player = FindObjectOfType<PlayerController>().GetPlayer();
        player.transform.SetPositionAndRotation(startingPoint.transform.position, startingPoint.transform.rotation);
    }

    public void Run() {
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
