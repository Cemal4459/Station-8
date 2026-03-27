using UnityEngine;

public class SelectableHighlight : MonoBehaviour
{
    private Renderer[] renderers;
    private Color[] originalColors;

    public Color highlightColor = Color.yellow;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();

        originalColors = new Color[renderers.Length];

        for (int i = 0; i < renderers.Length; i++)
        {
            originalColors[i] = renderers[i].material.color;
        }
    }

    public void HighlightOn()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = highlightColor;
        }
    }

    public void HighlightOff()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = originalColors[i];
        }
    }
}