using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSoundScenario : MonoBehaviour
{
    // Start is called before the first frame update
    public string nameSong;
    public bool playAtIntro = false;
    public bool playAtOutro = false;

    private Scenario scenario;
    private bool played = false;
    private AudioManager audioManager;

    void Start()
    {
        scenario = GetComponent<Scenario>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!played)
        {
            if (playAtIntro && scenario.UsedAsPlayableScenario() && scenario.GetState() == State.WAITING && audioManager != null)
            {
                if (audioManager.Play(nameSong))
                {
                    played = true;
                }
            }

            if (playAtOutro && scenario.UsedAsPlayableScenario() && scenario.GetState() == State.COMPLETED && audioManager != null) {
                if (audioManager.Play(nameSong))
                {
                    played = true;
                }
            }
        }
    }
}
