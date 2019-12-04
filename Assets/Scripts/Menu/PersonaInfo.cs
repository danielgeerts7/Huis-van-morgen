using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public string getFullName() {
        return firstName + " " + lastName;
    }
}
