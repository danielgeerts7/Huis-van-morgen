using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// This is a mobile controller class. This class adds buttons to the mobile controller
/// This class works with panels, then the buttons are created on the panels.
/// @Version: 1.0
/// @Authors: Florian Molenaars
/// </summary>
public class MobileController : MonoBehaviour
{

    private List<GameObject> panelList;
    private List<GameObject> buttonListMainMenu;

    /// <summary>
    /// the domotica that the main panel shows
    /// </summary>
    Dictionary<GameObject, LightController> buttonDictLightsMenu;
    Dictionary<GameObject, CurtainController> buttonDictCurtainMenu;

    /// <summary>
    /// the domoticaController is used to activate domotica(curtains/lights)
    /// </summary>
    private GameObject domoticaController;
    public GameObject buttonPrefab;
    public GameObject toggleButtonPrefab;

    private LightController[] lightControllers;
    private CurtainController[] curtainControllers;

    /// <summary>
    /// this is for the on/off sliders on the buttons
    /// </summary>
    private Transform on;
    private Transform off;
    private Transform ButtonOnOff;

    public GameObject mainMenuPanel;
    public GameObject lightMenuPanel;
    public GameObject curtainMenuPanel;
    public GameObject messagePanel;


    private void Start()
    {
        
        panelList = new List<GameObject>();

        foreach (Transform child in this.transform.GetChild(0).transform)
        {
            panelList.Add(child.gameObject);
        }

        domoticaController = GameObject.FindObjectOfType<DomoticaController>().gameObject;
        buttonDictLightsMenu = new Dictionary<GameObject, LightController>();
        buttonDictCurtainMenu = new Dictionary<GameObject, CurtainController>();
        buttonListMainMenu = new List<GameObject>();

        // calls the function create buttons to create buttons of a specific type of domotica,
        // except the first one. The first one create buttons with all the domotica created in the domotica controller
        CreateButtons(typeof(string));
        CreateButtons(typeof(CurtainController));
        CreateButtons(typeof(LightController));
        transform.GetChild(0).gameObject.SetActive(false);
    }


    private void Update()
    {
        if (this.gameObject.activeSelf == true)
        {
            // To set the on/off button to the right posistion
            SetLightButonsToRightState();
            SetCurtainsButonsToRightState();
        }
    }

    private void CreateButtons(System.Type type)
    {
        // position of starting button
        float x = 47.65f;
        float a = 30.64f;
        if (type == typeof(string))
        {
            // Create buttons in the main menu panel with domotica
            List<string> tempDomotica = domoticaController.GetComponent<DomoticaController>().GetListDomotica();
            for (int i = 0; i < tempDomotica.Count; i++)
            {
                int z = i;
                GameObject butn = Instantiate(buttonPrefab) as GameObject;
                butn.transform.SetParent(mainMenuPanel.transform, false);
                butn.transform.localPosition = new Vector3(0, (x - (a * z)), 0);
                butn.GetComponentInChildren<Text>().text = tempDomotica[i];
                butn.GetComponent<Button>().onClick.AddListener(() => SwitchPanel(tempDomotica[z]));
                buttonListMainMenu.Add(butn);
            }


        }
        if (type == typeof(LightController))
        {
            // Create buttons of all lightcontrollers with the check "show controller in mobile"
            lightControllers = new LightController[domoticaController.GetComponent<DomoticaController>().GetListLights().Length];
            lightControllers = domoticaController.GetComponent<DomoticaController>().GetListLights();
            int z = 0;
            for (int i = 0; i < lightControllers.Length; i++)
            {
                int p = i;
                if (lightControllers[i].ShowControllerInMobile == true)
                {
                    GameObject butn = Instantiate(toggleButtonPrefab) as GameObject;
                    butn.transform.SetParent(lightMenuPanel.transform, false);
                    butn.transform.localPosition = new Vector3(0, (x - (a * z)), 0);
                    butn.GetComponentInChildren<Text>().text = lightControllers[i].controllerName;

                    if (butn != null)
                    {
                        on = butn.transform.Find("Toggle/ON");
                        off = butn.transform.Find("Toggle/OFF");
                    }
                    on.GetComponent<Text>().text = "Aan";
                    off.GetComponent<Text>().text = "Uit";
                    ButtonOnOff = butn.transform.Find("Toggle/Button");
                    ButtonOnOff.GetComponent<Button>().onClick.AddListener(() => SwitchLights(lightControllers[p]));
                    buttonDictLightsMenu.Add(butn, lightControllers[p]);
                    z += 1;
                }
            }
        }
        if (type == typeof(CurtainController))
        {
            // Create buttons of all curtaincontrollers with the check "show controller in mobile"
            CurtainController[] curtainControllers = new CurtainController[domoticaController.GetComponent<DomoticaController>().GetListCurtains().Length];
            curtainControllers = domoticaController.GetComponent<DomoticaController>().GetListCurtains();
            for (int i = 0; i < curtainControllers.Length; i++)
            {
                int z = i;
                GameObject butn = Instantiate(toggleButtonPrefab) as GameObject;
                butn.transform.SetParent(curtainMenuPanel.transform, false);
                butn.transform.localPosition = new Vector3(0, (x - (a * i)), 0);
                butn.GetComponentInChildren<Text>().text = curtainControllers[i].controllerName;
                if (butn != null)
                {
                    on = butn.transform.Find("Toggle/ON");
                    off = butn.transform.Find("Toggle/OFF");
                }
                on.GetComponent<Text>().text = "Open";
                off.GetComponent<Text>().text = "Dicht";
                ButtonOnOff = butn.transform.Find("Toggle/Button");
                ButtonOnOff.GetComponent<Button>().onClick.AddListener(() => SwitchCurtains(curtainControllers[z]));
                buttonDictCurtainMenu.Add(butn, curtainControllers[z]);
            }
        }
    }

