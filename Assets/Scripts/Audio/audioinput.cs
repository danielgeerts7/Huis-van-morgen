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
            Debug.Log("hallo");
            FindObjectOfType<AudioManager>().Play("OpenDoor");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            FindObjectOfType<AudioManager>().Play("Select");
        }
    }
}
