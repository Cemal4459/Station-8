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
    public GameObject interactPrompt;

    public void ShowPrompt()
    {
        if (interactPrompt != null)
            interactPrompt.SetActive(true);
   
        Debug.Log(gameObject.name + " prompt açýlýyor");

        if (interactPrompt != null)
            interactPrompt.SetActive(true);
    }
    public void HidePrompt()
    {
        if (interactPrompt != null)
            interactPrompt.SetActive(false);
  
        Debug.Log(gameObject.name + " prompt kapanýyor");

        if (interactPrompt != null)
            interactPrompt.SetActive(false);
    }
    public void Interact()
    {
        Debug.Log(gameObject.name + " ile etkileþim kuruldu.");
    }
}