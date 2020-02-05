using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// Author: Daniël Geerts
/// Generates curved VR menu
/// And, spawns the Houses, Scenario, Persona cards on a position
/// </summary>
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

    private float counter = 0.0f;
    private float delay = 5.0f;
    private bool doOnce = true;

    // Start is called before the first frame update
    void Start()
    {
        configController = GameObject.FindObjectOfType<ConfigController>();

        FindObjectOfType<AudioManager>().Play("menu-welkom");
    }

    private void Update()
    {
        counter += 1 * Time.deltaTime;
        if (counter >= delay && doOnce)
        {
            LoadHouseView();
            doOnce = false;
        }
    }

    // Clear view of all cards
    void ClearView() {
        foreach (GameObject obj in cardCopies) {
            Destroy(obj);
        }
        cardCopies.Clear();
    }

    // Load every house (from the JSON) into the Curved Menu
    public void LoadHouseView() {
        ClearView();
        int count = 0;

        foreach (HouseInfo house in configController.GetHouses())
        {
            if (count < 7)
            {
                GameObject card = GameObject.Instantiate(houseCardPrefab, CardSpawnpoints[count].transform);
                cardCopies.Add(card);
                card.GetComponent<HouseCard>().FillHouseCard(house);

                count++;
                bool activeButton = true;
                // todo: check if scene exists in Build Settings, if so set button on active, else it will be disabled
                card.GetComponentInChildren<Button>().interactable = activeButton;

            }
        }

        FindObjectOfType<AudioManager>().Play("menu-huis");
    }

    // Load every Scenario (from the JSON) into the Curved Menu
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

        FindObjectOfType<AudioManager>().Play("menu-scenario");
    }

    // Load every persona (from the JSON) into the Curved Menu
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

        FindObjectOfType<AudioManager>().Play("menu-persona");
    }
}
