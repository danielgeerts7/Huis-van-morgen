using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OculusGoController : MonoBehaviour
{
    public float forwardSpeed = 0.25f;
    private float rotationSpeed = 45.0f;

    private bool canWalk = true;

    private bool pressedTouch = true;
    private bool canTakeMobile = true;

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
        GameObject player = GameObject.FindObjectOfType<OVRPlayerController>().gameObject;
        
        Vector2 axis;

        /*if (OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad) != null)
        {
            axis = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
        }
        else {*/
            axis = OVRInput.Get(OVRInput.RawAxis2D.Any);
        //}

        if (axis.y >= 0.5f || axis.y <= -0.5f)
        {
            if (canWalk)
            {
                // Walking forward or backwards
                var yaxis = Mathf.Round(axis.y);
                if (yaxis >= 1) yaxis = 1;
                if (yaxis <= -1) yaxis = -1;
                player.transform.Translate(-Vector3.forward * forwardSpeed * yaxis * Time.deltaTime);
            }
        }

        //if (axis.x >= 0.5f || axis.x <= -0.5f)
        //{
            // Rotating left and right
            GameObject.FindObjectOfType<OVRPlayerController>().RotateVRplayer(Mathf.Round(axis.x) * rotationSpeed * Time.deltaTime);
        //}

        // Back Buttons returns to MenuScene
        if (OVRInput.Get(OVRInput.RawButton.Back) ||
            OVRInput.Get(OVRInput.RawButton.B))
        {
            SceneManager.LoadScene("MenuScene");
        }


        /*// Make mobile visible or hide
        if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad) ||
            OVRInput.Get(OVRInput.Button.PrimaryThumbstick) ||
            OVRInput.Get(OVRInput.Button.SecondaryThumbstick))
        {
            pressedTouch = true;
        }
        else {
            pressedTouch = false;
            canTakeMobile = true;
        }

        if (pressedTouch)
        {
            if (canTakeMobile)
            {
                GameObject.FindObjectOfType<MobileController>().OpenSmartphone();
                canTakeMobile = false;
            }
        }*/
    }

    public void AllowedToWalk(bool mayWalk)
    {
        canWalk = mayWalk;
    }
}
