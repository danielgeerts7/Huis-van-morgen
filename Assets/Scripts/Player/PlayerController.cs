using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject VR_player;
    public GameObject EDITOR_player;

    void Awake()
    {
        if (Application.isEditor)
        {
            ActivatePlayer(EDITOR_player);
        } else
        {
            ActivatePlayer(VR_player);
        }
    }

    private void ActivatePlayer(GameObject name)
    {
        name.SetActive(true);
    }
}
