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

        if (this.GetComponent<MeshRenderer>() != null) {
            outlines.Add(gameObject.AddComponent<Outline>());
        }
        else if (this.GetComponentInChildren<MeshRenderer>() != null)
        {
            foreach (MeshRenderer renderer in this.GetComponentsInChildren<MeshRenderer>()) {
                outlines.Add(renderer.gameObject.AddComponent<Outline>());
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
        foreach (Outline outline in outlines)
        {
            outline.enabled = enabled;
        }
    }

    private void SetOutlineColor(int alpha)
    {
        foreach (Outline outline in outlines)
        {
            outline.color = alpha;
        }
    }
}