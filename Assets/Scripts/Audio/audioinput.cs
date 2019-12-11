using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioinput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<AudioManager>().Play("Activate");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            FindObjectOfType<AudioManager>().Play("Select");
        }
    }
}
