using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonaController : MonoBehaviour
{
    // Start is called before the first frame update
    private PersonaInfo persona;
    private ConfigController configController;
    private OculusGoController oculusController;
    private SnapshotMode filter;
    AudioSource[] sources;


    void Start()
    {
        configController = GameObject.FindObjectOfType<ConfigController>();
        if (configController != null)
        {
            persona = configController.GetSelectedPersona();
            oculusController = GameObject.FindObjectOfType<OculusGoController>();
            SetIngameEffect(persona);
            filter = GameObject.FindObjectOfType<SnapshotMode>();
            if (filter != null)
            {
                filter.enabled = false;
            }
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
            filter.enabled = true;
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
