using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomoticaController : MonoBehaviour
{
    // Start is called before the first frame update
    public LightController[] lightControllers;
    public CurtainInteractable[] curtainInteractables;
    
    void Start()
    {
        lightControllers = GameObject.FindObjectsOfType<LightController>();
        curtainInteractables = GameObject.FindObjectsOfType<CurtainInteractable>();
    }


    public void TurnOnLightOnRoom(string nameLightController)
    {
        foreach (LightController lightController in lightControllers)
        {
            if(lightController.name == nameLightController)
            {
                lightController.TurnOn();
            }
        }
    }
    public void TurnOffLightOnRoom(string nameLightController)
    {
        foreach (LightController lightController in lightControllers)
        {
            if (lightController.name == nameLightController)
            {
                lightController.TurnOff();
            }
        }
    }

    public void OpenCloseCurtain()
    {
        foreach (CurtainInteractable curtain in curtainInteractables)
        {
            curtain.OnActivate();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
