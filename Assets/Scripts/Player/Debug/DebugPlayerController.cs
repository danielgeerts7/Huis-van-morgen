using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPlayerController : MonoBehaviour
{
    Rigidbody playerBody;

    public float speed;

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
