using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportInteractable : Interactable
{
    public GameObject spot1;
    public GameObject spot2;

    private GameObject player;

    private bool isTeleported = false;

    public override bool isActive()
    {
        return false;
    }

    public override void OnActivate()
    {
        float dist1 = Vector3.Distance(player.transform.position, spot1.transform.position);
        float dist2 = Vector3.Distance(player.transform.position, spot2.transform.position);

        if (dist1 < dist2)
        {
            TeleportTo(spot2);
        }
        else
        {
            TeleportTo(spot1);
        }
    }

    private void TeleportTo(GameObject go)
    {
        player.transform.position = go.transform.position;
        FindObjectOfType<PlayerController>().DisablePlayerControls();
        player.transform.rotation = Quaternion.Euler(go.transform.rotation.eulerAngles);
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
