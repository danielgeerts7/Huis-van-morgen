using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Step : MonoBehaviour
{
    public string stepName;
    protected State state;

    public  KeyCode skipKey = KeyCode.P;

    public abstract void OnStart();
    public abstract void OnUpdate();
    public abstract void OnActivate();
    public abstract void OnRun();

    // Start is called before the first frame update
    void Start()
    {
        state = State.WAITING;
        OnStart();
    }

    void Update()
    {
        if (!(state == State.RUNNING))
            return;

        ScenarioController scenarioController = FindObjectOfType<ScenarioController>();
        if (scenarioController.debugMode && Input.GetKeyDown(skipKey))
            state = State.COMPLETED;

        OnUpdate();
    }

    public void Run()
    {
        state = State.RUNNING;
        OnRun();
    }
    public void Activate()
    {
        OnActivate();
    }

    public State getState()
    {
        return state;
    }

    public string GetStepName()
    {
        return stepName;
    }

    


}
