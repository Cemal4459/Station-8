using UnityEngine;

public class Interact : MonoBehaviour
{
    public float distance = 2f;
    public Camera cam;
    public ScreenFade screenFade;
    public GameObject ePromptUI;

    private InteractableObject currentInteractable;

    void Start()
    {
        if (cam == null)
            cam = Camera.main;

        if (screenFade == null)
            screenFade = Object.FindFirstObjectByType<ScreenFade>();

        if (ePromptUI != null)
            ePromptUI.SetActive(false);
    }

    void Update()
    {
        if (cam == null) return;

        CheckInteractable();

        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact(); // NPC / kapý / item neyse çalýþýr

            if (screenFade != null)
                screenFade.FadeToBlack();
        }
    }

    void CheckInteractable()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        InteractableObject newInteractable = null;

        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.TryGetComponent(out InteractableObject interactable))
            {
                newInteractable = interactable;
            }
        }

        if (newInteractable != currentInteractable)
        {
            if (currentInteractable != null)
                currentInteractable.HighlightOff();

            currentInteractable = newInteractable;

            if (currentInteractable != null)
                currentInteractable.HighlightOn();
        }

        if (ePromptUI != null)
            ePromptUI.SetActive(currentInteractable != null);
    }

    void OnDisable()
    {
        if (currentInteractable != null)
            currentInteractable.HighlightOff();

        if (ePromptUI != null)
            ePromptUI.SetActive(false);
    }
}