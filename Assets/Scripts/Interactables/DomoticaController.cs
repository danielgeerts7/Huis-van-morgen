using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomoticaController : MonoBehaviour
{
    // Start is called before the first frame update
    private LightController[] lightControllers;
    private CurtainController[] curtainControllers;
    private List<string> domotica;

    void Awake()    
    {
        domotica = new List<string>();
        lightControllers = GameObject.FindObjectsOfType<LightController>();
        curtainControllers = GameObject.FindObjectsOfType<CurtainController>();
        domotica.Add("Lampen");
        domotica.Add("Gordijnen");
    }

    public void SwitchLightOnRoom(LightController liController)
    {
        foreach (LightController lightController in lightControllers)
        {
            if (lightController == liController)
            {
                if (!CheckIfLightsAreOn(lightController))
                {
                    lightController.TurnOn();
                }
                else
                {
                    lightController.TurnOff();
                }
            }
        }

    }
    public void SwitchCurtainOnRoom(CurtainController curController)
    {
        foreach (CurtainController curtainController in curtainControllers)
        {
            if (curtainController == curController)
            {
                if (!CheckIfCurtainsAreOpen(curtainController))
                {
                    curtainController.OpenCurtain();
                }
                else
                {
                    curtainController.CloseCurtain();
                }
            }
        }
    }

    public void SwitchLights(bool allOn)
    {

        foreach (LightController lightController in lightControllers)
        {
            if (allOn)
            {
                lightController.TurnOn();
            }
            else {
                lightController.TurnOff();
            }

        }
    }

    public void SwitchCurtains(bool allOpen)
    {
        foreach (CurtainController curtainController in curtainControllers)
        {
            if (allOpen)
            {
                curtainController.OpenCurtain();
            }
            else {
                curtainController.CloseCurtain();
            }
        }
    }

    public bool CheckIfLightsAreOn(LightController lightController) 
    {
        float totalLights = 0;
        float totalEnabled = 0;
        foreach (GameObject light in lightController.lights)
        {
            totalLights += 1;
            if (light.GetComponentInChildren<Light>().enabled)
            {
                totalEnabled += 1.0f;
            }

        }
        if (totalEnabled >= Mathf.Ceil(totalLights / 2))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckIfCurtainsAreOpen(CurtainController curtainController)
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
