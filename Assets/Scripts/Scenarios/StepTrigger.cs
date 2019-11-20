using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepTrigger : MonoBehaviour
{
    public StepComponent step;
    private bool isActivated;
    public bool highlightActive;

    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;
        SetHighlight(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActivated)
        {
            if (!step)
             step = GetComponent<StepComponent>();

            if (step && step.IsRunning())
            {
                SetHighlight(true);
                isActivated = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        step.Activate();
        if (step.IsComplete())
        {
            SetHighlight(false);
        }
    }

    private void SetHighlight(bool state)
    {
        if (highlightActive)
        {
            GetComponentInParent<Outline>().enabled = state;
        } else
        {
            GetComponentInParent<Outline>().enabled = false;
        }
    }
}
