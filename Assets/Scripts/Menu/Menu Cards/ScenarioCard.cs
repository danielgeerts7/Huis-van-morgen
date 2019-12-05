﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenarioCard : SuperCard
{
    private ScenarioInfo scenario;

    public Text title;
    public Image featuredImg;

    private void Start()
    {
        button.GetComponentInChildren<Text>().text = "Selecteer " + scenario.title;
    }

    public override void SelectCard()
    {
        GameObject.FindObjectOfType<ConfigController>().SetSelectedScenario(scenario);

        SelectionBarController selectionBar = GameObject.FindObjectOfType<SelectionBarController>();
        selectionBar.SetCardIntoBar(ConfigController.CardType.SCENARIO, Resources.Load<Sprite>(scenario.imagePath), scenario.title);
    }

    public void FillScenarioCard(ScenarioInfo scenario)
    {
        this.scenario = scenario;

        this.title.text = scenario.title;
        this.featuredImg.sprite = Resources.Load<Sprite>(scenario.imagePath);
        this.featuredImg.color = Color.white;
    }
}
