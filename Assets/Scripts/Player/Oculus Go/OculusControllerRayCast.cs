using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OculusControllerRayCast : MonoBehaviour
{
    public float rayLength;

    // Raycast
    private RaycastHit vision;

    // Interactable
    private Interactable currentSelection;
    private bool gazeAtInteractable = false;

    // Buttons
    private Button currentBtn;
    private Color btnStartColor = Color.white;
    private bool gazeAtButton = false;

    // Line
    public Material lineMaterial;
    private GameObject myLine;
    LineRenderer lr;

    private void Start()
    {
        myLine = new GameObject();
        myLine.gameObject.transform.parent = this.gameObject.transform;
        myLine.AddComponent<LineRenderer>();
       
        lr = myLine.GetComponent<LineRenderer>();
        lr.material = lineMaterial;

        lr.startColor = Color.red;
        lr.endColor = Color.red;
        lr.SetWidth(0.025f, 0.025f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 origin = this.transform.position;
        Vector3 direction = this.transform.forward * rayLength;
        Debug.DrawRay(origin, direction);

        //myLine.transform.position = origin;
        if (lr != null)
        {
            lr.SetPosition(0, origin);
            lr.SetPosition(1, direction);
        }

        gazeAtButton = false;
        gazeAtInteractable = false;

        if (Physics.Raycast(origin, direction, out vision, rayLength))
        {
            if (vision.collider == null)
            {
                lr.startColor = Color.red;
                lr.endColor = Color.red;
            }
            else
            {
                lr.startColor = Color.green;
                lr.endColor = Color.green;
            }

            if (vision.collider.tag.Equals("Interactable"))
            {
                // Check if Interactable
                bool succes = vision.collider.gameObject.TryGetComponent<Interactable>(out Interactable newSelection);

                if (succes)
                {
                    gazeAtInteractable = true;

                    if (currentSelection == null)
                    {
                        currentSelection = newSelection;
                        currentSelection.Select();
                    }
                    else if (currentSelection && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                    {
                        currentSelection.Activate();
                    }
                    else if (!newSelection.Equals(currentSelection))
                    {
                        currentSelection = newSelection;
                    }
                }
            }
            else if (vision.transform.GetComponent<Button>() != null)
            {
                bool succes = vision.collider.gameObject.TryGetComponent<Button>(out Button lookAtButton);
                if (succes)
                {
                    gazeAtButton = true;

                    if (!lookAtButton.Equals(currentBtn))
                    {
                        currentBtn = lookAtButton;
                        currentBtn.transform.GetComponent<Image>().color = Color.red;
                    }

                    if (currentBtn && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                    {
                        currentBtn.onClick.Invoke();
                    }
                }
            }
        }

        if (!gazeAtInteractable) {
            currentSelection.Deselect();
        }

        if (!gazeAtButton) {
            ButtonDeselect();
        }
    }

    private void ButtonDeselect() {
        if (currentBtn == null) { return; };

        currentBtn.gameObject.GetComponent<Image>().color = btnStartColor;
        currentBtn = null;
    }

    private void showSmartphone()
    {
        /*if (Input.GetKeyDown(KeyCode.T))
        {
            if (mobileActive)
            {
                mobile.SetActive(true);
                mobileActive = !mobileActive;
            }
            else{
                mobile.SetActive(false);
                mobileActive = !mobileActive;
                }
        }*/
    }
}
