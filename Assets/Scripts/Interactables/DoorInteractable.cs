using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : Interactable
{
    public bool isOpen = false;
    private AudioManager audioManager;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public override bool isActive()
    {   
        return isOpen;
    }

    public override void OnActivate()
    {
        if (isOpen)
        {
            if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !this.GetComponent<Animator>().IsInTransition(0))
            {
                    if (audioManager != null)
                    {
                        audioManager.Play("CloseDoor");
                    }
                    this.gameObject.GetComponent<Animator>().Play("CloseDoor");
                isOpen = !isOpen;
                //throw new System.NotImplementedException();
            }
        }
        else
        {
            if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !this.GetComponent<Animator>().IsInTransition(0))
            {
                if(audioManager != null)
                {
                    audioManager.Play("OpenDoor");
                }
                gameObject.GetComponent<Animator>().Play("OpenDoor");
                isOpen = !isOpen;
            }
        }
        }

    public override void OnDeselect()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnSelect()
    {
        //throw new System.NotImplementedException();
    }
    
    public override void OnStart()
    {
       // new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
}
