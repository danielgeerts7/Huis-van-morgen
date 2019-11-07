using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable
{
    public GameObject lightControllerObject;
    private LightController lightcontroller;

    // Start is called before the first frame update
    public void Start()
    {
        lightcontroller = lightControllerObject.GetComponent<LightController>();
    }

    public override void Select()
    {
        //throw new System.NotImplementedException();
    }

    public override void Deselect()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnActivate()
    {
        lightcontroller.Switch();
    }




}
