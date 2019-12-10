using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OculusGoController : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 2.0f;
    [SerializeField] private float sidewardsSpeed = 0.5f;

    private float deltaTime;


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

            player.transform.Translate(-Vector3.forward * forwardSpeed * axis.y * Time.deltaTime);
            player.transform.Translate(-Vector3.right * sidewardsSpeed * axis.x * Time.deltaTime);

        }
    }
}
