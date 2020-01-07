using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallFromStairs : MonoBehaviour
{
    public Step step;
    private bool activated;
    private PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!activated && step.getState() == State.RUNNING)
        {
            activated = true;
        }

        if (activated && playerController.PlayerControlsEnabled())
        {
            playerController.DisablePlayerControls();
        }
    }
}
