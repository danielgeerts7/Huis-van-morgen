using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMenuController : MonoBehaviour
{
    public GameObject selectedHouse;
    public GameObject selectedScenario;
    public GameObject selectedPersona;

    public void SelectCard(MenuCard.CardType cardtype, Sprite featuredimg, string description)
    {
        switch (cardtype) {
            case (MenuCard.CardType.HOUSE):
                selectedHouse.GetComponent<CurrentSelected>().image.GetComponent<Image>().sprite = featuredimg;
                selectedHouse.GetComponent<CurrentSelected>().description.GetComponent<Text>().text = description;
                break;
            case (MenuCard.CardType.SCENARIO):
                selectedScenario.GetComponent<CurrentSelected>().image.GetComponent<Image>().sprite = featuredimg;
                selectedScenario.GetComponent<CurrentSelected>().description.GetComponent<Text>().text = description;
                break;
            case (MenuCard.CardType.PERSONA):
                selectedPersona.GetComponent<CurrentSelected>().image.GetComponent<Image>().sprite = featuredimg;
                selectedPersona.GetComponent<CurrentSelected>().description.GetComponent<Text>().text = description;
                break;
        }
    }
}
