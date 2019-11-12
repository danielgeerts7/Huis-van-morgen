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


    public override void OnActivate()
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

    public override void OnDeselect()
    {
        if (!active) SetColor(startColor);
    }

    public override void OnSelect()
    {
        if (!active) SetColor(highlightColor);
    }

    private void SetColor(Color color)
    {
        //leftCurtain.GetComponent<MeshRenderer>().material.color = color;
        //rightCurtain.GetComponent<MeshRenderer>().material.color = color;
    }

    public override void OnUpdate()
    {
        
    }

    public override void OnStart()
    {
        if (active)
        {
            leftCurtain.GetComponent<Animator>().Play("Open Curtain");
            rightCurtain.GetComponent<Animator>().Play("Open Curtain");
        }

        startColor = leftCurtain.GetComponent<MeshRenderer>().material.color;
        Debug.Log(startColor);
    }
}
