using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Shows message on phone when a step is running.
/// @Version: 1.0
/// @Authors: Florian Molenaars
/// </summary>
public class ActivateMobileMessage : MonoBehaviour
{
    public GameObject mobile;

    public Step running;
    private bool showedMessage = false;

    public string text;

    private void Start()
    {
        mobile = FindObjectOfType<MobileController>().gameObject;
    }

    void Update()
    {
        if (showedMessage == false)
        {
            if (running.getState() == State.RUNNING)
            {
                mobile.transform.GetChild(0).gameObject.SetActive(true);
                mobile.GetComponentInChildren<MobileController>().SetMessage(text);
                showedMessage = true;
            }
        }
    }
}
