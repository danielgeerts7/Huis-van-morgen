using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioController : MonoBehaviour
{
    public GameObject scenarioObject;
    private ScenarioO scenario;
    private int currentStep = 0;
    private bool running;

    // Start is called before the first frame update
    void Start()
    {
        SetScenario();
        DoIntro();
        running = true;
        NextStep();
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            // Check if step is completed
            if (scenario.StepCompleted(currentStep))
            {
                Debug.Log($"Step {currentStep + 1} completed.");
                currentStep++;
                NextStep();
            }
        }
    }
    private void DoIntro()
    {
        Debug.Log(scenario.GetIntro());
    }

    private void DoOutro()
    {
        Debug.Log(scenario.GetOutro());
    }

    public void NextStep()
    {
        if (currentStep < scenario.GetLength())
        {
            Debug.Log($"Starting step {currentStep + 1}");
            scenario.RunStep(currentStep);
        }
        else
        {
            running = false;
            DoOutro();
        }
    }

    private void SetScenario()
    {
        scenario = scenarioObject.GetComponent<ScenarioO>();
    }
}
