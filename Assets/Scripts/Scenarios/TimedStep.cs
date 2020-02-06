using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedStep : Step
{
    public float timeLength;
    private float startTime;

    public override void OnActivate()
    {
    }

    public override void OnRun()
    {
        startTime = Time.time;
        state = State.RUNNING;

    }

    public override void OnStart()
    {

    }

    public override void OnUpdate()
    {
        if (startTime + timeLength < Time.time)
        {
            state = State.COMPLETED;
        }
    }
}
