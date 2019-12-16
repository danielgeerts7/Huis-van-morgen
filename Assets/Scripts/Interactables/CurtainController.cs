


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainController : MonoBehaviour
{
    public List<GameObject> curtains;
    public string controllerName = "Placeholder";
    // Start is called before the first frame update

    public void OpenCurtain()
    {
        for (int i = 0; i < curtains.Count; i++)
        {
            if (!curtains[i].GetComponent<CurtainInteractable>().isOpen)
            {
                curtains[i].GetComponent<CurtainInteractable>().CurtainOpen();
            }
        }
    }
    public void CloseCurtain()
    {
        for (int i = 0; i < curtains.Count; i++)
        {
            if (curtains[i].GetComponent<CurtainInteractable>().isOpen)
            {
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