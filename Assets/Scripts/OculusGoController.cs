using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OculusGoController : MonoBehaviour
{
    public float forwardSpeed = 0.8f;
    private float rotationSpeed = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        OVRManager.display.displayFrequency = 72.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // update every frame so the Oculus GO controller
        OVRInput.Update();

        // If controller button is touched
        if (OVRInput.Get(OVRInput.Touch.PrimaryTouchpad))
        {
            //Vector2 axis = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote);
            Vector2 axis = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            GameObject player = GameObject.FindObjectOfType<OVRPlayerController>().gameObject;

            // Walking forward or backwards
            player.transform.Translate(-Vector3.forward * forwardSpeed * Mathf.Round(axis.y) * Time.deltaTime);

            // Rotating left and right
            //if (axis.x > 0.7f || axis.x < -0.7f)
            //{
                GameObject.FindObjectOfType<OVRPlayerController>().RotateVRplayer(Mathf.Round(axis.x) * rotationSpeed * Time.deltaTime);
            //}
        }

        // Back Buttons returns to MenuScene
        if (OVRInput.Get(OVRInput.Button.Back))
        {
            SceneManager.LoadScene("MenuScene");
        }

    }
}
