using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interactable used in DemoScene to show functions of Interactable class
/// 
/// @Version: 1.0
/// @Authors: Leon Smit
/// </summary>
public class CubeInteractable : Interactable
{
    private bool active;
    private bool rotate;
    public override bool isActive()
    {
        return active;
    }

    public override void OnActivate()
    {
        if (active)
        {
            GetComponent<Renderer>().material.color = Color.red;
            active = false;
        } else
        {
            GetComponent<Renderer>().material.color = Color.blue;
            active = true;
        }
    }

    public override void OnDeselect()
    {
        rotate = false;
    }

    public override void OnSelect()
    {
        rotate = true;
    }

    public override void OnStart()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public override void OnUpdate()
    {
        if (rotate)
        {
            transform.Rotate(5f * Time.deltaTime, 5f * Time.deltaTime, 5f * Time.deltaTime);
        }
    }
}
