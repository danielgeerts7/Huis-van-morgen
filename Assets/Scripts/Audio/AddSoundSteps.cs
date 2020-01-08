using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSoundSteps : MonoBehaviour
{
    // Start is called before the first frame update
    public string nameSong;
    private Step step;
    

    void Start()
    {
        step = GetComponent<Step>();
    }

    // Update is called once per frame
    void Update()
    {
        if (step != null)
        {
            if (step.getState() == State.RUNNING)
                GameObject.FindObjectOfType<AudioManager>().Play(nameSong);
        }
    }
}
