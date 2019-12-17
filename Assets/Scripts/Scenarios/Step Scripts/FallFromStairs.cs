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
        if (activated || !(step.getState() == State.RUNNING))
            return;
        else
            activated = true;

        if (isOVR)
        {
            RunOVRScript();
        } else
        {
            //RunOVRScript();
            RunDebugScript();
        }
    }

    private void RunDebugScript()
    {
        GameObject camera = player.GetComponentInChildren<Camera>().gameObject;
        camera.transform.localPosition += new Vector3(0f, -1f, 0f);

/*
        Debug.Log("Running debug script");
        player.transform.localScale += new Vector3(0f, -.5f, 0f);
*/
        Vector3 euler = player.transform.rotation.eulerAngles;
        euler.y = 180f;
        player.transform.Rotate(euler);
    }

    private void RunOVRScript()
    {
        OVRManager camera = player.GetComponentInChildren<OVRManager>();
        camera.headPoseRelativeOffsetTranslation += new Vector3(0f, -1f, 0f);

    }

    private void TeleportTo()
    {
        Debug.Log("Teleporting script at " + Time.time);
        player.transform.position = teleportTo.transform.position;


        //TODO: Fix rotation
        player.transform.rotation = Quaternion.Euler(teleportTo.transform.rotation.eulerAngles);
    }
}
