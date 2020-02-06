using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// This is a curtainInteractable class. This class can open and close curtains.
/// There is also a instant open and close method, this is for when the simulation starts,
/// so that you dont see them opening/closing at the start.
/// @Version: 1.0
/// @Authors: Daniël Geerts
/// </summary>
public class CurtainInteractable : Interactable
{
    private bool isOpen = true;

    public GameObject leftCurtain;
    public GameObject rightCurtain;

    public override void OnStart()
    {
    }

    public override void OnUpdate() { }
    public override void OnSelect() { }
    public override void OnDeselect() { }

    public override void OnActivate()
    {
        if (isOpen)
        {
            if (leftCurtain.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !leftCurtain.GetComponent<Animator>().IsInTransition(0))
            {   
                CurtainClose();
            }
        }
        else
        {
            if (leftCurtain.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !leftCurtain.GetComponent<Animator>().IsInTransition(0))
            {
                CurtainOpen();
            }
        }
    }

    public void CurtainOpen() {
        if (!isOpen)
        {
            leftCurtain.GetComponent<Animator>().Play("Open Curtain");
            rightCurtain.GetComponent<Animator>().Play("Open Curtain");

            if (FindObjectOfType<AudioManager>() != null)
            {
                FindObjectOfType<AudioManager>().Play("MoveCurtain");
            }
            isOpen = true;
        }

    }

    public void CurtainClose()
    {
        if (isOpen)
        {
            leftCurtain.GetComponent<Animator>().Play("Close Curtain");
            rightCurtain.GetComponent<Animator>().Play("Close Curtain");

            if (FindObjectOfType<AudioManager>() != null)
            {
                FindObjectOfType<AudioManager>().Play("MoveCurtain");
            }

            isOpen = false;
        }
    }

    public void CurtainOpenInstant()
    {
        leftCurtain.GetComponent<Animator>().Play("Instantly Open Curtain");
        rightCurtain.GetComponent<Animator>().Play("Instantly Open Curtain");

        isOpen = true;
    }

    public void CurtainCloseInstant()
    {
        leftCurtain.GetComponent<Animator>().Play("Instantly Close Curtain");
        rightCurtain.GetComponent<Animator>().Play("Instantly Close Curtain");

        isOpen = false;
    }

    public override bool isActive()
    {
        return isOpen;
    }
}
