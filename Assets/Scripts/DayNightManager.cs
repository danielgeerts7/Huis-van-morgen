using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour
{
    public List<Light> directionalLights;
    public enum DayPart { DAY, NIGHT }
    public DayPart dayPart;

    public bool isDay()
    {
        return dayPart == DayPart.DAY;
    }

    public bool isNight()
    {
        return dayPart == DayPart.NIGHT;
    }
}
