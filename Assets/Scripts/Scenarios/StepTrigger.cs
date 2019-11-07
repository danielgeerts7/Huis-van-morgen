using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepTrigger : MonoBehaviour
{
    public GameObject stepObject;
    private Step step;
    private Renderer renderer;
    private bool isActivated;

    // Start is called before the first frame update
    void Start()
    {
        SetStep();
        isActivated = false;
        renderer = GetComponent<Renderer>();
        renderer.material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActivated)
        {
            if (step.IsRunning())
            {
                isActivated = true;
                renderer.material.color = Color.yellow;
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        step.Activate();
        if (step.IsComplete())
        {
            renderer.material.color = Color.green;
        }
    }

    private void SetStep()
    {
        step = stepObject.GetComponent<Step>();
        step.GetComponentInParent<Interactable>();

        Debug.Log(step);
        if (step == null)
        {
            Debug.LogError($"The following step does not contain a Step Component: {stepObject.name}");
        }
    }

    
}
