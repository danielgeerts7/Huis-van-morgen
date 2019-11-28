using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedStep : Step
{
    public override void OnActivate()
    {
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 8)
        {
            state = State.COMPLETED;
        }
    }
}
