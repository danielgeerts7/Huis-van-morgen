using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScenarioO
{
    [SerializeField] private string introText;
    [SerializeField] private string introDescription;
    [SerializeField] private string outroText;
    [SerializeField] private string outroDescription;
    public List<Step> StepsList;

    // Start is called before the first frame update
    public void Start()
    {
        foreach (Step step in StepsList)
            step.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public string GetIntro()
    {
        return introText;
    }

    public string GetIntroDescription()
    {
        return introDescription;
    }

    public string GetOutro()
    {
        return outroText;
    }
    
    public string GetOutroDescription()
    {
        return outroDescription;
    }

    public int GetLength()
    {
        return StepsList.Count;
    }

    public void RunStep(int index)
    {
        StepsList[index].Run();
    }

    public bool StepCompleted(int index)
    {
        return StepsList[index].IsComplete();
    }

    public string GetStepText(int index)
    {
        return StepsList[index].stepDescription;
    }
}
