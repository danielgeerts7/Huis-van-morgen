using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This class is is acting on the persona chosen in the main menu.
/// It adds a "disability" to the character like blurry when the persona has bad sight
/// @Version: 1.0
/// @Authors: Florian Molenaars
/// </summary>
public class PersonaController : MonoBehaviour
{
    // Start is called before the first frame update
    private PersonaInfo persona;
    private ConfigController configController;
    private OculusGoController oculusController;
    AudioSource[] sources;
    private GameObject filter;


    void Start()
    {
        // get the persona chosen from the main menu through the configcontroller
        // and the filter object
        configController = GameObject.FindObjectOfType<ConfigController>();
        filter = GameObject.Find("BadSight");
        if (configController != null)
        {
            persona = configController.GetSelectedPersona();
            oculusController = GameObject.FindObjectOfType<OculusGoController>();
            if(filter != null)
            {
                filter.GetComponentInChildren<Image>().enabled = false;
            }
            SetIngameEffect(persona);
        }
    }

    void SetIngameEffect(PersonaInfo persona)
    {
        // set an effect ingame for the chosen persona
        if (persona.inGameEffect.Equals("Slow"))
        {
            oculusController.forwardSpeed = 0.5f;  
        }
        if (persona.inGameEffect.Equals("Blurry"))
        {
            if (filter != null)
            {
                filter.GetComponentInChildren<Image>().enabled = true;
            }
        }
        if (persona.inGameEffect.Equals("LowSound"))
        {
            sources = GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            for (int i = 0; i < sources.Length; i++)
            {
                sources[i].volume = 0.5f;
            }
        }
    }
}
