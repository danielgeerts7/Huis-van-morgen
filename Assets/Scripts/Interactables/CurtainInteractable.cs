using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainInteractable : Interactable
{
    public bool isOpen = true;

    public GameObject leftCurtain;
    public GameObject rightCurtain;

    public override void OnStart()
    {
        if (!isOpen)
        {
            leftCurtain.GetComponent<Animator>().Play("Close Curtain");
            rightCurtain.GetComponent<Animator>().Play("Close Curtain");
            isOpen = false;
        }
    }

    public override void OnUpdate() { }
    public override void OnSelect() { }
    public override void OnDeselect() { }

    public override void OnActivate()
    {
        if (isOpen)
        {
            CurtainClose();
        }
        else
        {
            CurtainOpen();
        }
    }

    public void CurtainOpen() {
        if (!isOpen)
        {
            leftCurtain.GetComponent<Animator>().Play("Open Curtain");
            rightCurtain.GetComponent<Animator>().Play("Open Curtain");
            isOpen = true;
        }

    }

    public void CurtainClose()
    {
        if (isOpen)
        {
            leftCurtain.GetComponent<Animator>().Play("Close Curtain");
            rightCurtain.GetComponent<Animator>().Play("Close Curtain");
            isOpen = false;
        }
    }

    public override bool isActive()
    {
        return isOpen;
    }
}
