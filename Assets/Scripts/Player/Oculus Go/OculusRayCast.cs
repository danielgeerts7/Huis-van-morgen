using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class OculusRayCast : MonoBehaviour
{
    public float raycastLength = 2000;
    public float lightsaberLength = 5;

    public GameObject pointer;

    // Raycast
    private RaycastHit hit;

    // Interactable
    private Interactable currentSelection;
    private bool gazeAtInteractable = false;

    // Buttons
    private Button currentBtn;
    private Color btnStartColor = Color.white;
    private bool gazeAtButton = false;

    // Line
    public Material lineMaterial;
    private Color standardLineColor;
    private GameObject myLine;
    private LineRenderer lr;

    private void Start()
    {
        myLine = new GameObject("Oculus laser pointer");
        myLine.AddComponent<LineRenderer>();

        lr = myLine.GetComponent<LineRenderer>();
        lr.receiveShadows = false;
        lr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        lr.useWorldSpace = false;
        lr.material = lineMaterial;
        lr.startWidth = 0.008f;
        lr.endWidth = 0.0f;

        standardLineColor = Color.white;
//        standardLineColor.a = 0.5f;
        lineMaterial.color = standardLineColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Back))
        {
            SceneManager.LoadScene("MenuScene");
        }

        gazeAtButton = false;
        gazeAtInteractable = false;

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit raycastHit;
        Vector3 endPosition = transform.position + (transform.forward * lightsaberLength);
        if (Physics.Raycast(ray, out raycastHit, lightsaberLength))
        {
            endPosition = raycastHit.point;
        }

        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, endPosition);

        pointer.SetActive(false);

        Vector3 origin = transform.position;
        Vector3 direction = transform.forward * raycastLength;
        if (Physics.Raycast(origin, direction, out hit, raycastLength))
        {
            direction = hit.point;

            float distance = Vector3.Distance(origin, direction);
            pointer.transform.localScale = new Vector3(distance / 75, distance / 75, pointer.transform.localScale.z);
            Vector3 targetPoint = new Vector3(hit.transform.position.x, transform.position.y, hit.transform.position.z) - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(-targetPoint, Vector3.up);
            pointer.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);


            if ((hit.transform && hit.transform.GetComponent<Button>()) ||
                (hit.collider && hit.collider.tag.Equals("Interactable")))
            {
                pointer.SetActive(true);
                pointer.transform.position = hit.point;
            //if (hit.collider.tag.Equals("Interactable") || hit.transform.GetComponent<Button>() != null) {
                pointer.GetComponent<SpriteRenderer>().color = Color.green;
                lineMaterial.color = Color.green;
            }

            if (hit.collider.tag.Equals("Interactable"))
            {
                // Check if isInteractable
                bool succes = hit.collider.gameObject.TryGetComponent<Interactable>(out Interactable newSelection);
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
            else if (hit.transform.GetComponent<Button>() != null)
            {
                // Check if isButton
                bool succes = hit.collider.gameObject.TryGetComponent<Button>(out Button lookAtButton);
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
            pointer.GetComponent<SpriteRenderer>().color = Color.white;
            lineMaterial.color = standardLineColor;
        }

        if (!gazeAtButton && currentBtn)
        {
            ButtonDeselect();
            pointer.GetComponent<SpriteRenderer>().color = Color.white;
            lineMaterial.color = standardLineColor;
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
        if (VRhelper.m_modelOculusGoController.activeSelf)
        {
            return VRhelper.m_modelOculusGoController;
        }
        // Oculus GearVR Controller
        if (VRhelper.m_modelGearVrController.activeSelf)
        {
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
