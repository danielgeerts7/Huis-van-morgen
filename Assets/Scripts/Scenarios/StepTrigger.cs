using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepTrigger : MonoBehaviour
{
    private Outline outline;
    private StepHandler stepHandler;

    private void Awake()
    {
        outline = gameObject.AddComponent<Outline>();
        stepHandler = gameObject.AddComponent<StepHandler>();
    }

    private void Start()
    {
        outline.color = 1;
    }

    private void Update()
    {
        outline.enabled = stepHandler.IsActive();
    }

    private void OnTriggerEnter(Collider other)
    {
        stepHandler.Activate();
    }
}
