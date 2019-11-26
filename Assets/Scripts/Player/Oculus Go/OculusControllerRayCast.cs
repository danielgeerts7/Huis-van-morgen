using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class OculusControllerRayCast : MonoBehaviour
{
    public float rayLength = 2000;
    public float rayShowLength = 10;

    // Raycast
    private RaycastHit vision;

    // Interactable
    private Interactable currentSelection;
    private bool gazeAtInteractable = false;

    // Buttons
    private Button currentBtn;
    private Color btnStartColor = Color.white;
    private bool gazeAtButton = false;

    // Line
    public Material lineMaterial;
    private GameObject myLine;
    LineRenderer lr;

    private void Start()
    {
        myLine = new GameObject();
        myLine.gameObject.transform.parent = DeterminHeadset().transform;
        myLine.AddComponent<LineRenderer>();

        lr = myLine.GetComponent<LineRenderer>();
        lr.material = lineMaterial;
        lr.startWidth = 0.015f;
        lr.endWidth = 0.001f;

        lineMaterial.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Back))
        {
            SceneManager.LoadScene("MenuScene");
            return;
        }

        Vector3 origin = this.transform.position;
        Vector3 direction = this.transform.forward * rayLength;

        Vector3 linedirection = this.transform.forward * rayShowLength;
        //Debug.DrawRay(origin, direction);

        //myLine.transform.position = origin;
        if (lr != null)
        {
            lr.SetPosition(0, origin);
            lr.SetPosition(1, direction);
        }

        gazeAtButton = false;
        gazeAtInteractable = false;

        if (Physics.Raycast(origin, direction, out vision, rayLength))
        {
            if (vision.collider != null)
            {
                lineMaterial.color = Color.green;
            }

            if (vision.collider.tag.Equals("Interactable"))
            {
                // Check if isInteractable
                bool succes = vision.collider.gameObject.TryGetComponent<Interactable>(out Interactable newSelection);
                if (succes)
                {
                    gazeAtInteractable = true;

                    if (currentSelection == null)
                    {
                        currentSelection = newSelection;
                        currentSelection.Select();
                    }
                    else if (currentSelection && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                    {
                        currentSelection.Activate();
                    }
                    else if (!currentSelection.Equals(newSelection))
                    {
                        currentSelection = newSelection;
                    }
                }
            }
            else if (vision.transform.GetComponent<Button>() != null)
            {
                // Check if isButton
                bool succes = vision.collider.gameObject.TryGetComponent<Button>(out Button lookAtButton);
                if (succes)
                {
                    gazeAtButton = true;

                    if (currentBtn == null)
                    {
                        currentBtn = lookAtButton;
                        currentBtn.transform.GetComponent<Image>().color = Color.red;
                    }
                    else if (currentBtn && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                    {
                        currentBtn.onClick.Invoke();
                    }
                    else if (!currentBtn.Equals(lookAtButton))
                    {
                        currentBtn = lookAtButton;
                    }
                }
            }
        }

        if (!gazeAtInteractable && currentSelection)
        {
            currentSelection.Deselect();
            lineMaterial.color = Color.white;
        }

        if (!gazeAtButton && currentBtn)
        {
            ButtonDeselect();
            lineMaterial.color = Color.white;
        }
    }

    private void ButtonDeselect()
    {
        if (currentBtn == null) { return; };

        currentBtn.gameObject.GetComponent<Image>().color = btnStartColor;
        currentBtn = null;
    }

    private void showSmartphone()
    {
        /*if (Input.GetKeyDown(KeyCode.T))
        {
            if (mobileActive)
            {
                mobile.SetActive(true);
                mobileActive = !mobileActive;
            }
            else{
                mobile.SetActive(false);
                mobileActive = !mobileActive;
                }
        }*/
    }

    private GameObject DeterminHeadset()
    {
        OVRControllerHelper VRhelper = this.gameObject.GetComponent<OVRControllerHelper>();

        // Oculus Go Controller
        if (VRhelper.m_modelOculusGoController.activeSelf) {
            return VRhelper.m_modelOculusGoController;
        }
        // Oculus GearVR Controller
        if (VRhelper.m_modelGearVrController.activeSelf) {
            return VRhelper.m_modelGearVrController;
        }
        // Oculus Quest/Rift LEFT Controller
        if (VRhelper.m_modelOculusTouchQuestAndRiftSLeftController.activeSelf)
        {
            return VRhelper.m_modelOculusTouchQuestAndRiftSLeftController;
        }
        // Oculus Quest/Rift RIGHT Controller
        if (VRhelper.m_modelOculusTouchQuestAndRiftSRightController.activeSelf)
        {
            return VRhelper.m_modelOculusTouchQuestAndRiftSRightController;
        }
        // Oculus Touch Right LEFT Controller
        if (VRhelper.m_modelOculusTouchRiftLeftController.activeSelf)
        {
            return VRhelper.m_modelOculusTouchRiftLeftController;
        }
        // Oculus Touch Rift RIGHT Controller
        if (VRhelper.m_modelOculusTouchRiftRightController.activeSelf)
        {
            return VRhelper.m_modelOculusTouchRiftRightController;
        }

        return null;
    }
}
