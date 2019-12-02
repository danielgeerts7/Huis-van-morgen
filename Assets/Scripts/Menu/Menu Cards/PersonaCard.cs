using System.Collections;
using System.Collections.Generic;
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
        CurrentSelectedController currentSelectedController = GameObject.FindObjectOfType<CurrentSelectedController>();
        currentSelectedController.SelectCard(ConfigController.CardType.PERSONA, persona.featuredImage, persona.getFullName());
        GameObject.FindObjectOfType<ConfigController>().SetSelectedPersona(persona);
    }

    public void FillPersonaCard(PersonaInfo persona)
    {
        this.persona = persona;

        this.personaName.text = persona.getFullName();
        this.personaBiography.text = persona.biography;
        this.personaAge.text = persona.age;
        this.personaImage.sprite = persona.featuredImage;

        string limitations = "";
        foreach (string limit in persona.limitations)
        {
            limitations += limit + "\n";
        }
        this.personaLimitation.text = limitations;
    }
}
