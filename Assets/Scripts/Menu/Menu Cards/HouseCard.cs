using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// Author: Daniël Geerts
/// subclasse: HouseCard is created for Huis-van-Morgen houses
/// </summary>
public class HouseCard : SuperCard
{
    private HouseInfo house;

    public Text title;
    public Image featuredImg;

    private void Start()
    {
        button.GetComponentInChildren<Text>().text = "Selecteer " + house.houseName;
    }

    public override void SelectCard()
    {
        GameObject.FindObjectOfType<AudioManager>().Play("ButtonClick");

        GameObject.FindObjectOfType<ConfigController>().SetSelectedHouse(house);

        SelectionBarController selectionBar = GameObject.FindObjectOfType<SelectionBarController>();
        selectionBar.SetCardIntoBar(ConfigController.CardType.HOUSE, Resources.Load<Sprite>(house.imagePath), house.houseName);
    }

    // Fill HouseCard with houseINFO, located in the huis-van-morgen.json
    public void FillHouseCard(HouseInfo house)
    {
        this.house = house;

        this.title.text = house.houseName;
        this.featuredImg.sprite = Resources.Load<Sprite>(house.imagePath);
        this.featuredImg.color = Color.white;
    }
}
