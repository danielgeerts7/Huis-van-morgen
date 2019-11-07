using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainInteractable : Interactable
{
    public bool active = false;
    private Color startColor;
    public Color highlightColor;
    public Color activeColor;

    public GameObject leftCurtain;
    public GameObject rightCurtain;

    void Start()
    {
        startColor = leftCurtain.GetComponent<MeshRenderer>().material.color;
        Debug.Log(startColor);
    }
    public override void Activate()
    {
        if (active)
        {
            Debug.Log($"Deactivating {gameObject.name}");
            SetColor(highlightColor);
            active = false;

            leftCurtain.GetComponent<Animator>().Play("Close Curtain");
            rightCurtain.GetComponent<Animator>().Play("Close Curtain");
        }
        else
        {
            Debug.Log($"Activating {gameObject.name}");
            SetColor(activeColor);
            active = true;

            leftCurtain.GetComponent<Animator>().Play("Open Curtain");
            rightCurtain.GetComponent<Animator>().Play("Open Curtain");
        }
    }

    public override void Deselect()
    {
        if (!active) SetColor(startColor);
    }

    public override void Select()
    {
        if (!active) SetColor(highlightColor);
    }

    private void SetColor(Color color)
    {
        leftCurtain.GetComponent<MeshRenderer>().material.color = color;
        rightCurtain.GetComponent<MeshRenderer>().material.color = color;
    }
}
