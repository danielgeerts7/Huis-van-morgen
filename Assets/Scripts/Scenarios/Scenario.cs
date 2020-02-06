using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Contains information about the scenario and initializes the scene based on parameters
/// Keeps track of the current step and provides information for ScenarioController
/// @Version: 1.0
/// @Authors: Leon Smit
/// </summary>
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
    public DayNightManager.DayPart scenarioDayPart;

    public List<Step> steps;

    private State state;
    private int activeStepIndex;
    private Step step;

    private bool isBeingUsed = false;

    void Start()
    {
        state = State.WAITING; 
    }

    public void InitializeScenario()
    {
        // Initialize scene based on bool parameters
        DomoticaController dom = GameObject.FindObjectOfType<DomoticaController>();
        dom.SwitchCurtainsWithoutAnimation(startWithCurtainsOpen);
        dom.SwitchLights(startWithLightsOn);
        GameObject.FindObjectOfType<DayNightManager>().SetDayPart(scenarioDayPart);

        // Teleports the player to the starting position of the scenario
        GameObject player = FindObjectOfType<PlayerController>().GetPlayer();
        player.transform.SetPositionAndRotation(startingPoint.transform.position, startingPoint.transform.rotation);

        isBeingUsed = true;
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
        if (activeStepIndex + 1 <= steps.Count - 1) {
            return true;
        }
        state = State.COMPLETED;

        Debug.Log(state + " is done");

        return false;
    }

    // Set activestep to next index
    public void NextStep()
    {
        activeStepIndex++;
        step = steps[activeStepIndex];
        step.Run();
    }
    public State GetState()
    {
        return state;
    }
    public void SetState(State newstate)
    {
        state = newstate;
    }

    public bool UsedAsPlayableScenario() {
        return isBeingUsed;
    }
}
