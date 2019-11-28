using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public GameObject scenarioTitle;
    public GameObject scenarioInfo;
    public GameObject scenarioButton;

    // TODO: let UI class handle this
    public void DisplayIntro(string title, string info)
    {
        scenarioTitle.SetActive(true);
        scenarioTitle.GetComponentInChildren<Text>().text = title;

        scenarioInfo.SetActive(true);
        scenarioInfo.GetComponentInChildren<Text>().text = info;

        scenarioButton.SetActive(true);
        scenarioButton.GetComponentInChildren<Text>().text = "Start Scenario";
    }

    // TODO: let UI class handle this
    public void DisplayOutro(string title, string info)
    {
        scenarioTitle.SetActive(true);
        scenarioTitle.GetComponentInChildren<Text>().text = title;

        scenarioInfo.SetActive(true);
        scenarioInfo.GetComponentInChildren<Text>().text = info;

        scenarioButton.SetActive(true);
        scenarioButton.GetComponentInChildren<Text>().text = "Naar Menu";
    }

    // TODO: let UI class handle this
    public void DisplayStep(string title)
    {
        scenarioTitle.SetActive(true);
        scenarioInfo.SetActive(false);
        scenarioButton.SetActive(false);

        scenarioTitle.GetComponentInChildren<Text>().text = title;
    }

}
