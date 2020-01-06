
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable
{
    public GameObject lightControllerObject;
    private LightController lightcontroller;

    // Start is called before the first frame update
    public override void OnStart()
    {
        lightcontroller = lightControllerObject.GetComponent<LightController>();
    }


    public override void OnUpdate()
    {
        // Gets called on update
    }

    public override void OnSelect()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnDeselect()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnActivate()
    {
        lightcontroller.Switch();
        GameObject.FindObjectOfType<AudioManager>().Play("Switch");
    }

    public override bool isActive()
    {
        return false;
    }
}
