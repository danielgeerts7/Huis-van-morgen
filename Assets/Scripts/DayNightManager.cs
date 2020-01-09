using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Author: Daniël Geerts
 * Day and Night system that controls the skybox and lights in the scene
 */
public class DayNightManager : MonoBehaviour
{
    public enum DayPart { NIGHT, MORNING, AFTERNOON, EVENING }

    public Light directionalMain;
    public Light directionalSupport;

    // Night 
    public Material skyboxNight;
    public float lightIntensityNight = 0.25f;

    // Morning
    public Material skyboxMorning;
    public float lightIntensityMorning = 0.75f;

    // Afternoon
    public Material skyboxAfternoon;
    public float lightIntensityAfternoon = 1.0f;

    // Evening
    public Material skyboxEvening;
    public float lightIntensityEvening = 0.5f;

    private void Start()
    {
        SetDayPart(DayPart.MORNING);
    }

    public void SetDayPart(DayPart daypart) {
        switch (daypart)
        {
            case DayPart.NIGHT:
                RenderSettings.skybox = skyboxNight;
                this.SetLights(lightIntensityNight);
                break;
            case DayPart.MORNING:
                RenderSettings.skybox = skyboxMorning;
                this.SetLights(lightIntensityMorning);
                break;
            case DayPart.AFTERNOON:
                RenderSettings.skybox = skyboxAfternoon;
                this.SetLights(lightIntensityAfternoon);
                break;
            case DayPart.EVENING:
                RenderSettings.skybox = skyboxEvening;
                this.SetLights(lightIntensityEvening);
                break;
        }
    }

    private void SetLights(float all)
    {
        SetLights(all, all, all);
    }

    private void SetLights(float main, float support, float rest)
    {
        foreach (Light light in FindObjectsOfType<Light>())
        {
            light.intensity = rest;
        }
        directionalMain.intensity = main;
        directionalSupport.intensity = support;
    }
}
