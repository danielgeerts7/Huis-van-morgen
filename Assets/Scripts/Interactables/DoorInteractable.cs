using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : Interactable
{
    public bool isOpen = false;

    public override bool isActive()
    {
        return isOpen;
    }

    public override void OnActivate()
    {
        if (isOpen)
        {
            this.gameObject.GetComponent<Animator>().Play("CloseDoor");
            isOpen = !isOpen;
            //throw new System.NotImplementedException();
            Debug.Log("fucked up");
        }
        else
        {
            isOpen = !isOpen;
            gameObject.GetComponent<Animator>().Play("OpenDoor");
            Debug.Log("fucked up");
        }
    }   

    public override void OnDeselect()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnSelect()
    {
        //GetComponentInChildren<Animator>().Play("DoorOpenAnimation");
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
