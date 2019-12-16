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

    void Start()
    {
        configController = GameObject.FindObjectOfType<ConfigController>();
        if (configController != null)
        {
            persona = configController.GetSelectedPersona();
            oculusController = GameObject.FindObjectOfType<OculusGoController>();
            filter = GameObject.FindObjectOfType<SnapshotMode>();
            SetIngameEffect(persona);
            filter.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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

        }
    }
}
