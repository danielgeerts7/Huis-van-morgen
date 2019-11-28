using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateStep : Step
{
    public KeyCode activateKey = KeyCode.P;

    public override void OnActivate()
    {
        state = State.COMPLETED;
    }

    public void Update()
    {
        if (Input.GetKeyDown(activateKey))
        {
            state = State.COMPLETED;
        }
    }
}
