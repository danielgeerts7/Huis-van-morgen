using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightsout : MonoBehaviour
{
    public Light directionalMain;
    public Light directionalSupport;


    void Start()
    {
        foreach (Light light in FindObjectsOfType<Light>())
        {
            light.intensity = 1.0f;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SetLights(0.25f, 0.25f, 0.1f);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SetLights(0.5f, 0.25f, 0.3f);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SetLights(0.75f, 0.5f, 0.4f);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            SetLights(1f, 0.75f, 0.4f);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            SetLights(1f, 1f, 0.5f);

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            foreach (Light light in FindObjectsOfType<Light>())
            {
                if (!(light == directionalMain || light == directionalSupport))
                {
                    light.enabled = !light.enabled;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
            foreach (Light light in FindObjectsOfType<Light>())
            {
                if (!(light == directionalMain || light == directionalSupport))
                {
                    light.intensity = 1.0f;
                }
            }

    }

    private void SetLights ( float main, float support, float rest)
    {
        foreach (Light light in FindObjectsOfType<Light>())
        {
            light.intensity = rest;
        }
        directionalMain.intensity = main;
        directionalSupport.intensity = support;
    }
}
