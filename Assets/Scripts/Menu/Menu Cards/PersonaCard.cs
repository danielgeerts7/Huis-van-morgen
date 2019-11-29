using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PersonaCard : SuperCard
{
    private PersonaInfo persona;

    public Text personaName;
    public Text personaBiography;
    public Text personaAge;
    public Text personaLimitation;
    public Image personaImage;

    private void Start()
    {
        button.GetComponentInChildren<Text>().text = "Selecteer " + persona.getFullName();
    }

    public override void SelectCard()
    {
        SelectionBarController currentSelectedController = GameObject.FindObjectOfType<SelectionBarController>();
        currentSelectedController.SelectCard(ConfigController.CardType.PERSONA, (Sprite)AssetDatabase.LoadAssetAtPath(persona.mugshotPath, typeof(Sprite)), persona.getFullName());
        GameObject.FindObjectOfType<ConfigController>().SetSelectedPersona(persona);
    }

    public void FillPersonaCard(PersonaInfo persona)
    {
        this.persona = persona;

        this.personaName.text = persona.getFullName();
        //this.personaBiography.text = persona.biography;
        this.personaAge.text = persona.age.ToString();
        this.personaImage.sprite = (Sprite)AssetDatabase.LoadAssetAtPath(persona.mugshotPath, typeof(Sprite));

        string limitations = "";
        /*foreach (string limit in persona.limitations)
        {
            limitations += limit + "\n";
        }*/
        this.personaLimitation.text = limitations;
    }
}
