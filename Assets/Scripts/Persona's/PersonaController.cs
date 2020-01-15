using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        configController = GameObject.FindObjectOfType<ConfigController>();
        filter = GameObject.Find("BadSight");
        Debug.Log(filter);
        if (configController != null)
        {
            persona = configController.GetSelectedPersona();
            oculusController = GameObject.FindObjectOfType<OculusGoController>();
            if(filter != null)
            {
                filter.GetComponent<Image>().enabled = false;
            }
            SetIngameEffect(persona);
        }
    }

    void SetIngameEffect(PersonaInfo persona)
    {
        if (persona.inGameEffect.Equals("Slow"))
        {
            oculusController.forwardSpeed = 0.5f;  
        }
        if (persona.inGameEffect.Equals("Blurry"))
        {
            filter.GetComponent<Image>().enabled = true;
        }
        if (persona.inGameEffect.Equals("LowSound"))
        {
            sources = GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            for (int i = 0; i < sources.Length; i++)
            {
                sources[i].volume = 0.1f;
            }
        }
    }
}
