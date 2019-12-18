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

    private void ActivatePlayer(GameObject name)
    {
        name.SetActive(true);
    }

    private void DeActivatePlayer(GameObject name)
    {
        name.SetActive(false);
    }
}