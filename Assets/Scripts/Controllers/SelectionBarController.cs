using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// Author: Daniël Geerts
/// The SelectionBarController controls the Menu
/// When a House, Persona or Scenario is selected, then fill it into current seleciton bar and Load a new View from Curved Menu
/// </summary>
public class SelectionBarController : MonoBehaviour
{
    public GameObject selectedHouseView;
    public GameObject selectedScenarioView;
    public GameObject selectedPersonaView;

    public GameObject resetSelectionView_Btn;

    private CurvedMenuController curvedController;

    public GameObject loadingscreen;
    public Image LoadingBar;

    private ConfigController.CardType currentTypeToSelect = ConfigController.CardType.HOUSE;

    private void Start()
    {
        curvedController = GameObject.FindObjectOfType<CurvedMenuController>();

        resetSelectionView_Btn.SetActive(false);

        loadingscreen.SetActive(false);
    }

    // Which Cards need to be loaded into the Current Selection Bar
    public void SetCardIntoBar(ConfigController.CardType cardtype, Sprite featuredimg, string description)
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
                StartCoroutine(StartSimulation());
                break;
        }
        tempSelected.GetComponent<CurrentSelected>().FillCurrentSelected(featuredimg, description, Color.white);

        GoToNextSection();
    }

    // Start Simulation and get Loading screen while waiting
    public IEnumerator StartSimulation()
    {
        loadingscreen.SetActive(true);
        string houseSceneName = GameObject.FindObjectOfType<ConfigController>().GetSelectedHouse().scene;
        AsyncOperation async = SceneManager.LoadSceneAsync(houseSceneName);

        // todo: add loading bar and text with amount of percentes loaded
        while (!async.isDone)
        {
            LoadingBar.fillAmount = async.progress;

            yield return null;
        }

        loadingscreen.SetActive(false);
    }

    // Reset Current Selection Bar
    public void ResetSelectionCache() {
        GameObject.FindObjectOfType<AudioManager>().Play("ButtonClick");

        // Clear views of selected House/Scenario/Persona
        selectedHouseView.GetComponent<CurrentSelected>().Reset();
        selectedScenarioView.GetComponent<CurrentSelected>().Reset();
        selectedPersonaView.GetComponent<CurrentSelected>().Reset();

        // Load Houses into Curved Menu
        curvedController.LoadHouseView();
        currentTypeToSelect = ConfigController.CardType.HOUSE;

        // Set buttons to invisible
        resetSelectionView_Btn.SetActive(false);
    }

    // Move to next Section
    // From house to scenario
    // From scenario to persona
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
                // Not needed
                break;
        }
    }
}
