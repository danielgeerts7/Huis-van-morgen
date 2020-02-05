using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using OVRSimpleJSON;
using UnityEngine.UI;

/// <summary>
/// Author: Daniël Geerts
/// Singleton class. Loaded in MenuScene and used thoughout the whole project
/// Contains all information from the JSON
/// Contains selected houseInfo, scenarioInfo and personaInfo from MenuScene
/// Scenes can use the information inside this class, for example: to get the selected Scenario or Persona
/// </summary>
public class ConfigController : MonoBehaviour
{
    // Get configs of House, Scenario, Persona
    private JSONNode info;

    public HouseInfo[] houses;
    public ScenarioInfo[] scenarios;
    public PersonaInfo[] personas;

    private static ConfigController instance;

    private HouseInfo currHouse;
    private ScenarioInfo currScenario;
    private PersonaInfo currPersona;

    public enum CardType { HOUSE, SCENARIO, PERSONA };

    /**
     * Awake & Instance makes this class a singleton
     * Dont Destroy the first loaded object of this type
     * then, Do Destroy the rest
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

        //Read the text from the HuisvanMorgen_info.json file
        TextAsset textfromfile = Resources.Load<TextAsset>("HuisvanMorgen_info");
        if (textfromfile != null)
        {
            using (StreamReader sr = new StreamReader(new MemoryStream(textfromfile.bytes)))
            {
                string json = sr.ReadToEnd();
                info = JSON.Parse(json);

                houses = JsonHelper.getJsonArray<HouseInfo>(info["houses"].ToString());
                scenarios = JsonHelper.getJsonArray<ScenarioInfo>(info["scenarios"].ToString());
                personas = JsonHelper.getJsonArray<PersonaInfo>(info["personas"].ToString());

                sr.Close();
            }
        }
    }

    public List<HouseInfo> GetHouses() {
       return new List<HouseInfo>(houses);
    }

    public List<ScenarioInfo> GetScenarios()
    {
        return new List<ScenarioInfo>(scenarios);
    }

    public List<PersonaInfo> GetPersonas()
    {
        return new List<PersonaInfo>(personas);
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
