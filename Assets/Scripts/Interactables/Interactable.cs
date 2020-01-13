using UnityEngine;
using cakeslice;
using System.Collections.Generic;

public abstract class Interactable : MonoBehaviour
{
    private List<Renderer> renderers;
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
        renderers.Add(this.gameObject.GetComponent<Renderer>());
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            renderers.Add(renderer);
        }
        
        stepHandler = gameObject.AddComponent<StepHandler>();
    }

    private void Start()
    {
        //SetOutline(false);
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
        OnActivate();
        stepHandler.Activate();

    }

    private void SetOutline(bool enabled) {
        if (enabled)
        {
            Material outlineMat = new Material(Shader.Find("Specular"));
            outlineMat.color = Color.green;

            Renderer renderer = GetComponent<Renderer>();
            Material[] materials = new Material[renderer.materials.Length + 1];

            for (int i = 0; i < renderer.materials.Length; i++)
            {
                materials[i] = renderer.materials[i];
            }

            materials[materials.Length - 1] = outlineMat;

            renderer.materials = materials;

            Debug.Log(renderer.materials.Length);

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
        } else
        {
            Renderer renderer = GetComponent<Renderer>();
            Material[] materials = new Material[renderer.materials.Length - 1];

            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = renderer.materials[i];
            }

            renderer.materials = materials;


            Debug.Log(renderer.materials.Length);
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