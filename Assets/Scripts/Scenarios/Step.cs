using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    public string stepName;
    public string stepDescription;
    private bool isRunning;
    private bool isComplete;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Run()
    {
        if (isComplete)
        {
            Debug.LogError($"Attempting to run step \"{stepName}\" while it's already completed");
        }

        isRunning = true;
    }

    public void Activate()
    {
        if (isRunning && !isComplete)
        {
            isRunning = false;
            isComplete = true;
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
