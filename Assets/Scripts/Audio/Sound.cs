using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sound object created from SoundInfo object
/// Used to be played by AudioManager
/// 
/// @Version: 1.0
/// @Authors: Leon Smit
/// </summary>
[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume=1f;
    [Range(.1f, 3f)]
    public float pitch=1f;
    public bool loop;

    [HideInInspector]
    public AudioSource source;

    public Sound(SoundInfo soundInfo)
    {
        this.name = soundInfo.name;
        this.volume = soundInfo.volume;
        this.clip = Resources.Load<AudioClip>(soundInfo.path);
    }
}
