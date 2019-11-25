using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenarioController : MonoBehaviour
{
    public bool active;
    public ScenarioO scenario;
    private int currentStep = 0;
    private bool started = false;
    private bool running = false;
    public GameObject stepText;
    public GameObject infoText;
    public GameObject infoButton;
    private bool finished;


    // Start is called before the first frame update
    void Start()
    {
        if (active)
        {
            scenario.Start();
            DoIntro();
        }
    }

    public void Activate()
    {
        if (active)
        {
            if (!finished)
            {
                running = true;
                NextStep();
            }
            else
            {
                SceneManager.LoadScene("MenuScene");
            }
        }
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
        DisplayName(scenario.GetIntro());
        infoText.SetActive(true);
        infoButton.SetActive(true);
        DisplayInfo(scenario.GetIntroDescription());
        Debug.Log(scenario.GetIntro());
    }

    private void DoOutro()
    {
        finished = true;
        infoText.SetActive(true);
        infoButton.GetComponentInChildren<Text>().text = "Terug naar menu";
        infoButton.SetActive(true);
        float endTime = Time.time;
        DisplayName(scenario.GetOutro());
        DisplayInfo(scenario.GetOutroDescription());
        Debug.Log(scenario.GetOutro());

    }

    public void NextStep()
    {
        infoText.SetActive(false);
        infoButton.SetActive(false);

        if (currentStep < scenario.GetLength())
        {
            Debug.Log($"Starting step {currentStep + 1}");
            DisplayName(scenario.GetStepText(currentStep));
            scenario.RunStep(currentStep);
        }
        else
        {
            running = false;
            DoOutro();
        }
    }

    private void DisplayName(string text)
    {
        stepText.SetActive(true);
        stepText.GetComponentInChildren<Text>().text = text;
    }

    private void DisplayInfo(string info)
    {
        infoText.SetActive(true);
        infoButton.SetActive(true);
        infoText.GetComponentInChildren<Text>().text = info;
    }
}
