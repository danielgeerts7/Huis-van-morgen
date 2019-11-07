using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLight : MonoBehaviour
{
    public Light otherLight;
    public float onIntensity = 0.8f;
    public float offIntensity = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (otherLight.enabled)
        {
            GetComponent<Light>().intensity = onIntensity;
        } else
        {
            GetComponent<Light>().intensity = offIntensity;
        }
    }
}
