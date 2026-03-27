using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 5f;
    public LayerMask interactLayer;

    private NPCInteractable currentNPC;

    void Update()
    {
        CheckLookAtObject();

        if (Input.GetKeyDown(KeyCode.E) && currentNPC != null)
        {
            currentNPC.Interact();
        }
    }

    void CheckLookAtObject()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            NPCInteractable npc = hit.collider.GetComponentInParent<NPCInteractable>();

            if (npc != null)
            {
                if (currentNPC != npc)
                {
                    ClearCurrentSelection();
                    currentNPC = npc;
                    currentNPC.Select();
                }

                return;
            }
        }

        ClearCurrentSelection();
    }

    void ClearCurrentSelection()
    {
        if (currentNPC != null)
        {
            currentNPC.Deselect();
            currentNPC = null;
        }
    }
}