using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the Ambulance light
/// @Version: 1.0
/// @Authors: Leon Smit
/// </summary>
public class SirenLight : MonoBehaviour
{
    new public Light light;

    // Start is called before the first frame update
    void Start()
    {
        light.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<AmbulanceInteractable>().isActive())
        {
            light.enabled = true;
            // Sinus gives a wave pattern to the intensitys
            light.intensity = Mathf.Sin(Time.time * 5) * 5;
        }
        else
        {
            light.enabled = false;
        }
    }
}
