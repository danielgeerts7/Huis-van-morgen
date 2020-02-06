using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves player based on keyboard input. Only used while playing in Editor
/// @Version: 1.0
/// @Authors: Leon Smit
/// </summary>
public class DebugPlayerController : MonoBehaviour
{
    Rigidbody playerBody;

    public float speed = 5;

    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;
        transform.Translate(moveDirection);
    }
}
