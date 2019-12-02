using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : Interactable
{
    public bool isOpen = false;
    private Animator _animator;

    public override bool isActive()
    {
        return isOpen;
    }

    public override void OnActivate()
    {
        if (!isOpen)
        {
            _animator.SetBool("OpenDoor", true);
            isOpen = !isOpen;
            //throw new System.NotImplementedException();
        }
        else if(isOpen){
            isOpen = !isOpen;
            _animator.SetBool("OpenDoor", false);
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
        _animator = GetComponentInParent<Animator>();
       // new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
}
