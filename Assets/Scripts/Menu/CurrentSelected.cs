using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Author: Daniël Geerts
/// After selecting a Card in de Curved (VR) Menu
/// Then this class can save the info into the Current Selection Bar
/// </summary>
public class CurrentSelected : MonoBehaviour
{
    public GameObject image;
    public GameObject description;

    private Sprite oldImg;
    private Color oldColor;
    private string oldText;

    private void Start()
    {
        oldImg = image.GetComponent<Image>().sprite;
        oldColor = image.GetComponent<Image>().color;
        oldText = description.GetComponent<Text>().text;
    }

    // Fill Current Selected INFO in the Selection Bar
    public void FillCurrentSelected(Sprite newImage, string newText, Color color)
    {
        image.GetComponent<Image>().sprite = newImage;
        image.GetComponent<Image>().color = color;
        description.GetComponent<Text>().text = newText;

    }

    // Reset Current Selected INFO
    public void Reset()
    {
        image.GetComponent<Image>().sprite = oldImg;
        image.GetComponent<Image>().color = oldColor;
        description.GetComponent<Text>().text = oldText;
    }
}
