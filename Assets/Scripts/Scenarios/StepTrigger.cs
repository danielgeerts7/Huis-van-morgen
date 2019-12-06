using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepTrigger : MonoBehaviour
{
    private StepHandler handler;
    private bool outlineIsOn;

    // Update is called once per frame
    void Update()
    {
        if (!handler)
        {
            handler = GetComponent<StepHandler>();
            return;
        }

        SetOutline(handler.IsActive());

        Debug.Log("handling steps");
    }

    private void OnTriggerEnter(Collider other)
    {
        handler = GetComponent<StepHandler>();

        if (handler == null)
            return;

        handler.Activate();
    }

    private void SetOutline(bool on)
    {
        if (on == outlineIsOn)
            return;

        Outline outline = GetComponent<Outline>();

        if (outline)
        {
            outline.enabled = on;
            outlineIsOn = on;
        }
    }
}
