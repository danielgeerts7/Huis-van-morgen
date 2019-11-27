using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomoticaController : MonoBehaviour
{
    // Start is called before the first frame update
    public LightController[] lightControllers;
    public CurtainController[] curtainControllers;
    private List<string> domotica;
    void Awake()    
    {
        domotica = new List<string>();
        lightControllers = GameObject.FindObjectsOfType<LightController>();
        curtainControllers = GameObject.FindObjectsOfType<CurtainController>();
        domotica.Add("Lampen");
        domotica.Add("Gordijnen");
    }

    public void TurnOnLightOnRoom(string nameLightController)
    {
        Debug.Log(nameLightController);
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

    public void OpenCurtainOnRoom(string nameCurtainController)
    {
        foreach (CurtainController curtainController in curtainControllers)
        {
            if (curtainController.name == nameCurtainController)
                curtainController.OpenCurtain();
        }
    }

    public void CloseCurtainOnRoom(string nameCurtainController)
    {
        foreach (CurtainController curtainController in curtainControllers)
        {
            if (curtainController.name == nameCurtainController)
                curtainController.CloseCurtain();
        }
    }

    public bool CheckIfLightsOn(LightController lightController) 
    {
        float totalLights = 0.0f;
        float totalEnabled = 0.0f;
        foreach (GameObject light in lightController.lights)
        {
            totalLights += 1.0f;
            if (GetComponentInChildren<Light>().enabled == true)
            {
                totalEnabled += 1.0f;
            }

        }
        if (totalEnabled >= Mathf.Ceil(totalLights / 2.0f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckIfCurtainIsOpen(CurtainController curtainController)
    {
        float totalCurtains = 0.0f;
        float totalEnabled = 0.0f;
        foreach (GameObject curtain in curtainController.curtains)
        {
            totalCurtains += 1.0f;
            if (curtain.GetComponent<CurtainInteractable>().isOpen == true)
            {
                totalEnabled += 1.0f;
            }
        }
        if (totalEnabled >= Mathf.Ceil(totalCurtains / 2.0f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public List<string> GetListDomotica()
    {
        return domotica;
    }
    public LightController[] GetListLights()
    {
        return lightControllers;
    }
    public CurtainController[] GetListCurtains()
    {
        return curtainControllers;
    }
}
