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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectCard()
    {
        GameObject plyr = GameObject.FindGameObjectWithTag("Player");
        plyr.GetComponent<PlayerMenuController>().SelectCard(cardtype, image.sprite, title.text);
    }
}
