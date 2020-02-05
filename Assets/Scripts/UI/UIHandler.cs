using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles the UI elements in the scene, created for scenarios.
/// @Version: 1.0
/// @Authors: Leon Smit
/// </summary>
public class UIHandler : MonoBehaviour
{
    public GameObject scenarioTitle;
    public GameObject scenarioInfo;
    public GameObject scenarioButton;

    // Displays title and info provided in the correct components
    // Adds listener for button to activate the scene
    public void DisplayIntro(string title, string info)
    {
        scenarioTitle.SetActive(true);
        scenarioTitle.GetComponentInChildren<Text>().text = title;

        scenarioInfo.SetActive(true);
        scenarioInfo.GetComponentInChildren<Text>().text = info;

        scenarioButton.SetActive(true);
        scenarioButton.GetComponent<Button>().onClick.AddListener(delegate
        {
            FindObjectOfType<ScenarioController>().Activate();
        });
        scenarioButton.GetComponentInChildren<Text>().text = "Start Scenario";
    }

    // Displays title and info provided in the correct components
    public void DisplayOutro(string title, string info)
    {
        scenarioTitle.SetActive(true);
        scenarioTitle.GetComponentInChildren<Text>().text = title;

        scenarioInfo.SetActive(true);
        scenarioInfo.GetComponentInChildren<Text>().text = info;

        scenarioButton.SetActive(true);
        scenarioButton.GetComponentInChildren<Text>().text = "Naar Menu";
    }

    // Displays text in StepComponent on top of screen.
    public void DisplayStep(string title)
    {
        scenarioTitle.SetActive(true);
        scenarioInfo.SetActive(false);
        scenarioButton.SetActive(false);

        scenarioTitle.GetComponentInChildren<Text>().text = title;
    }

}
