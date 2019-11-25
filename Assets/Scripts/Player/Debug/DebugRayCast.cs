using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DebugRayCast : MonoBehaviour
{
    public float rayLength;
    public Image image;
    public GameObject mobile;
    private bool mobileActive = false;
    private RaycastHit vision;
    private Interactable currentSelection;
    public Color crosshairDefaultColor = Color.white;
    public Color crosshairSelectColor = Color.green;

    // Update is called once per frame
    void Update()
    {
        Vector3 origin = this.transform.position;
        Vector3 direction = this.transform.forward * rayLength;

        if (Input.GetKeyDown(KeyCode.T))
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
        }

        Debug.DrawRay(origin, direction);
        if (Physics.Raycast(origin, direction, out vision, rayLength))
        {
            if (vision.collider.tag.Equals("Interactable"))
            {

                // Check if Interactable
                bool succes = vision.collider.gameObject.TryGetComponent<Interactable>(out Interactable newSelection);

                //set 
                image.color = crosshairSelectColor;
                //Debug.Log("Succes!");
                if (succes)
                {
                    if (!currentSelection)
                    {
                        currentSelection = newSelection;
                        currentSelection.Select();
                    }
                    else if (!newSelection.Equals(currentSelection))
                    {
                        Debug.Log("deselecting...");
                        currentSelection.Deselect();
                        currentSelection = newSelection;
                        currentSelection.Select();
                    }
                }
                else
                {
                    Debug.LogError(vision.collider.name + " has an Interactable tag, but does not contain an Interactable component");
                    currentSelection = null;
                    image.color = crosshairDefaultColor;
                }
            }
            else
            {
                if (currentSelection)
                {
                    currentSelection.Deselect();
                    currentSelection = null;
                    image.color = crosshairDefaultColor;
                }
            }
        }
        else if (currentSelection)
        {
            currentSelection.Deselect();
            currentSelection = null;
            image.color = crosshairDefaultColor;
        }

        if (currentSelection && Input.GetKeyDown(KeyCode.E)) {
            currentSelection.Activate();
        }

    }
}
