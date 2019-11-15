using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigController : MonoBehaviour
{
    // Get configs of House, Scenario, Persona
    public GameObject houseConfig;
    public GameObject scenarioConfig;
    public GameObject personaConfig;

    public static ConfigController instance;

    private House currHouse;
    private Scenario currScenario;
    private Persona currPersona;


    public enum CardType { HOUSE, SCENARIO, PERSONA };

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

    public void SetSelectedHouse(House house)
    {
        this.currHouse = house;
    }

    public void SetSelectedScenario(Scenario scenario)
    {
        this.currScenario = scenario;
    }

    public void SetSelectedPersona(Persona persona)
    {
        this.currPersona = persona;
    }

    /*
     * Return current selected House
     */
    public House GetSelectedHouse()
    {
        return this.currHouse;
    }

    /*
     * Return current selected Scenario
     */
    public Scenario GetSelectedScenario()
    {
        return this.currScenario;
    }

    /*
     * Return current selected Persona
     */
    public Persona GetSelectedPersona()
    {
        return this.currPersona;
    }

}
