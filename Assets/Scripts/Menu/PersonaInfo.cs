using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Daniël Geerts
/// Persona INFO -> from huis-van-morgen_info.json
/// </summary>
[Serializable]
public struct PersonaInfo
{
    public int BSN;
    public string firstName;
    public string lastName;
    public int age;
    public string mugshotPath;

    public string biography;
    public string[] limitations;
    public string inGameEffect;

    public string getFullName() {
        return firstName + " " + lastName;
    }
}
