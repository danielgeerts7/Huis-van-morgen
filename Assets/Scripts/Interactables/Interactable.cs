using UnityEngine;
using cakeslice;

public abstract class Interactable : MonoBehaviour
{
    private Outline outline;
    private StepHandler stepHandler;

    public abstract void OnActivate();
    public abstract void OnSelect();
    public abstract void OnDeselect();
    public abstract void OnStart();
    public abstract void OnUpdate();
    public abstract bool isActive();

    private void Awake()
    {
        outline = gameObject.AddComponent<Outline>();
        stepHandler = gameObject.AddComponent<StepHandler>();
    }

    private void Start()
    {
        outline.enabled = false;
        OnStart();
    }

    private void Update()
    {
        OnUpdate();
    }

    public void Select()
    {
        outline.color = 0;
        outline.enabled = true;

        OnSelect();
    }

    public void Deselect()
    {
        if (stepHandler.IsActive())
        {
            outline.color = 1;
        }
        else
        {
            outline.enabled = false;
        }

        OnDeselect();
    }

    public void Activate()
    {
        stepHandler.Activate();
        OnActivate();
    }
}