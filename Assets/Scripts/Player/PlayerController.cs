using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject VR_player;
    public GameObject EDITOR_player;

    private GameObject player;

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
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    public void DisablePlayerControls()
    {
        if (player.Equals(VR_player)) {
            OVRManager camera = player.GetComponentInChildren<OVRManager>();
            player.GetComponentInChildren<OculusGoController>().AllowedToWalk(false);
            player.GetComponent<OVRPlayerController>().enabled = false;
        }
        if (player.Equals(EDITOR_player)) {
            GameObject camera = player.GetComponentInChildren<Camera>().gameObject;
            player.GetComponentInChildren<DebugPlayerController>().enabled = false;
        }
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