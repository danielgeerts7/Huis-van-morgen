
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is a light controller class. This class controls lights of a certain group.
/// To use all lightconcontrollers use domotica class
/// Mobile controller adds all lightcontrollers as a button(unless the showcontrollerinmobile is toggles off). Give the lightcontroller a name to display name in mobile
/// @Version: 1.0
/// @Authors: Florian Molenaars
/// </summary>
public class LightController : MonoBehaviour
{
    public List<GameObject> lights;
    public bool ShowControllerInMobile = true;
    public string controllerName = "Placeholder";
    
    public void TurnOn()
    {
        // turn lights on that are connected with the lightcontroller
        for (int i = 0; i < lights.Count; i++)
        {
            lights[i].GetComponentInChildren<Light>().enabled = true;
        }
    }


    public void TurnOff()
    {
        // turn lights off that are connected with the lightcontroller
        for (int i = 0; i < lights.Count; i++)
        {
            lights[i].GetComponentInChildren<Light>().enabled = false;
        }
    }

    public void Switch()
    {
        GameObject.FindObjectOfType<DomoticaController>().SwitchLightOnRoom(this);
    }

    public void IncreaseLightIntesity()
    { 
        for (int i = 0; i < lights.Count; i++)
        {
            lights[i].GetComponentInChildren<Light>().intensity = 8;
        }
    }

    public void DecreaseLightIntesity()
    {
        for (int i = 0; i < lights.Count; i++)
        {
            lights[i].GetComponentInChildren<Light>().intensity = 1.5f;
        }
    }
}
