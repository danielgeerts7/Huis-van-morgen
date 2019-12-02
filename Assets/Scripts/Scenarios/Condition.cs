using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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
}