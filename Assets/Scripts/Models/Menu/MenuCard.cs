using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCard : MonoBehaviour
{
    public Text title;
    public Image image;
    public Button button;

    public enum CardType { HOUSE, SCENARIO, PERSONA };
    public CardType cardtype;

    public PlayerMenuController playerMenuController;


    private void Start()
    {
        button.GetComponentInChildren<Text>().text = "Selecteer " + title.text;
    }

    public void SelectCard()
    {
        playerMenuController = GameObject.FindObjectOfType<PlayerMenuController>();
        playerMenuController.SelectCard(cardtype, image.sprite, title.text);
    }
}
