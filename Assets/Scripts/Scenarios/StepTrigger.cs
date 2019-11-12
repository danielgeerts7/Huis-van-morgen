using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepTrigger : MonoBehaviour
{
    public GameObject stepObject;
    private Step step;
    private bool isActivated;
    public bool highlightActive;

    // Start is called before the first frame update
    void Start()
    {
        SetStep();
        isActivated = false;
        SetHighlight(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActivated)
        {
            if (step.IsRunning())
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

    private void SetStep()
    {
        if (stepObject != null)
        {
            step = stepObject.GetComponent<Step>();
            step.GetComponentInParent<Interactable>();
        }

        Debug.Log(step);
        if (step == null)
        {
            Debug.LogWarning($"The following step does not contain a Step Component: {stepObject.name}");
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
