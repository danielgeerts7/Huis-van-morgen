using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenarioController : MonoBehaviour
{
    // Debug (variables are drawn in ScenarioControllerEditor)
    [HideInInspector] public bool scenarioIsActive = true;
    [HideInInspector] public bool debugMode;
    [HideInInspector] public int activeScenarioIndex = 0;

    public UIHandler UI;

    public List<Scenario> scenarios;
    private Scenario scenario;

    private State scenarioStateController;

    void Start()
    {
        UI = FindObjectOfType<UIHandler>();

        // Check for scenario in ConfigController
        ConfigController configController = FindObjectOfType<ConfigController>();

        if (configController == null)
        {
            if (debugMode)
            {
                if (!scenarioIsActive)
                    return;

                if (!(activeScenarioIndex >= 0 && activeScenarioIndex < scenarios.Count))
                    return;

                StartScenario();
            }
            return;
        }

        int activeScenarioID = configController.GetSelectedScenario().ID;

        bool scenarioFound = false;
        foreach (Scenario scenario in scenarios)
        {
            if (scenario.scenarioID == activeScenarioID)
            {
                activeScenarioIndex = scenarios.IndexOf(scenario);
                scenarioFound = true;
                break;
            }
        }
        if (!scenarioFound)
            return;

        StartScenario();
    }

    private void StartScenario()
    {
        scenario = scenarios[activeScenarioIndex];
        FindObjectOfType<PlayerController>().DisablePlayerControls();
        UI.DisplayIntro(scenario.introText, scenario.introDescription);
        scenario.InitializeScenario();
        Debug.Log(scenario.GetState());

        scenarioStateController = State.STARTED;
    }

    void Update()
    {
        if (!(scenarioStateController == State.RUNNING))
            return;

        if (!scenario.StepCompleted())
            return;

        if (scenario.HasNextStep())
        {
            scenario.NextStep();
            UI.DisplayStep(scenario.GetStepDescription());
        }
        else
        {
            FindObjectOfType<PlayerController>().DisablePlayerControls();
            UI.DisplayOutro(scenario.outroText, scenario.outroDescription);
            scenario.SetState(State.COMPLETED);
            scenarioStateController = State.COMPLETED;
        }
    }

    public void Activate()
    {
        switch (scenarioStateController)
        {
            case State.STARTED:
                scenario = scenarios[activeScenarioIndex];
                scenario.Run();
                FindObjectOfType<PlayerController>().EnablePlayerControls();
                UI.DisplayStep(scenario.GetStepDescription());
                scenarioStateController = State.RUNNING;
                break;
            case State.COMPLETED:
                FindObjectOfType<AudioManager>().StopAll();
                SceneManager.LoadScene("MenuScene");
                break;
            default:
                break;
        }
    }
}
