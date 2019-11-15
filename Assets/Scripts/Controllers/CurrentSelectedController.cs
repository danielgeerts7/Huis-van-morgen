using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CurrentSelectedController : MonoBehaviour
{
    public GameObject selectedHouseView;
    public GameObject selectedScenarioView;
    public GameObject selectedPersonaView;

    public GameObject startSimulation_btn;
    public GameObject resetSelectionView_Btn;

    private CurvedMenuController curvedController;

    private ConfigController.CardType currentTypeToSelect = ConfigController.CardType.HOUSE;

    private void Start()
    {
        curvedController = GameObject.FindObjectOfType<CurvedMenuController>();

        startSimulation_btn.SetActive(false);
        resetSelectionView_Btn.SetActive(false);
    }

    public void SelectCard(ConfigController.CardType cardtype, Sprite featuredimg, string description)
    {
        GameObject tempSelected = null;
        switch (cardtype) {
            case (ConfigController.CardType.HOUSE):
                tempSelected = selectedHouseView;
                break;
            case (ConfigController.CardType.SCENARIO):
                tempSelected = selectedScenarioView;
                break;
            case (ConfigController.CardType.PERSONA):
                tempSelected = selectedPersonaView;
                startSimulation_btn.SetActive(true);
                break;
        }
        tempSelected.GetComponent<CurrentSelected>().FillCurrentSelected(featuredimg, description);

        GoToNextSection();
    }

    public void StartSimulation()
    {
        string loadHouse = GameObject.FindObjectOfType<ConfigController>().GetSelectedHouse().houseName;
        SceneManager.LoadScene(loadHouse);
    }

    public void ResetSelectionCache() {
        // Clear views of selected House/Scenario/Persona
        selectedHouseView.GetComponent<CurrentSelected>().Reset();
        selectedScenarioView.GetComponent<CurrentSelected>().Reset();
        selectedPersonaView.GetComponent<CurrentSelected>().Reset();

        // Load Houses into Curved Menu
        curvedController.LoadHouseView();
        currentTypeToSelect = ConfigController.CardType.HOUSE;

        // Set buttons to invisible
        startSimulation_btn.SetActive(false);
        resetSelectionView_Btn.SetActive(false);
    }


    public void GoToNextSection() {
        resetSelectionView_Btn.SetActive(true);

        switch (currentTypeToSelect)
        {
            case (ConfigController.CardType.HOUSE):
                curvedController.LoadScenarioView();
                currentTypeToSelect = ConfigController.CardType.SCENARIO;
                break;
            case (ConfigController.CardType.SCENARIO):
                curvedController.LoadPersonaView();
                currentTypeToSelect = ConfigController.CardType.PERSONA;
                break;
            case (ConfigController.CardType.PERSONA):
                // Do nothing
                // Debug.Log("Selecting other PERSONA");
                break;
        }
    }
}
