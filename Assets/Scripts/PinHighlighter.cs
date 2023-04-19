using UnityEngine;

public class PinHighlighter : MonoBehaviour
{
    public Color highlightColor = Color.yellow;
    private Color originalColor;
    private Renderer pinRenderer;

    void Start()
    {
        pinRenderer = GetComponent<Renderer>();
        originalColor = pinRenderer.material.color;
    }

    void OnMouseEnter()
    {
        pinRenderer.material.color = highlightColor;
    }

    void OnMouseExit()
    {
        pinRenderer.material.color = originalColor;
    }
}
