using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OculusGoController : MonoBehaviour
{
    [SerializeField] private Text debugText;
    [SerializeField] private int moveSpeed = 2;

    private float deltaTime;


    // Start is called before the first frame update
    void Start()
    {
        
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

            player.transform.Translate(-Vector3.forward * moveSpeed * axis.y * Time.deltaTime);
            player.transform.Translate(-Vector3.right * moveSpeed * axis.x * Time.deltaTime);

        }

        fillText();
    }

    void fillText() {
        debugText.text = "";

        // Touched touchpad
        debugText.text += "if Touch me: " + OVRInput.Get(OVRInput.Touch.PrimaryTouchpad);

        debugText.text += "\n";

        // X, Y where you touch trackpad on controller
        debugText.text += "Where you touche me: " + OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote);

        debugText.text += "\n";

        // Clicked touchpad
        debugText.text += "Clicked: " + OVRInput.Get(OVRInput.Button.PrimaryTouchpad);

        debugText.text += "\n";

        // FPS counter
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        debugText.text += "FPS: " + Mathf.Ceil(fps).ToString();
    }
}
