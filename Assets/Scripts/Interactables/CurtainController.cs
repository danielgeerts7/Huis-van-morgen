


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainController : MonoBehaviour
{
    public List<GameObject> curtains;
    public string controllerName = "Placeholder";

    public void OpenCurtains(bool skipAnimation)
    {
        for (int i = 0; i < curtains.Count; i++)
        {
            if (!curtains[i].GetComponent<CurtainInteractable>().isOpen)
            {
                if (skipAnimation)
                    curtains[i].GetComponent<CurtainInteractable>().CurtainOpenInstant();
                else
                    curtains[i].GetComponent<CurtainInteractable>().CurtainOpen();
                }
            }
    }

    public void CloseCurtains(bool skipAnimation)
    {
        for (int i = 0; i < curtains.Count; i++)
        {
            if (curtains[i].GetComponent<CurtainInteractable>().isOpen)
            {
                if (skipAnimation)
                    curtains[i].GetComponent<CurtainInteractable>().CurtainCloseInstant();
                else
                    curtains[i].GetComponent<CurtainInteractable>().CurtainClose();
            }
        }
    }


    public void Switch()
    {
        for (int i = 0; i < curtains.Count; i++)
        {
            curtains[i].GetComponent<CurtainInteractable>().OnActivate();
        }
    }
}