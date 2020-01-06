using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenLight : MonoBehaviour
{
    public Light light;

    // Start is called before the first frame update
    void Start()
    {
        light.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        light.enabled = true;
        light.intensity = (Mathf.Sin(Time.time) + 1) * 6;
    }
}
