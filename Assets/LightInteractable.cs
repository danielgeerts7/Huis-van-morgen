﻿




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
