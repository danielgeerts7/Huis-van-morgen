using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoInteractable : Interactable
{
    public string soundName;
    public float turnspeed = 3f;
    public float delay = 0f;

    private float timeSpent;
    private bool activated = false;

    public override bool isActive()
    {
        return false;
    }

    public override void OnActivate()
    {
        FindObjectOfType<AudioManager>().Play(soundName);
        FindObjectOfType<PlayerController>().DisablePlayerControls();
        timeSpent = 0f;
        activated = true;
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
        transform.Rotate(0.0f, turnspeed * Time.deltaTime, 0.0f);
        if (activated){
            timeSpent += Time.deltaTime;
            if (delay < timeSpent)
            {
                FindObjectOfType<PlayerController>().EnablePlayerControls();
                activated = false;
            }
        }
    }
}
