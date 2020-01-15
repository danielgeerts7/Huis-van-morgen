using UnityEngine;
using cakeslice;
using System.Collections.Generic;

public abstract class Interactable : MonoBehaviour
{
    private List<Renderer> renderers;
    private bool outlineIsActive;
    protected StepHandler stepHandler;

    public abstract void OnActivate();
    public abstract void OnSelect();
    public abstract void OnDeselect();
    public abstract void OnStart();
    public abstract void OnUpdate();
    public abstract bool isActive();

    private void Awake()
    {
        renderers = new List<Renderer>();
        stepHandler = gameObject.AddComponent<StepHandler>();
    }

    private void Start()
    {
        Renderer goRenderer = this.gameObject.GetComponent<Renderer>();

        if (goRenderer)
        {
            renderers.Add(goRenderer);
        }

        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            if (renderer) renderers.Add(renderer);
        }

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
        if (stepHandler && stepHandler.IsActive())
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
        OnActivate();
        if (stepHandler) stepHandler.Activate();

    }

    private void SetOutline(bool enabled)
    {
        if (enabled)
        {
            if (outlineIsActive) return;

            Material outlineMat = Resources.Load("Materials/OutlineMaterial", typeof(Material)) as Material;

            foreach (Renderer renderer in renderers)
            {
                Material[] materials = new Material[renderer.materials.Length + 1];

                for (int i = 0; i < renderer.materials.Length; i++)
                {
                    materials[i] = renderer.materials[i];
                }

                materials[materials.Length - 1] = outlineMat;

                renderer.materials = materials;
            }

            outlineIsActive = true;

            /*
            Renderer[] renderers = GetComponents<Renderer>();
            renderers.add(GetComponentsInChildren<Renderer>())
            string renderString = "";
            foreach (Renderer renderer in renderers)
            {
                renderString += "d";
            }
            
            Debug.Log(renderString);
            */
        }
        else
        {
            if (!outlineIsActive) return;

            foreach (Renderer renderer in renderers)
            {
                Material[] materials = new Material[renderer.materials.Length - 1];

                for (int i = 0; i < materials.Length; i++)
                {
                    materials[i] = renderer.materials[i];
                }

                renderer.materials = materials;
            }

            outlineIsActive = false;
        }
    }

    private void SetOutlineColor(int alpha)
    {
        /*if (outlines.Count > 0)
        {
            foreach (Outline outline in outlines)
            {
                outline.color = alpha;
            }
        }*/
    }
}