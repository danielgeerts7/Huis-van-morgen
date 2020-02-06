using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Let's the player sit on the toilet and disables movement if a step is active (To make player stuck on toilet)
/// @Version: 1.0
/// @Authors: Leon Smit, Daniël Geerts
/// </summary>
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
    }
}
