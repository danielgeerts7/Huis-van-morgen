using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceInteractable : Interactable
{
    Rigidbody m_Rigidbody;
    float m_Speed;
    float startTime = 0;
    bool activated;

    public override bool isActive()
    {
        return activated;
    }

    public override void OnActivate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnDeselect()
    {
        throw new System.NotImplementedException();
    }

    public override void OnSelect()
    {
        throw new System.NotImplementedException();
    }

    public override void OnStart()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Speed = 10.0f;

        foreach (MeshRenderer meshRenderer in transform.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.enabled = false;
        }
    }

    // Update is called once per frame
    public override void OnUpdate()
    {
        StepHandler stepHandler = GetComponent<StepHandler>();
        if (stepHandler == null) return;

        if (stepHandler.IsActive())
        {
            if (!activated)
            {
                activated = true;
                foreach (MeshRenderer meshRenderer in transform.GetComponentsInChildren<MeshRenderer>())
                {
                    meshRenderer.enabled = true;
                }
            }

            MeshRenderer renderer = GetComponent<MeshRenderer>();
            renderer.enabled = true;

            if (gameObject.transform.position.x > 5)
            {
                if (startTime == 0)
                {
                    startTime = Time.time;
                }

                if (startTime + 1 < Time.time)
                {
                    stepHandler.Activate();
                }

            }
            else
            {

                m_Rigidbody.velocity = transform.forward * m_Speed;
            }

        }
    }
}
