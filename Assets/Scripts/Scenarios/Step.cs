using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Step
{
    public string stepName;
    public string stepDescription;
    public StepType stepType;
    public List<GameObject> gameObjects;
    private List<StepComponent> stepComponents;

    private bool isRunning;
    private bool isComplete;

    // Start is called before the first frame update
    public void Start()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            StepComponent stepComponent;

            switch (stepType)
            {
                case StepType.ACTIVATE:
                    stepComponent = gameObject.AddComponent<ActivateStep>();
                    break;
                case StepType.CONDITIONAL:
                    stepComponent = gameObject.AddComponent<ConditionalStep>();
                    break;
                default:
                    stepComponent = null;
                    break;
            }

            if (stepComponent)
                stepComponent.addStep(this);
        }
    }

    public void Run()
    {
        if (isComplete)
        {
            Debug.LogWarning($"Attempting to run step \"{stepName}\" while it's already completed");
        }

        isRunning = true;
    }

    public void Activate()
    {
        switch (stepType)
        {
            case StepType.ACTIVATE:
                if (isRunning && !isComplete)
                {
                    isRunning = false;
                    isComplete = true;
                }
                break;
            case StepType.CONDITIONAL:
                bool completed = true;
                foreach (StepComponent component in stepComponents)
                {
                    if (!component.IsComplete())
                        completed = false;
                }

                if (completed)
                {
                    isRunning = false;
                    isComplete = true;
                }
                break;
            default:
                Debug.LogError($"Step type of {this.stepName} not set");
                break;
        }
    }

    public bool IsComplete()
    {
        return isComplete;
    }

    public bool IsRunning()
    {
        return isRunning;
    }
}

public enum StepType
{
    ACTIVATE, CONDITIONAL
}