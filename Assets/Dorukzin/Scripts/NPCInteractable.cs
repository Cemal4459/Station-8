using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public GameObject interactPrompt;
    public bool isCorrectNPC = false;

    private Renderer rend;
    private Color originalColor;

    void Start()
    {
        rend = GetComponentInChildren<Renderer>();

        if (rend != null)
        {
            originalColor = rend.material.color;
        }

        if (interactPrompt != null)
        {
            interactPrompt.SetActive(false);
        }
    }

    public void Select()
    {
        if (rend != null)
        {
            rend.material.color = Color.yellow;
        }

        if (interactPrompt != null)
        {
            interactPrompt.SetActive(true);
        }
    }

    public void Deselect()
    {
        if (rend != null)
        {
            rend.material.color = originalColor;
        }

        if (interactPrompt != null)
        {
            interactPrompt.SetActive(false);
        }
    }

    public void Interact()
    {
        Debug.Log(gameObject.name + " ile etkileşim kuruldu.");

        if (isCorrectNPC)
        {
            Debug.Log("SUCCESS");
        }
        else
        {
            Debug.Log("GAME OVER");
        }
    }
}