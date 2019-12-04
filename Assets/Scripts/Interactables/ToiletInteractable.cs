using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletInteractable : Interactable
{
    public override bool isActive()
    {
        throw new System.NotImplementedException();
    }

    public override void OnActivate()
    {


        if (GetComponent<StepHandler>())
        {

        }
    }

    public override void OnDeselect()
    {
        throw new System.NotImplementedException();
    }

    public override void OnSelect()
    {
        throw new System.NotImplementedException();
    }

    public override void OnStart()
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
}
