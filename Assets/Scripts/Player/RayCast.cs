using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public float rayLength;

    private RaycastHit vision;
    private Interactable currentSelection;

    // Update is called once per frame
    void Update()
    {
        Vector3 origin = this.transform.position;
        Vector3 direction = this.transform.forward * rayLength;

        Debug.DrawRay(origin, direction);
        if (Physics.Raycast(origin, direction, out vision, rayLength))
        {
            if (vision.collider.tag.Equals("Interactable"))
            {
                // Check if Interactable
                bool succes = vision.collider.gameObject.TryGetComponent<Interactable>(out Interactable newSelection);
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
                }
            }
            else
            {
                if (currentSelection)
                {
                    currentSelection.Deselect();
                    currentSelection = null;
                }
            }
        }
        else if (currentSelection)
        {
            currentSelection.Deselect();
            currentSelection = null;
        }

        if (currentSelection && Input.GetKeyDown(KeyCode.E)) {
            currentSelection.Activate();
        }

    }
}
