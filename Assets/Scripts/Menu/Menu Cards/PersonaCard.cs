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
        GameObject.FindObjectOfType<AudioManager>().Play("ButtonClick");

        GameObject.FindObjectOfType<ConfigController>().SetSelectedPersona(persona);

        SelectionBarController selectionBar = GameObject.FindObjectOfType<SelectionBarController>();
        selectionBar.SetCardIntoBar(ConfigController.CardType.PERSONA, Resources.Load<Sprite>(persona.mugshotPath), persona.getFullName());
    }

    public void FillPersonaCard(PersonaInfo persona)
    {
        this.persona = persona;

        this.personaName.text = persona.getFullName();
        this.personaBiography.text = persona.biography;

        Rect a = this.personaBiography.rectTransform.rect;
        float height = persona.biography.Length * 1.25f;
        this.personaBiography.rectTransform.sizeDelta = new Vector2(a.width, height);
        Vector3 b = this.personaBiography.rectTransform.transform.position;
        b.y = -(height / 2);
        this.personaBiography.rectTransform.transform.position = b;


        this.personaAge.text = persona.age.ToString();
        this.personaImage.sprite = Resources.Load<Sprite>(persona.mugshotPath);
        this.personaImage.color = Color.white;

        string limitations = "";
        foreach (string limit in persona.limitations)
        {
            limitations += limit + "\n";
        }
        this.personaLimitation.text = limitations;
    }
}
