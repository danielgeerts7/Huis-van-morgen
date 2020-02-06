using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// This class is controlling all the domotica. It can switch all curtains/lights at the same time.
/// It can also check if lights/curtains are on or off
/// @Version: 1.0
/// @Authors: Florian Molenaars
/// </summary>
public class DomoticaController : MonoBehaviour
{
    // Start is called before the first frame update
    private LightController[] lightControllers;
    private CurtainController[] curtainControllers;

    //to add domotica in mobile, add to this list
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
        // switch all the lights connected to the light controller
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
        // switch all the curtains connected to the curtain controller
        foreach (CurtainController curtainController in curtainControllers)
        {
            if (curtainController == curController)
            {
                if (!CheckIfCurtainsAreOpen(curtainController))
                {
                    curtainController.OpenCurtains(false);
                }
                else
                {
                    curtainController.CloseCurtains(false);
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

    public void SwitchCurtainsWithoutAnimation(bool allOpen)
    {
        //this is for when you need to switch the curtains at the start of the game to skip the animation
        foreach (CurtainController curtainController in curtainControllers)
        {
            if (allOpen)
            {
                curtainController.OpenCurtains(true);
            }
            else {
                curtainController.CloseCurtains(true);
            }
        }
    }

    public bool CheckIfLightsAreOn(LightController lightController) 
    {
        //if more than 50 % of the lights are on this will return true
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
        //if more than 50 % of the curtains are open this will return true
        float totalCurtains = 0.0f;
        float totalEnabled = 0.0f;
        foreach (GameObject curtain in curtainController.curtains)
        {
            totalCurtains += 1.0f;
            if (curtain.GetComponent<CurtainInteractable>().isActive())
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
