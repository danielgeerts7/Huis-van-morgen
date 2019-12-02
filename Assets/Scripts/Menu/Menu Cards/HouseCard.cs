using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        CurrentSelectedController currentSelectedController = GameObject.FindObjectOfType<CurrentSelectedController>();
        currentSelectedController.SelectCard(ConfigController.CardType.HOUSE, house.featuredImage, house.houseName);
        GameObject.FindObjectOfType<ConfigController>().SetSelectedHouse(house);
    }

    public void FillHouseCard(HouseInfo house)
    {
        this.house = house;

        this.title.text = house.houseName;
        this.featuredImg.sprite = house.featuredImage;
    }
}
