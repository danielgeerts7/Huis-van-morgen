using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedStep : Step
{
    public float timeLength;
    private float startTime;

    public override void OnActivate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnRun()
    {
        startTime = Time.time;
    }

    public override void OnStart()
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        if (startTime + timeLength < Time.time)
        {
            state = State.COMPLETED;
        }
    }
}
