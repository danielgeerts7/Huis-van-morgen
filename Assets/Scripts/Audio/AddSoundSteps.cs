using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// After making an scenario put this class on an stepobject to add sound.
/// 
/// @Version: 1.0
/// @Authors: Florian Molenaars
/// </summary>
public class AddSoundSteps : MonoBehaviour
{
    // Start is called before the first frame update
    public string nameSong;
    private Step step;
    AudioManager audioManager;
    private bool played = false;
    public float delay = 0.0f;
    private bool activated = false;
    private float startTime = 0.0f;

    void Start()
    {
        step = GetComponent<Step>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if the step is active
        if (!step) return;

        if (!activated)
        {
            if (step.getState() == State.RUNNING)
            {
                activated = true;
                startTime = Time.time;
            }
        }
        // add delay in sec after the step started
        if (!played && activated && startTime + delay <= Time.time)
        {
            if (audioManager)
            {
                audioManager.Play(nameSong);
            }
            played = true;
        }
    }
}
