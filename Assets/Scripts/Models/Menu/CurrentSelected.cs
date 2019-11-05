using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentSelected : MonoBehaviour
{
    public GameObject image;
    public GameObject description;

    private Sprite oldImg;
    private string oldText;

    private void Start()
    {
        oldImg = image.GetComponent<Image>().sprite;
        oldText = description.GetComponent<Text>().text;
    }

    public void FillCurrentSelected(Sprite newImage, string newText)
    {
        image.GetComponent<Image>().sprite = newImage;
        description.GetComponent<Text>().text = newText;

    }
    public void Reset()
    {
        image.GetComponent<Image>().sprite = oldImg;
        description.GetComponent<Text>().text = oldText;
    }
}
