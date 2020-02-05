using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/// <summary>
/// Used by CondtionalStep, contains gameobject and gets the interactable component from it. 
/// Decides how to evaluate whether a condition is met. 
/// Add more ConditionTypes to add more kinds of condition
/// @Version: 1.0
/// @Authors: Leon Smit
/// </summary>
public class Condition
{
    public GameObject gameObject;
    private Interactable interactable;
    public enum ConditionType { ACTIVE, NOTACTIVE };
    public ConditionType type;

    public bool isSolved()
    {
        if (!interactable)
            interactable = gameObject.GetComponent<Interactable>();

        switch (type)
        {
            case ConditionType.ACTIVE:
                return (interactable.isActive());
            case ConditionType.NOTACTIVE:
                return (!interactable.isActive());
            default:
                return false;
        }
    }

    public Interactable GetInteractable()
    {
        return interactable;
    }
}