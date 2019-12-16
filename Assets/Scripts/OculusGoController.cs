using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OculusGoController : MonoBehaviour
{
    public float forwardSpeed = 0.8f;
    private float rotationSpeed = 60.0f;

    private float counter = 0.0f;
    private float countTo = 1.0f;

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

        // Back Buttons returns to MenuScene
        if (OVRInput.GetDown(OVRInput.Button.Back))
        {
            counter += 1 * Time.deltaTime;
            if (counter >= countTo)
            {
                SceneManager.LoadScene("MenuScene");
                counter = 0;
            }
        }
        else {
            counter = 0;
        }

        // If controller button is touched
        if (OVRInput.Get(OVRInput.Touch.PrimaryTouchpad))
        {
            //Vector2 axis = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote);
            Vector2 axis = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            GameObject player = GameObject.FindObjectOfType<OVRPlayerController>().gameObject;

            // Walking forward or backwards
            if (axis.y > 0.2f || axis.y < -0.6f)
            {
                player.transform.Translate(-Vector3.forward * forwardSpeed * axis.y * Time.deltaTime);
            }

            // Rotating left and right
            if (axis.x > 0.7f || axis.x < -0.7f)
            {
                GameObject.FindObjectOfType<OVRPlayerController>().RotateVRplayer(axis.x * rotationSpeed * Time.deltaTime);
            }
        }
    }
}
