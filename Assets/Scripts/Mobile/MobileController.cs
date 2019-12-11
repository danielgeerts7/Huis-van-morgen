using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MobileController : MonoBehaviour
{
    public bool MobileIsActive = false;
    private List<GameObject> panelList;
    private List<GameObject> buttonListMainMenu;

    Dictionary<GameObject, LightController> buttonDictLightsMenu;
    Dictionary<GameObject, CurtainController> buttonDictCurtainMenu;

    private GameObject domoticaController;
    public GameObject buttonPrefab;
    public GameObject toggleButtonPrefab;

    private LightController[] lightControllers;
    private CurtainController[] curtainControllers;

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
      
        foreach (Transform child in this.transform)
        {
            panelList.Add(child.gameObject);
        }

        domoticaController = GameObject.FindObjectOfType<DomoticaController>().gameObject;

        buttonDictLightsMenu = new Dictionary<GameObject, LightController>();
        buttonDictCurtainMenu = new Dictionary<GameObject, CurtainController>();
        buttonListMainMenu = new List<GameObject>();

        CreateButtons(typeof(string));
        CreateButtons(typeof(CurtainController));
        CreateButtons(typeof(LightController));
        this.gameObject.SetActive(false);
    }


    private void Update()
    {
        if (this.gameObject.activeSelf == true)
        {
            SetLightButonsToRightState();
            SetCurtainsButonsToRightState();
        }
    }

    private void CreateButtons(System.Type type)
    {

        float x = 47.65f;
        float a = 30.64f;
        if (type == typeof(string))
        {

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
        for (int i = 0; i < panelList.Count; i++)
        {
            if (panelList[i].activeSelf) panelList[i].SetActive(false);
        }
    }


    public void OpenPanel(GameObject panel)
    {
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
        if (panelList == null)
        {
            foreach (Transform child in this.transform)
            {
                panelList.Add(child.gameObject);
            }
        }
        messagePanel.GetComponentInChildren<Text>().text = s;
        OpenPanel(messagePanel);
    }
}
