using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Select();
    public abstract void Deselect();
    public abstract void Activate();    
}