using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoInteractable : Interactable
{
    public string soundName;

    public override bool isActive()
    {
        return false;
    }

    public override void OnActivate()
    {
        FindObjectOfType<AudioManager>().Play(soundName);
    }

    public override void OnDeselect()
    {
        
    }

    public override void OnSelect()
    {
    }

    public override void OnStart()
    {
    }

    public override void OnUpdate()
    {
    }
}
