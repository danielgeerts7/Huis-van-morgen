using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallFromStairs : MonoBehaviour
{
    public Step step;
    public GameObject teleportTo;
    private bool activated;
    private bool isOVR;
    private GameObject player;

    void Start()
    {
        player = FindObjectOfType<DebugPlayerController>().gameObject;

        if (!player)
        {
            player = FindObjectOfType<OVRPlayerController>().gameObject;
            isOVR = true;
        }

        Debug.Log("FFS"+ player);
    }

    // Update is called once per frame
    void Update()
    {
        if (activated || !(step.getState() == State.COMPLETED))
            return;
        else
            activated = true;

        if (isOVR)
        {
            RunOVRScript();
        } else
        {
            RunDebugScript();
        }
    }

    private void RunDebugScript()
    {
        Debug.Log("Running debug script");
        player.transform.localScale += new Vector3(0f, -.5f, 0f);

        Vector3 euler = player.transform.rotation.eulerAngles;
        euler.y = 180f;
        player.transform.Rotate(euler);
    }

    private void RunOVRScript()
    {
        Debug.Log("Running script on OVR");
        player.transform.localScale += new Vector3(0f, -.9f, 0f);
        player.transform.Find("OVRCameraRig");
    }

    private void TeleportTo()
    {
        Debug.Log("Teleporting script at " + Time.time);
        player.transform.position = teleportTo.transform.position;


        //TODO: Fix rotation
        player.transform.rotation = Quaternion.Euler(teleportTo.transform.rotation.eulerAngles);
    }
}