    private void SetLightButonsToRightState()
    {
        // sets the on/off toggle button to the right position. This checks if more than half of the lights of the controller is on/off and then switches accordingly
        foreach (KeyValuePair<GameObject, LightController> button in buttonDictLightsMenu)
        {

            if (domoticaController.GetComponent<DomoticaController>().CheckIfLightsAreOn(button.Value))
            {

                button.Key.GetComponentInChildren<ToggleController>().SwitchButtonToOn();
            }
            else
            {
                button.Key.GetComponentInChildren<ToggleController>().SwitchButtonToOff();
            }
        }
    }


    private void SetCurtainsButonsToRightState()
    {
        // sets the on/off toggle button to the right position. This checks if more than half of the curtains of the controller is on/off and then switches accordingly
        foreach (KeyValuePair<GameObject, CurtainController> button in buttonDictCurtainMenu)
        {

            if (domoticaController.GetComponent<DomoticaController>().CheckIfCurtainsAreOpen(button.Value))
            {

                button.Key.GetComponentInChildren<ToggleController>().SwitchButtonToOn();
            }
            else
            {
                button.Key.GetComponentInChildren<ToggleController>().SwitchButtonToOff();
            }
        }
    }
    private void SwitchLights(LightController lightController)
    {
        domoticaController.GetComponent<DomoticaController>().SwitchLightOnRoom(lightController);
    }


    private void SwitchCurtains(CurtainController curtainController)
    {
        domoticaController.GetComponent<DomoticaController>().SwitchCurtainOnRoom(curtainController);
    }


    void ResetPanels()
    {
        // deactivates all panels
        Debug.Log("Resetting");
        for (int i = 0; i < panelList.Count; i++)
        {
            if (panelList[i].activeSelf) panelList[i].SetActive(false);
        }
    }


    public void OpenPanel(GameObject panel)
    {
        // call this function to open a panel. all other panels are automaticly closed with reset panels
        Debug.Log("Opening panel");
        ResetPanels();
        panel.SetActive(true);
    }


    private void SwitchPanel(string s)
    {
        if (s == "Lampen")
        {
            OpenPanel(lightMenuPanel);
        }
        if (s == "Gordijnen")
        {
            OpenPanel(curtainMenuPanel);
        }
    }

    public void SetMessage(string s)
    {
        // to create a message on the mobilephone.
        if (panelList == null)
        {
            foreach (Transform child in this.transform)
            {
                panelList.Add(child.gameObject);
            }
        }
        FindObjectOfType<AudioManager>().Play("Message");
        messagePanel.GetComponentInChildren<Text>().text = s;
        OpenPanel(messagePanel);
    }


    public void OpenSmartphone() {
        // set mobilephone to active
        if (this.gameObject.transform.GetChild(0).gameObject.activeSelf)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
