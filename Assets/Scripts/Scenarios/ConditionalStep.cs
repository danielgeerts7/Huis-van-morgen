using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A step that is completed when all its conditions are met
/// @Version: 1.0
/// @Authors: Leon Smit
/// </summary>
public class ConditionalStep : Step
{
    public List<Condition> conditions;

    public override void OnActivate()
    {
    }

    public override void OnRun()
    {
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
            state = State.COMPLETED;
        }
    }
}
