using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSoundScenario : MonoBehaviour
{
    // Start is called before the first frame update
    public string nameSong;
    public bool playSong;
    private Scenario scenario;
    private bool played = false;
    void Start()
    {
        scenario = GetComponent<Scenario>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!played)
        {
            if (scenario.getState() == State.WAITING)
            {
                if (FindObjectOfType<AudioManager>().Play(nameSong))
                {
                    played = true;
                }
            }
            
        }
    }
}
