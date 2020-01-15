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

    // Buttons
    private Button currentBtn;

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
        lr.material = new Material(lineMaterial);
        lr.startWidth = 0.008f;
        lr.endWidth = 0.002f;

        standardColor = Color.white;
        //standardLineColor.a = 0.5f;
        lr.material.color = standardColor;

        selectPointer = Instantiate(prefabSelectPointer);
        nonSelectPointer = Instantiate(prefabNonSelectPointer);
    }

    bool pressed = false;
    bool cando = true;

    // Update is called once per frame
    void Update() {

        DrawLightSaber();

        CheckIfRayCastHit();

        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            pressed = true;
        }
        else
        {
            pressed = false;
            cando = true;
        }

        if (pressed && cando)
        {
            // Interactables
            if (currentSelection)
            {
                currentSelection.Activate();
                ChangeLineCol(Color.red);
                cando = false;
            }

            //UI buttons
            if (currentBtn)
            {
                currentBtn.onClick.Invoke();
                ChangeLineCol(Color.red);
                cando = false;
            }
        }
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

            if ((hit.transform && hit.transform.GetComponent<Button>() != null) ||
                (hit.collider && hit.collider.tag.Equals("Interactable")))
            {
                crosshair = selectPointer;
                selectPointer.SetActive(true);
                nonSelectPointer.SetActive(false);
            }
            else
            {
                crosshair = nonSelectPointer;
                selectPointer.SetActive(false);
                nonSelectPointer.SetActive(true);
                if (currentSelection) currentSelection.Deselect();
                currentSelection = null;
                currentBtn = null;
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
            lr.startColor = lr.material.color = crosshair.GetComponent<SpriteRenderer>().color = selectionColor;

            if (hit.collider.tag.Equals("Interactable") && FindObjectOfType<PlayerController>().PlayerControlsEnabled())
            {
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
                // Check if isButton
                bool succes = hit.collider.gameObject.TryGetComponent<Button>(out Button lookAtButton);
                if (succes)
                {
                    if (!lookAtButton.Equals(currentBtn)) {
                        ButtonDeselect();
                    }
                    currentBtn = lookAtButton;
                    Color newCol = currentBtn.transform.GetComponent<Image>().color;
                    newCol.a = 0.5f;
                    currentBtn.transform.GetComponent<Image>().color = newCol;
                }
            }
            else
            {
                ChangeLineCol(standardColor);
                crosshair.GetComponent<SpriteRenderer>().color = standardColor;
            }
        }
        else
        {
            selectPointer.SetActive(false);
            nonSelectPointer.SetActive(false);

            if (currentBtn)
            {
                ButtonDeselect();
                currentBtn = null;
            }
            if (currentSelection)
            {
                currentSelection.Deselect();
                currentSelection = null;
            }
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

    private void ChangeLineCol(Color col) {
        lr.startColor = col;
        lr.endColor = col;
        lr.material.color = col;
    }
}
