﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/** 
 * Generates curved VR menu
 * Spawns the vr cards on right position
 *
 */
public class CurvedMenuController : MonoBehaviour
{
    // Cards
    public GameObject houseCardPrefab;
    public GameObject scenarioCardPrefab;
    public GameObject personaCardPrefab;


    public List<Transform> CardSpawnpoints;

    private List<GameObject> cardCopies = new List<GameObject>();

    // Config controller
    private ConfigController configController;

    // Start is called before the first frame update
    void Start()
    {
        configController = GameObject.FindObjectOfType<ConfigController>();
        LoadHouseView();
    }

    void ClearView() {
        foreach (GameObject obj in cardCopies) {
            Destroy(obj);
        }
        cardCopies.Clear();
    }

    public void LoadHouseView() {
        ClearView();
        int count = 0;

        foreach (HouseInfo house in configController.GetHouses())
        {
            if (count < 7)
            {
                GameObject card = GameObject.Instantiate(houseCardPrefab, CardSpawnpoints[count].transform);
                //GameObject houseObj = GameObject.Instantiate(house.prefabPath, CardSpawnpoints[count].transform);
                cardCopies.Add(card);
                card.GetComponent<HouseCard>().FillHouseCard(house);

                bool showCard = false;
                foreach (UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes)
                {
                    if (S.enabled)
                    {
                        string name = S.path.Substring(S.path.LastIndexOf('/') + 1);
                        name = name.Substring(0, name.Length - 6);
                        if (name.Equals(house.scene)) {
                            showCard = true;
                        }
                    }
                }
                count++;

                card.GetComponentInChildren<Button>().interactable = showCard;

            }
        }
    }

    public void LoadScenarioView() {
        ClearView();
        int count = 0;
        foreach (ScenarioInfo scenario in configController.GetScenarios()) {
            if (count < 7) {
                bool isAvailable = false;
                HouseInfo house = configController.GetSelectedHouse();
                foreach (int i in scenario.houseIDs)
                {
                    if (i == house.ID)
                    {
                        isAvailable = true;
                    }
                }
                if (isAvailable) {
                    GameObject card = GameObject.Instantiate(scenarioCardPrefab, CardSpawnpoints[count].transform);
                    cardCopies.Add(card);
                    card.GetComponent<ScenarioCard>().FillScenarioCard(scenario);
                    count++;
                }
            }
        }
    }

    public void LoadPersonaView() {
        ClearView();
        int count = 0;
        foreach (PersonaInfo persona in configController.GetPersonas()) {
            if (count < 7) {
                GameObject card = GameObject.Instantiate(personaCardPrefab, CardSpawnpoints[count].transform);
                cardCopies.Add(card);
                card.GetComponent<PersonaCard>().FillPersonaCard(persona);
                count++;
            }
        }
    }
}
