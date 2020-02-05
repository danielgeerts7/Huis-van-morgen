using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Performs a raycast which returns a colliding object. Used to determine if the player is looking at an object.
/// If the player is looking at an object it is selected. 
/// When player presses 'E' key, the selected object is activated if it's an interactable.
/// @Version: 1.0
/// @Authors: Leon Smit
/// </summary>
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
                mobileActive = !mobileActive;
                mobile.SetActive(false);
            }
            else{
                mobileActive = !mobileActive;
                mobile.SetActive(true);
            }
        }

        // Draw the Raycast and puts colliding object in vision variable
        Debug.DrawRay(origin, direction);
        if (Physics.Raycast(origin, direction, out vision, rayLength))
        {
            // If object has Interactable tag continue
            if (vision.collider.tag.Equals("Interactable") && FindObjectOfType<PlayerController>().PlayerControlsEnabled())
            {
                // Check if object is Interactable
                bool succes = vision.collider.gameObject.TryGetComponent<Interactable>(out Interactable newSelection);

                image.color = crosshairSelectColor;
                // If object has Interactable component, continue,
                // else Log in error
                if (succes)
                {
                    // If object is newly selected, perform select function
                    if (!currentSelection)
                    {
                        currentSelection = newSelection;
                        currentSelection.Select();
                    }
                    else if (!newSelection.Equals(currentSelection))
                    {
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
                // If no interactable object is collided with, but there is an object selected,
                // deselect the object.
                if (currentSelection)
                {
                    currentSelection.Deselect();
                    currentSelection = null;
                    image.color = crosshairDefaultColor;
                }
            }
        }
        // if no object is collided with, deselect the current selection if it exists
        else if (currentSelection)
        {
            currentSelection.Deselect();
            currentSelection = null;
            image.color = crosshairDefaultColor;
        }

        // If 'E' key is pressed, activate current selection
        if (currentSelection && Input.GetKeyDown(KeyCode.E)) {
            currentSelection.Activate();
        }

    }
}
