using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInteractable : Interactable
{
    public override void Select()
    {
        Debug.Log($"Selecting {this.gameObject.name}");
    }

    public override void Deselect()
    {
        Debug.Log($"Deselecting {this.gameObject.name}");
    }

    public override void Activate()
    {
        Debug.Log("slkjfsadf");
    }
}
