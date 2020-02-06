using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores the json information from Audio.json in an object
/// Used as helper class to generate a sound file
/// 
/// @Version: 1.0
/// @Authors: Leon Smit
/// </summary>

[System.Serializable]
public class SoundInfo
{
    public string name;
    public string path;
    public float volume;
}
