using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public Material toonOutlineMaterial;
    private Material originalMaterial;
    private Renderer objectRenderer;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;
    }

    private void OnMouseEnter()
    {
        objectRenderer.material = toonOutlineMaterial;
    }

    private void OnMouseExit()
    {
        objectRenderer.material = originalMaterial;
    }

    public void RestoreOriginalMaterial()
    {
        objectRenderer.material = originalMaterial;
    }
}
