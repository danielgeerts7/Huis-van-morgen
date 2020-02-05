using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Daniël Geerts
/// Scenario INFO -> from huis-van-morgen_info.json
/// </summary>
[Serializable]
public struct ScenarioInfo
{
    public int ID;
    public string title;
    public string imagePath;
    public int[] houseIDs;
}
