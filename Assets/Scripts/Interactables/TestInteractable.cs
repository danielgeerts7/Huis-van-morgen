using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : Interactable
{
    private bool active = false;
    private Color startColor;
    public Color highlightColor;
    public Color activeColor;

    public override void OnActivate()
    {
        if (active)
        {
            Debug.Log($"Deactivating {gameObject.name}");
            SetColor(highlightColor);
            active = false;
        }
        else
        {
            Debug.Log($"Activating {gameObject.name}");
            SetColor(activeColor);
            active = true;
        }
    }

    public override void OnSelect()
    {
        //if (!active) SetColor(highlightColor);
        GetComponentInParent<Outline>().enabled = true;
    }

    public override void OnDeselect()
    {
        //if (!active) SetColor(startColor);
        GetComponentInParent<Outline>().enabled = false;
    }

    private void SetColor(Color color)
    {
        Renderer renderer = GetComponentInParent<Renderer>();
        renderer.material.color = color;
    }
    public override void OnStart()
    {
        GetComponentInParent<Outline>().enabled = false;
        Renderer renderer = GetComponentInParent<Renderer>();
        startColor = renderer.material.color;
        Debug.Log(startColor);
    }

    public override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GetComponentInParent<Outline>().color++;
        }
    }
}
