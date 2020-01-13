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
        if (!step) return;

        if (!activated)
        {
            if (step.getState() == State.RUNNING)
            {
                activated = true;
                startTime = Time.time;
            }
        }

        if (!played && activated && startTime + delay <= Time.time)
        {
            Debug.Log("lskjdflksfdjflkj");
            if (audioManager)
            {
                audioManager.Play(nameSong);
            }
            played = true;
        }
    }
}
