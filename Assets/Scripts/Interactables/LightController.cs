
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : DomoticaController
{
    public List<GameObject> lights;
    public bool ShowControllerInMobile = true;
    

    // Start is called before the first frame update

    // Update is called once per frame

    public void TurnOn()
    {
        for (int i = 0; i < lights.Count; i++)
        {
            lights[i].GetComponentInChildren<Light>().enabled = true;
        }
    }


    public void TurnOff()
    {
        for (int i = 0; i < lights.Count; i++)
        {
            lights[i].GetComponentInChildren<Light>().enabled = false;
        }
    }

    public void Switch()
    {
        base.SwitchLightOnRoom(this);
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
