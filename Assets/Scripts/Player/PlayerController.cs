using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Start()
    {
        if (Application.isEditor)
        {
            ActivatePlayer("Player");
        } else
        {
            ActivatePlayer("VR Player");
        }
    }

    private void ActivatePlayer(string name)
    {
        transform.Find(name).gameObject.SetActive(true);
    }
}
