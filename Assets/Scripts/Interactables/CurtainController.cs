


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a curtain controller class. This class controls curtains of a certain group connected to this controller
/// To use all curtain controllers use domotica class.
/// @Version: 1.0
/// @Authors: Daniël Geerts
/// </summary>
public class CurtainController : MonoBehaviour
{
    public List<GameObject> curtains;
    public string controllerName = "Placeholder";

    public void OpenCurtains(bool skipAnimation)
    {
        //also adds the animation of the curtains
        for (int i = 0; i < curtains.Count; i++)
        {
            if (!curtains[i].GetComponent<CurtainInteractable>().isActive())
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
        //also adds the animation of the curtains
        for (int i = 0; i < curtains.Count; i++)
        {
            if (curtains[i].GetComponent<CurtainInteractable>().isActive())
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