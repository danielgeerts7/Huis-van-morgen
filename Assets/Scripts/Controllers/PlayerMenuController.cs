using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMenuController : MonoBehaviour
{
    public GameObject selectedHouse;
    public GameObject selectedScenario;
    public GameObject selectedPersona;

    public GameObject startSimButton;
    public GameObject resetSelectionButton;

    private CurvedMenuController curvedController;
    private MenuCard.CardType currentSelector = MenuCard.CardType.HOUSE;

    private void Start()
    {
        curvedController = GameObject.FindObjectOfType<CurvedMenuController>();

        startSimButton.SetActive(false);
        resetSelectionButton.SetActive(false);
    }

    public void SelectCard(MenuCard.CardType cardtype, Sprite featuredimg, string description)
    {
        GameObject tempSelected = null;
        switch (cardtype) {
            case (MenuCard.CardType.HOUSE):
                tempSelected = selectedHouse;
                break;
            case (MenuCard.CardType.SCENARIO):
                tempSelected = selectedScenario;
                break;
            case (MenuCard.CardType.PERSONA):
                tempSelected = selectedPersona;
                startSimButton.SetActive(true);
                break;
        }
        tempSelected.GetComponent<CurrentSelected>().FillCurrentSelected(featuredimg, description);

        GoToNextSection();
    }

    public void StartSimulation()
    {
        SceneManager.LoadScene("DemoScene");
    }

    public void ResetSelectionCache() {
        selectedHouse.GetComponent<CurrentSelected>().Reset();
        selectedScenario.GetComponent<CurrentSelected>().Reset();
        selectedPersona.GetComponent<CurrentSelected>().Reset();
        curvedController.LoadHouseView();
        currentSelector = MenuCard.CardType.HOUSE;
        startSimButton.SetActive(false);
        resetSelectionButton.SetActive(false);
    }


    public void GoToNextSection() {
        resetSelectionButton.SetActive(true);

        switch (currentSelector)
        {
            case (MenuCard.CardType.HOUSE):
                curvedController.LoadScenarioView();
                currentSelector = MenuCard.CardType.SCENARIO;
                break;
            case (MenuCard.CardType.SCENARIO):
                curvedController.LoadPersonaView();
                currentSelector = MenuCard.CardType.PERSONA;
                break;
            case (MenuCard.CardType.PERSONA):
                // Do nothing
                Debug.LogError("This button should not be visible");
                break;
        }

        Debug.LogWarning("Switching to next section " + currentSelector);
    }
}
