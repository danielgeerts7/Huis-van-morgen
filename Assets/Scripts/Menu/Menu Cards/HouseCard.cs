using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
        GameObject.FindObjectOfType<ConfigController>().SetSelectedHouse(house);

        SelectionBarController selectionBar = GameObject.FindObjectOfType<SelectionBarController>();
        selectionBar.SetCardIntoBar(ConfigController.CardType.HOUSE, Resources.Load<Sprite>(house.imagePath), house.houseName);
    }

    public void FillHouseCard(HouseInfo house)
    {
        this.house = house;

        this.title.text = house.houseName;
        this.featuredImg.sprite = Resources.Load<Sprite>(house.imagePath);
        this.featuredImg.color = Color.white;
    }
}
