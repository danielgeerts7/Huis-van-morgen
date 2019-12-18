using UnityEngine;
using cakeslice;
using System.Collections.Generic;

public abstract class Interactable : MonoBehaviour
{
    private List<Outline> outlines;
    private StepHandler stepHandler;

    public abstract void OnActivate();
    public abstract void OnSelect();
    public abstract void OnDeselect();
    public abstract void OnStart();
    public abstract void OnUpdate();
    public abstract bool isActive();

    private void Awake()
    {
        outlines = new List<Outline>();

        if (this.gameObject.GetComponent<Renderer>() != null)
        {
            outlines.Add(this.gameObject.AddComponent<Outline>());
        }
        else if (this.gameObject.GetComponentInChildren<Renderer>() != null)
        {
            // for example: Curtains use multiple childern gameobjects
            foreach (Renderer renderer in this.gameObject.GetComponentsInChildren<Renderer>())
            {
                if (renderer != null)
                {
                    outlines.Add(renderer.gameObject.AddComponent<Outline>());
                }
            }
        }
        stepHandler = gameObject.AddComponent<StepHandler>();
    }

    private void Start()
    {
        SetOutline(false);
        OnStart();
    }

    private void Update()
    {
        OnUpdate();
    }

    public void Select()
    {
        SetOutlineColor(0);
        SetOutline(true);

        OnSelect();
    }

    public void Deselect()
    {
        if (stepHandler.IsActive())
        {
            SetOutlineColor(1);
        }
        else
        {
            SetOutline(false);
        }

        OnDeselect();
    }

    public void Activate()
    {
        stepHandler.Activate();
        OnActivate();
    }

    private void SetOutline(bool enabled) {
        if (outlines.Count > 0)
        {
            foreach (Outline outline in outlines)
            {
                outline.enabled = enabled;
            }
        }
    }

    private void SetOutlineColor(int alpha)
    {
        if (outlines.Count > 0)
        {
            foreach (Outline outline in outlines)
            {
                outline.color = alpha;
            }
        }
    }
}