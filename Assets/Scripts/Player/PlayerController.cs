using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject VR_player;
    public GameObject EDITOR_player;

    private GameObject player;
    private bool playerControlsEnabled;

    void Awake()
    {
        if (Application.isEditor)
        {
            player = EDITOR_player;
            DeActivatePlayer(VR_player);
            ActivatePlayer(EDITOR_player);
        }
        else
        {
            player = VR_player;
            DeActivatePlayer(EDITOR_player);
            ActivatePlayer(VR_player);
        }

        playerControlsEnabled = true;
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    public void DisablePlayerControls()
    {
        if (player.Equals(VR_player))
        {
            player.GetComponentInChildren<OculusGoController>().AllowedToWalk(false);
            player.GetComponent<OVRPlayerController>().enabled = false;
        }
        if (player.Equals(EDITOR_player))
        {
            player.GetComponentInChildren<DebugPlayerController>().enabled = false;
        }

        playerControlsEnabled = false;
    }

    public void EnablePlayerControls()
    {
        if (player.Equals(VR_player))
        {
            player.GetComponentInChildren<OculusGoController>().AllowedToWalk(true);
            player.GetComponent<OVRPlayerController>().enabled = true;
        }
        if (player.Equals(EDITOR_player))
        {
            player.GetComponentInChildren<DebugPlayerController>().enabled = true;
        }

        playerControlsEnabled = true;
    }

    public bool PlayerControlsEnabled()
    {
        return playerControlsEnabled;
    }

    private void ActivatePlayer(GameObject name)
    {
        name.SetActive(true);
    }

    private void DeActivatePlayer(GameObject name)
    {
        name.SetActive(false);
    }
}