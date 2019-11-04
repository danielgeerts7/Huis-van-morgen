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

    public GameObject ConfigController;

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> panels = new List<GameObject> ();
        GameObject north = GameObject.Instantiate(panelPrefab, northSpawnpoint.transform);
        GameObject east = GameObject.Instantiate(panelPrefab, eastSpawnpoint.transform);
        GameObject south = GameObject.Instantiate(panelPrefab, southSpawnpoint.transform);
        GameObject west = GameObject.Instantiate(panelPrefab, westSpawnpoint.transform);

        panels.Add(north);
        panels.Add(east);
        panels.Add(south);
        panels.Add(west);

        List<Transform> CardSpawnpoints = new List<Transform>();

        foreach (GameObject obj in panels) {
            obj.SetActive(true);
            CardSpawnpoints.Add(obj.GetComponent<MenuPanel>().leftCard);
            CardSpawnpoints.Add(obj.GetComponent<MenuPanel>().rightCard);
        }

        ConfigController config = ConfigController.GetComponent<ConfigController>();
        int count = 0;

        foreach (Scenario s in config.GetScenarios()) {

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
                MenuCard cardcomponent = card.GetComponent<MenuCard>();
                cardcomponent.title.text = s.title;
                cardcomponent.image.sprite = s.image;
                cardcomponent.cardtype = MenuCard.CardType.SCENARIO;

                Debug.LogWarning("Loaded card title: " + s.title);

                count++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
