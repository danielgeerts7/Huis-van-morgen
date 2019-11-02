using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigController : MonoBehaviour
{

    public GameObject houseConfig;
    public GameObject scenarioConfig;
    public GameObject personaConfig;

    private List<House> houses = new List<House>(8);
    private List<Scenario> scenarios = new List<Scenario>(8);
    private List<Persona> personas = new List<Persona>(8);

    void Start()
    {
        foreach (House h in houseConfig.GetComponents<House>()) {
            houses.Add(h);
        }
        foreach (Scenario s in scenarioConfig.GetComponents<Scenario>())
        {
            scenarios.Add(s);
        }
        foreach (Persona p in personaConfig.GetComponents<Persona>())
        {
            personas.Add(p);
        }
    }

    public List<House> GetHouses() {
        return houses;
    }

    public List<Scenario> GetScenarios()
    {
        return scenarios;
    }

    public List<Persona> GetPersonas()
    {
        return personas;
    }

}
