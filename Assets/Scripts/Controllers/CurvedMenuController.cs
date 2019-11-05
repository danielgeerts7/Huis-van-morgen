using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedMenuController : MonoBehaviour
{
    // Panel
    public GameObject northSpawnpoint;
    public GameObject southSpawnpoint;
    public GameObject eastSpawnpoint;
    public GameObject westSpawnpoint;

    public GameObject panelPrefab;

    // Cards
    public GameObject leftCardPrefab;
    public GameObject rightCardPrefab;
    private List<GameObject> cardCopies = new List<GameObject>();
    List<Transform> CardSpawnpoints = new List<Transform>();

    // Config controller
    public ConfigController configController;

    // Start is called before the first frame update
    void Start()
    {
        configController = GameObject.FindObjectOfType<ConfigController>();

        List<GameObject> panels = new List<GameObject> ();
        GameObject north = GameObject.Instantiate(panelPrefab, northSpawnpoint.transform);
        GameObject east = GameObject.Instantiate(panelPrefab, eastSpawnpoint.transform);
        GameObject south = GameObject.Instantiate(panelPrefab, southSpawnpoint.transform);
        GameObject west = GameObject.Instantiate(panelPrefab, westSpawnpoint.transform);

        panels.Add(north);
        panels.Add(east);
        panels.Add(south);
        panels.Add(west);

        foreach (GameObject obj in panels) {
            obj.SetActive(true);
            CardSpawnpoints.Add(obj.GetComponent<MenuPanel>().leftCard);
            CardSpawnpoints.Add(obj.GetComponent<MenuPanel>().rightCard);
        }

        LoadHouseView();
    }

    void ClearView() {
        foreach (GameObject obj in cardCopies) {
            Destroy(obj);
        }
        cardCopies.Clear();
    }

    public void LoadHouseView()
    {
        ClearView();

        int count = 0;

        foreach (House h in configController.GetHouses())
        {

            if (count < 7)
            {
                GameObject card;

                //GameObject house = GameObject.Instantiate(h.housePrefab, CardSpawnpoints[count].transform);
                if (count % 2 == 0)
                {
                    card = GameObject.Instantiate(leftCardPrefab, CardSpawnpoints[count].transform);
                }
                else
                {
                    card = GameObject.Instantiate(rightCardPrefab, CardSpawnpoints[count].transform);
                }
                cardCopies.Add(card);
                MenuCard cardcomponent = card.GetComponent<MenuCard>();
                cardcomponent.title.text = h.houseName;
                cardcomponent.cardtype = MenuCard.CardType.HOUSE;
                count++;
            }
        }
    }

    public void LoadScenarioView() {
        ClearView();

        int count = 0;

        foreach (Scenario s in configController.GetScenarios())
        {

            if (count < 7)
            {
                GameObject card;
                if (count % 2 == 0)
                {
                    card = GameObject.Instantiate(leftCardPrefab, CardSpawnpoints[count].transform);
                }
                else
                {
                    card = GameObject.Instantiate(rightCardPrefab, CardSpawnpoints[count].transform);
                }
                cardCopies.Add(card);
                MenuCard cardcomponent = card.GetComponent<MenuCard>();
                cardcomponent.title.text = s.title;
                cardcomponent.image.sprite = s.image;
                cardcomponent.cardtype = MenuCard.CardType.SCENARIO;
                count++;
            }
        }
    }

    public void LoadPersonaView()
    {
        ClearView();

        int count = 0;

        foreach (Persona p in configController.GetPersonas())
        {

            if (count < 7)
            {
                GameObject card;
                if (count % 2 == 0)
                {
                    card = GameObject.Instantiate(leftCardPrefab, CardSpawnpoints[count].transform);
                }
                else
                {
                    card = GameObject.Instantiate(rightCardPrefab, CardSpawnpoints[count].transform);
                }
                cardCopies.Add(card);
                MenuCard cardcomponent = card.GetComponent<MenuCard>();
                cardcomponent.title.text = p.getFullName();
                cardcomponent.image.sprite = p.mugshot;
                cardcomponent.cardtype = MenuCard.CardType.PERSONA;
                count++;
            }
        }
    }
}
