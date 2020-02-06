using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves the camera based on mouse movement.
/// @Version: 1.0
/// @Authors: Leon Smit
/// </summary>
public class DebugPlayerCamera : MonoBehaviour
{

    Vector2 mouseLook;
    public float sensitivity = 2;
    GameObject player;

    private bool islocked = false;

    // Start is called before the first frame update
    void Start()
    {
        player = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!islocked)
        {
            float horizontal = Input.GetAxis("Mouse X");
            float vertical = Input.GetAxis("Mouse Y");

            Vector2 look = new Vector2(horizontal, vertical);
            mouseLook += look * sensitivity;

            mouseLook.y = Mathf.Clamp(mouseLook.y, -80f, 80);
        
            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
        }
    }

    public void UpdateRotation(Quaternion newRot) {
        transform.rotation = newRot;
    }
}
