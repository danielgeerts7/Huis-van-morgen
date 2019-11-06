using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public List<GameObject> lights;
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
        for (int i = 0; i < lights.Count; i++)
        {
            lights[i].GetComponentInChildren<Light>().enabled = !lights[i].GetComponentInChildren<Light>().enabled;
        }
    }
}
