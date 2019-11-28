using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Step : MonoBehaviour
{
    public string stepDescription;
    public State state;
    public List<GameObject> gameObjects;

    // Start is called before the first frame update
    void Start()
    {
        AddToGameObjects();
        state = State.WAITING;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Run()
    {
        state = State.RUNNING;
    }

    private void AddToGameObjects()
    {
        foreach (GameObject go in gameObjects)
        {
            Debug.Log("Adding stephandler");
            // Get StepHandler, add if GameObject has none
            StepHandler stepHandler = go.GetComponent<StepHandler>();

            if (stepHandler == null)
                stepHandler = go.AddComponent<StepHandler>();

            stepHandler.AddStep(GetComponent<Step>());
        }
    }

    public abstract void OnActivate();

    public void Activate()
    {
        OnActivate();
    }

    public State getState()
    {
        return state;
    }

    public string GetStepDescription()
    {
        return stepDescription;
    }
}
