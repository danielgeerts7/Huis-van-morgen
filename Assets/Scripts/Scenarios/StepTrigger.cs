using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepTrigger : MonoBehaviour
{
    private StepHandler stepHandler;

    private void Awake()
    {
        stepHandler = gameObject.AddComponent<StepHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        stepHandler.Activate();
    }
}
