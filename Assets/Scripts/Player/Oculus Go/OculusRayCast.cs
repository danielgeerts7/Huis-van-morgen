using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class OculusRayCast : MonoBehaviour
{
    public float raycastLength = 2000;
    public float lightsaberLength = 5;

    public GameObject prefabSelectPointer;
    public GameObject prefabNonSelectPointer;

    private GameObject selectPointer;
    private GameObject nonSelectPointer;

    // Raycast
    private RaycastHit hit;

    // Interactable
    private Interactable currentSelection;
    private bool gazeAtInteractable = false;

    // Buttons
    private Button currentBtn;
    private bool gazeAtButton = false;

    // Line
    public Material lineMaterial;
    public Color selectionColor = Color.green;
    private Color standardColor;
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
        lr.generateLightingData = true;
        lr.material = lineMaterial;
        lr.startWidth = 0.008f;
        lr.endWidth = 0.002f;

        standardColor = Color.white;
        //standardLineColor.a = 0.5f;
        lineMaterial.color = standardColor;

        selectPointer = Instantiate(prefabSelectPointer);
        nonSelectPointer = Instantiate(prefabNonSelectPointer);
    }

    // Update is called once per frame
    void Update()
    {
        DrawLightSaber();

        CheckIfRayCastHit();
    }

    private void DrawLightSaber() {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit raycastHit;
        Vector3 endPosition = transform.position + (transform.forward * lightsaberLength);
        if (Physics.Raycast(ray, out raycastHit, lightsaberLength))
        {
            endPosition = raycastHit.point;
        }

        lr.SetPosition(0, this.transform.parent.position);
        lr.SetPosition(1, endPosition);
    }

    private void CheckIfRayCastHit() {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward * raycastLength;
        if (Physics.Raycast(origin, direction, out hit, raycastLength))
        {
            direction = hit.point;

            GameObject crosshair;

            if ((hit.transform && hit.transform.GetComponent<Button>()) ||
                (hit.collider && hit.collider.tag.Equals("Interactable")))
            {
                crosshair = selectPointer;
                selectPointer.SetActive(true);
                nonSelectPointer.SetActive(false);

                gazeAtButton = true;
                gazeAtInteractable = true;
            }
            else
            {
                crosshair = nonSelectPointer;
                selectPointer.SetActive(false);
                nonSelectPointer.SetActive(true);

                gazeAtButton = false;
                gazeAtInteractable = false;
            }

            crosshair.SetActive(true);

            // Position Crosshair
            crosshair.transform.position = hit.point;

            // Scale Crosshair
            float distance = Vector3.Distance(origin, direction);
            if (distance <= 1) { distance = 1; }
            crosshair.transform.localScale = new Vector3(distance / 50, distance / 50, crosshair.transform.localScale.z);

            // Rotation Crosshair
            Vector3 targetPoint = new Vector3(hit.transform.position.x, this.transform.position.y, hit.transform.position.z) - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(-targetPoint, Vector3.up);
            crosshair.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);

            // Crosshair color
            lr.startColor = lineMaterial.color = crosshair.GetComponent<SpriteRenderer>().color = selectionColor;

            if (hit.collider.tag.Equals("Interactable"))
            {
                gazeAtInteractable = true;

                // Check if isInteractable
                bool succes = hit.collider.gameObject.TryGetComponent<Interactable>(out Interactable newSelection);
                if (succes)
                {
                    currentSelection = newSelection;
                    currentSelection.Select();
                }
            }
            else if (hit.transform.GetComponent<Button>() != null)
            {
                gazeAtButton = true;

                // Check if isButton
                bool succes = hit.collider.gameObject.TryGetComponent<Button>(out Button lookAtButton);
                if (succes)
                {
                    currentBtn = lookAtButton;
                    Color newCol = currentBtn.transform.GetComponent<Image>().color;
                    newCol.a = 0.5f;
                    currentBtn.transform.GetComponent<Image>().color = newCol;
                }
            }
            else
            {
                lr.startColor = lineMaterial.color = crosshair.GetComponent<SpriteRenderer>().color = standardColor;
            }
        }
        else
        {
            selectPointer.SetActive(false);
            nonSelectPointer.SetActive(false);
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            // Interactiables
            if (currentSelection)
            {
                currentSelection.Activate();
                lr.startColor = Color.red;
                lineMaterial.color = Color.red;
            }

            //UI buttons
            if (currentBtn)
            {
                currentBtn.onClick.Invoke();
                lr.startColor = Color.red;
                lineMaterial.color = Color.red;
            }
        }

        if (!gazeAtInteractable && currentSelection)
        {
            currentSelection.Deselect();
            currentSelection = null;
            lr.startColor = standardColor;
            lineMaterial.color = standardColor;
        }

        if (!gazeAtButton && currentBtn)
        {
            ButtonDeselect();
            currentBtn = null;
            lr.startColor = standardColor;
            lineMaterial.color = standardColor;
        }
    }

    private void ButtonDeselect()
    {
        if (currentBtn == null) { return; };

        Color temp = currentBtn.gameObject.GetComponent<Image>().color;
        temp.a = 1.0f;
        currentBtn.gameObject.GetComponent<Image>().color = temp;

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
            else
            {
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
