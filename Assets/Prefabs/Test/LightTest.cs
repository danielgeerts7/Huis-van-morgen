using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTest : MonoBehaviour
{
    public bool active;
    public Light dirLight;
    public Light spotLight;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (active)
            {
                dirLight.intensity = .8f;
                spotLight.enabled = true;
            } else
            {
                dirLight.intensity = .5f;
                spotLight.enabled = false;
            }

            active = !active;
        }
    }
}
