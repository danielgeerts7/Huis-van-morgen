using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMobileMessage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mobile;

    public Step running;
    private bool showedMessage = false;

    public string text;
    // Update is called once per frame

    private void Start()
    {
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
