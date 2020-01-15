using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletInteractable : Interactable
{

    public GameObject teleportSpot;
    private PlayerController playercontroller;

    private bool sitOnToilet = false;

    public override void OnStart()
    {
        playercontroller = FindObjectOfType<PlayerController>();
    }

    public override bool isActive()
    {
        return sitOnToilet;
    }

    public override void OnActivate()
    {
        if (stepHandler)
        {
            TeleportTo();
        }
    }

    private void TeleportTo()
    {
        GameObject player = playercontroller.GetPlayer();

        player.transform.SetPositionAndRotation(teleportSpot.transform.position, teleportSpot.transform.rotation);
        if (stepHandler.IsActive())
        {
            playercontroller.DisablePlayerControls();
        }

        this.GetComponent<BoxCollider>().isTrigger = true;
        sitOnToilet = true;
    }

    public override void OnDeselect()
    {

    }

    public override void OnSelect()
    {

    }

    private float smooth = 5.0f;
    private float tiltAngle = 60.0f;

    public override void OnUpdate()
    {
        /*if (rotateToPoint)
        {
            GameObject player = playercontroller.GetPlayer();

            // Rotate the cube by converting the angles into a quaternion.
            var rot = teleportSpot.transform.rotation.eulerAngles * tiltAngle;
            Quaternion target = Quaternion.Euler(rot.x, rot.y, rot.z);

            // Dampen towards the target rotation
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, target, Time.deltaTime * smooth);

            if (OVRInput.Get(OVRInput.Touch.Any))
            {
                rotateToPoint = false;
            }

            if (Application.isEditor)
            {

                GameObject cam = player.GetComponentInChildren<DebugPlayerCamera>().gameObject;
                Vector3 cameuler = cam.transform.rotation.eulerAngles;
                cameuler.x = teleportSpot.transform.rotation.x;
                cameuler.y = teleportSpot.transform.rotation.y;
                cameuler.z = teleportSpot.transform.rotation.z;
                cam.transform.rotation = Quaternion.Euler(cameuler);
            }
        }*/
    }
}
