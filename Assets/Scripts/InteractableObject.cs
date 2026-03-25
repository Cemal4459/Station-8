using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public Renderer objectRenderer;
    public Color highlightColor = Color.yellow;

    private Color originalColor;

    void Start()
    {
        if (objectRenderer == null)
            objectRenderer = GetComponent<Renderer>();

        if (objectRenderer != null)
            originalColor = objectRenderer.material.color;
    }

    public void HighlightOn()
    {
        if (objectRenderer != null)
            objectRenderer.material.color = highlightColor;
    }

    public void HighlightOff()
    {
        if (objectRenderer != null)
            objectRenderer.material.color = originalColor;
    }
}