using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigController : MonoBehaviour
{

    public GameObject houseConfig;
    public GameObject scenarioConfig;
    public GameObject personaConfig;

    private House currentSelectedHouse;
    private Scenario currentSelectedScenario;
    private Persona currentSelectedPersona;

    void Start()
    {
    }

    public List<House> GetHouses() {
        return new List<House>(houseConfig.GetComponents<House>());
    }

    public List<Scenario> GetScenarios()
    {
        return new List<Scenario>(scenarioConfig.GetComponents<Scenario>());
    }

    public List<Persona> GetPersonas()
    {
        return new List<Persona>(personaConfig.GetComponents<Persona>());
    }

}
