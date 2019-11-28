using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenarioController : MonoBehaviour
{
    // Debug
    [HideInInspector] public bool scenarioIsActive = true;
    [HideInInspector] public bool debugMode;
    [HideInInspector] public int activeScenarioIndex = 0;

    //UI
    public UIHandler UI;

    // Scenarios
    public List<Scenario> scenarios;
    private Scenario scenario;

    private State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.WAITING;

        // If Debug Mode is enabled, handle it
        if (debugMode)
        {
            if (scenarioIsActive && activeScenarioIndex >= 0 && activeScenarioIndex < scenarios.Count)
            {
                scenario = scenarios[activeScenarioIndex];
                state = State.STARTED;
                UI.DisplayIntro(scenario.introText, scenario.introDescription);             
                return;
            }
            else
            {
                return;
            }
        }

        // If debug mode is not enabled:
        // Find scenario with ID from menu
        bool scenarioFound = false;

        ConfigController configController = FindObjectOfType<ConfigController>();
        if (configController != null)
        {
            int scenarioID = configController.GetSelectedScenario().ID;

            foreach (Scenario scenario in scenarios)
            {
                if (scenario.scenarioID == scenarioID)
                {
                    activeScenarioIndex = scenarios.IndexOf(scenario);
                    scenarioFound = true;
                    break;
                }
            }
        }

        // If no scenario is found, stop Scenario Controller
        if (!scenarioFound)
            return;

        scenario = scenarios[activeScenarioIndex];
        UI.DisplayIntro(scenario.introText, scenario.introDescription);
        state = State.STARTED;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.RUNNING)
        {
            Debug.Log("Running");
            if (scenario.StepCompleted())
            {
                if (scenario.HasNextStep())
                {
                    scenario.NextStep();
                    UI.DisplayStep(scenario.GetStepDescription());
                }
                else
                {
                    UI.DisplayOutro(scenario.outroText, scenario.outroDescription);
                    state = State.COMPLETED;
                }
            }
        }
    }

    public void ActivateScenario()
    {
        if (state == State.STARTED)
        {
            scenario = scenarios[activeScenarioIndex];
            scenario.Run();
            state = State.RUNNING;

            UI.DisplayStep(scenario.GetStepDescription());
        }
        else if (state == State.COMPLETED)
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
