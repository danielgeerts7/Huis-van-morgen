using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MobileController : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> panelList;
    private List<GameObject> buttonListMainMenu;
    private List<GameObject> buttonListLightsMenu;
    private List<GameObject> buttonListCurtainsMenu;


    private GameObject domoticaController;
    public GameObject buttonPrefab;
    public GameObject toggleButtonPrefab;

    private Transform on;
    private Transform off;
    private Transform ButtonOnOff;

    private GameObject mainMenuPanel;
    private GameObject lightMenuPanel;
    private GameObject curtainMenuPanel;


    void Start()
    {

        mainMenuPanel = this.transform.GetChild(0).gameObject;
        lightMenuPanel = this.transform.GetChild(1).gameObject;
        curtainMenuPanel = this.transform.GetChild(2).gameObject;

        panelList = new List<GameObject>();
        buttonListMainMenu = new List<GameObject>();
        buttonListLightsMenu = new List<GameObject>();
        buttonListCurtainsMenu = new List<GameObject>();
        foreach (Transform child in this.transform)
        {
            panelList.Add(child.gameObject);
        }   

        domoticaController = GameObject.FindObjectOfType<DomoticaController>().gameObject;

        createButtons(typeof(string));
        createButtons(typeof(CurtainController));
        createButtons(typeof(LightController));
    }

    void update()
    {
    }
    private void createButtons(System.Type type)
    {
        
        float x = 42.64f;
        float a = 30.64f;
        if (type == typeof(string))
        {
            
            List<string> tempDomotica = domoticaController.GetComponent<DomoticaController>().GetListDomotica();
            for (int i = 0; i < tempDomotica.Count; i++)
            {
                int z = i;
                GameObject butn = Instantiate(buttonPrefab) as GameObject;
                butn.transform.SetParent(mainMenuPanel.transform, false);
                butn.transform.localPosition = new Vector3(0, (x -= (a * i)), 0);
                butn.GetComponentInChildren<Text>().text = tempDomotica[i];
                butn.GetComponent<Button>().onClick.AddListener(() => SwitchPanel(tempDomotica[z]));
                buttonListMainMenu.Add(butn);
            }

                
        }
        if (type == typeof(LightController))
        {
            LightController[] lightControllers = new LightController[domoticaController.GetComponent<DomoticaController>().GetListLights().Length];
            lightControllers = domoticaController.GetComponent<DomoticaController>().GetListLights();
            for (int i = 0; i < lightControllers.Length; i++)
            {
                int z = i;
                GameObject butn = Instantiate(toggleButtonPrefab) as GameObject;
                butn.transform.SetParent(lightMenuPanel.transform, false);
                butn.transform.localPosition = new Vector3(0, (x -= (a * i)), 0);
                butn.transform.parent = lightMenuPanel.transform;
                butn.GetComponentInChildren<Text>().text = lightControllers[i].name;

                if (butn != null)
                {
                    on = butn.transform.Find("Toggle/ON");
                    off = butn.transform.Find("Toggle/OFF");
                }
                on.GetComponent<Text>().text = "Aan";
                off.GetComponent<Text>().text = "Uit";
                ButtonOnOff = butn.transform.Find("Toggle/Button");
                ButtonOnOff.GetComponent<Button>().onClick.AddListener(() => SwitchLights(lightControllers[z].name));
                buttonListLightsMenu.Add(butn);
            }
        }
        if (type == typeof(CurtainController))
        {
            CurtainController[] curtainControllers = new CurtainController[domoticaController.GetComponent<DomoticaController>().GetListCurtains().Length];
            curtainControllers = domoticaController.GetComponent<DomoticaController>().GetListCurtains();
            domoticaController.GetComponent<DomoticaController>().GetListCurtains();
                for (int i = 0; i < curtainControllers.Length; i++)
                {
                    int z = i;
                    GameObject butn = Instantiate(toggleButtonPrefab) as GameObject;
                    butn.transform.SetParent(curtainMenuPanel.transform, false);
                    butn.transform.localPosition = new Vector3(0, (x -= (a * i)), 0);
                    butn.GetComponentInChildren<Text>().text = curtainControllers[i].name;
                if (butn != null)
                    {
                        on = butn.transform.Find("Toggle/ON");
                        off = butn.transform.Find("Toggle/OFF");
                    }
                        on.GetComponent<Text>().text = "Open";
                        off.GetComponent<Text>().text = "Dicht";
                        ButtonOnOff = butn.transform.Find("Toggle/Button");
                        ButtonOnOff.GetComponent<Button>().onClick.AddListener(() => SwitchCurtains(curtainControllers[z].name));
                        buttonListCurtainsMenu.Add(butn);
            }
        }
    }
    void ResetPanels()
    {
        for (int i = 0; i < panelList.Count; i++)
        {
            if (panelList[i].activeSelf) panelList[i].SetActive(false);
        }
    }
    public void OpenPanel(int index)
    {
        ResetPanels();
        panelList[index].SetActive(true);
    }
    private void SwitchLights(string s)
    {
        domoticaController.GetComponent<DomoticaController>().TurnOnLightOnRoom(s);
    }
    private void SwitchCurtains(string s)
    {
        domoticaController.GetComponent<DomoticaController>().OpenCurtainOnRoom(s);
    }
    private void SwitchPanel(string s)
    {
        if(s == "Lampen")
        {
            OpenPanel(1);
        }
        if (s == "Gordijnen")
        {
            OpenPanel(2);
        }
    }
}
