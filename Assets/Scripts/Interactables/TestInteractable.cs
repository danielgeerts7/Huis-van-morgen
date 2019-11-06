﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : Interactable
{
    private bool active = false;
    private Color startColor;
    public Color highlightColor;
    public Color activeColor;

    public void Start()
    {
        Renderer renderer = GetComponentInParent<Renderer>();
        startColor = renderer.material.color;
        Debug.Log(startColor);
    }
    public override void Activate()
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
        Renderer renderer = GetComponentInParent<Renderer>();
        renderer.material.color = color;
    }
}