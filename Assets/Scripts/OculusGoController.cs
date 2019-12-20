using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OculusGoController : MonoBehaviour
{
    public float forwardSpeed = 0.8f;
    private float rotationSpeed = 60.0f;

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

        if (OVRInput.Get(OVRInput.Touch.Any))
        {
            axis = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
        }
        else if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick) != null)
        {
            axis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        }
        else if (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick) != null)
        {
            axis = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        }
        else {
            axis = OVRInput.Get(OVRInput.Axis2D.Any);
        }

        if (canWalk)
        {
            // Walking forward or backwards
            player.transform.Translate(-Vector3.forward * forwardSpeed * Mathf.Round(axis.y) * Time.deltaTime);
        }

        // Rotating left and right
        GameObject.FindObjectOfType<OVRPlayerController>().RotateVRplayer(Mathf.Round(axis.x) * rotationSpeed * Time.deltaTime);

        // Back Buttons returns to MenuScene
        if (OVRInput.Get(OVRInput.Button.Back))
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
