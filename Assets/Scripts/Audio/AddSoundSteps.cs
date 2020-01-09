using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSoundSteps : MonoBehaviour
{
    // Start is called before the first frame update
    public string nameSong;
    private Step step;
    AudioManager audioManager;
    private bool played = false;

    void Start()
    {
        step = GetComponent<Step>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (step != null)
        {
            if(!played)
            {
                if (step.getState() == State.RUNNING)
                {
                    if (audioManager != null)
                    {
                        audioManager.Play(nameSong);
                    }
                    played = true;
                }
            }
        }
    }
}
