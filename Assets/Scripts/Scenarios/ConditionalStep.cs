using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalStep : Step
{
    public List<Condition> conditions;

    public override void OnActivate()
    {

    }

    public override void OnRun()
    {
        SetOutlines(true);
    }

    public override void OnStart()
    {

    }

    public override void OnUpdate()
    {
        if (!(state == State.RUNNING))
            return;

        bool solved = true;
        foreach (Condition condition in conditions)
        {
            if (!condition.isSolved())
            {
                solved = false;
                break;
            }
        }


        if (solved)
        {
            SetOutlines(false);
            state = State.COMPLETED;
        }
    }

    private void SetOutlines(bool state)
    {
        /*foreach (Condition condition in conditions)
        {
            Interactable interactable = condition.GetInteractable();

            Outline outline = interactable.GetComponent<Outline>();

            if (outline == null)
                outline = interactable.gameObject.AddComponent<Outline>();

            outline.enabled = state;
        }*/
    }

    private void SetOutlineColor(Color color)
    {

    }
}
