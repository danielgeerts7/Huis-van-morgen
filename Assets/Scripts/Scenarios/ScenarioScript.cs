using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioScript : MonoBehaviour
{
    public List<Light> lights;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Light light in lights)
            light.intensity *= .2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
