using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public void ResetSelectionCache() {
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
