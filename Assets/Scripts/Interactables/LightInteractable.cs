using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to check in scenario if the light is active (Used in ConditionalStep)
/// 
/// @Version: 1.0
/// @Authors: Florian Molenaars
/// </summary>
public class LightInteractable : Interactable
{
    public override bool isActive()
    {
        return GetComponent<Light>().enabled;
    }

    public override void OnActivate()
    {
        // throw new System.NotImplementedException();
    }

    public override void OnDeselect()
    {
        // throw new System.NotImplementedException();
    }

    public override void OnSelect()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnStart()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        //throw new System.NotImplementedException();
    }
}
