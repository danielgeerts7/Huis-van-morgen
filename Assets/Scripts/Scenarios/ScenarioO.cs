using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioO : MonoBehaviour
{
    public string introText;
    public string outroText;
    public List<GameObject> StepObjectsList;
    private List<Step> StepsList;

    // Start is called before the first frame update
    void Start()
    {
        SetStepsList();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public string GetIntro()
    {
        return introText;
    }

    public string GetOutro()
    {
        return outroText;
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

    private void SetStepsList()
    {
        StepsList = new List<Step>();
        for (int i = 0; i < StepObjectsList.Count; i++)
        {
            StepsList.Add(StepObjectsList[i].GetComponent<Step>());
        }
    }

    public string GetStepText(int index)
    {
        return StepsList[index].stepDescription;
    }
}
