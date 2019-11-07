using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioController : MonoBehaviour
{
    public GameObject scenarioObject;
    private ScenarioO scenario;
    private int currentStep = 0;
    private bool running = false;
    public GameObject stepText;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        SetScenario();
        DoIntro();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!running && startTime < Time.time - 5f)
        {
            Debug.Log($"StartTime: {startTime}");
            running = true;
            NextStep();
        }


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
        DisplayText(scenario.GetIntro());
        Debug.Log(scenario.GetIntro());
    }

    private void DoOutro()
    {
        DisplayText(scenario.GetOutro());
        Debug.Log(scenario.GetOutro());

    }

    public void NextStep()
    {
        if (currentStep < scenario.GetLength())
        {
            Debug.Log($"Starting step {currentStep + 1}");
            DisplayText(scenario.GetStepText(currentStep));
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

    private void DisplayText(string text)
    {
        stepText.GetComponent<Text>().text = text;
    }
}
