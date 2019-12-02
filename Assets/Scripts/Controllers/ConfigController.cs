using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigController : MonoBehaviour
{
    // Get configs of House, Scenario, Persona
    public GameObject houseConfig;
    public GameObject scenarioConfig;
    public GameObject personaConfig;

    private static ConfigController instance;

    private HouseInfo currHouse;
    private ScenarioInfo currScenario;
    private PersonaInfo currPersona;

    public enum CardType { HOUSE, SCENARIO, PERSONA };

    public List<HouseInfo> GetHouses() {
        return new List<HouseInfo>(houseConfig.GetComponents<HouseInfo>());
    }

    public List<ScenarioInfo> GetScenarios()
    {
        return new List<ScenarioInfo>(scenarioConfig.GetComponents<ScenarioInfo>());
    }

    public List<PersonaInfo> GetPersonas()
    {
        return new List<PersonaInfo>(personaConfig.GetComponents<PersonaInfo>());
    }

    /*
     * Make this class a singleton
     * Dont destroy the first loaded object of this type
     * Do destroy the rest
     */
    void Awake()
    {
        // If the instance reference has not been set, yet, 
        if (instance == null)
        {
            // Set this instance as the instance reference.
            instance = this;
        }
        else if (instance != this)
        {
            // If the instance reference has already been set, and this is not the
            // the instance reference, destroy this game object.
            Destroy(gameObject);
        }

        // Do not destroy this object, when we load a new scene.
        DontDestroyOnLoad(gameObject);
    }

    public void SetSelectedHouse(HouseInfo house)
    {
        this.currHouse = house;
    }

    public void SetSelectedScenario(ScenarioInfo scenario)
    {
        this.currScenario = scenario;
    }

    public void SetSelectedPersona(PersonaInfo persona)
    {
        this.currPersona = persona;
    }

    /*
     * Return current selected House
     */
    public HouseInfo GetSelectedHouse()
    {
        return this.currHouse;
    }

    /*
     * Return current selected Scenario
     */
    public ScenarioInfo GetSelectedScenario()
    {
        return this.currScenario;
    }

    /*
     * Return current selected Persona
     */
    public PersonaInfo GetSelectedPersona()
    {
        return this.currPersona;
    }

}
