using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportInteractable : Interactable
{
    public GameObject target;
    private GameObject player;

    private bool isTeleported = false;

    public override bool isActive()
    {
        return false;
    }

    public override void OnActivate()
    {
        TeleportTo(target);
    }

    private void TeleportTo(GameObject go)
    {
        player.transform.position = go.transform.position; 
        player.transform.rotation = Quaternion.Euler(go.transform.rotation.eulerAngles);
        FindObjectOfType<PlayerController>().DisablePlayerControls();
       
        isTeleported = true;
    }

    public override void OnDeselect()
    {

    }

    public override void OnSelect()
    {

    }

    public override void OnStart()
    {
        player = FindObjectOfType<PlayerController>().GetPlayer();
    }

    public override void OnUpdate()
    {
        if (isTeleported) {
            FindObjectOfType<PlayerController>().EnablePlayerControls();
            isTeleported = false;
        }
    }
}
