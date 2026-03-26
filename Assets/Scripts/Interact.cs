using UnityEngine;

public class Interact : MonoBehaviour
{
    public float distance = 4f;
    public Camera cam;
    public ScreenFade screenFade;
    public GameObject ePromptUI;

    private InteractableObject currentInteractable;

    void Start()
    {
        if (cam == null)
            cam = Camera.main;

        if (screenFade == null)
            screenFade = FindObjectOfType<ScreenFade>();

        if (ePromptUI != null)
            ePromptUI.SetActive(false);
    }

    void Update()
    {
        if (cam == null)
        {
            Debug.LogError("Cam atanmadý.");
            return;
        }

        CheckForInteractable();

        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Etkileþim oldu");

            if (screenFade != null)
                screenFade.FadeToBlack();
        }
    }

    void CheckForInteractable()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        InteractableObject newInteractable = null;

        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                newInteractable = hit.collider.GetComponent<InteractableObject>();
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
        {
            ePromptUI.SetActive(currentInteractable != null);
        }
    }

    void OnDisable()
    {
        if (currentInteractable != null)
            currentInteractable.HighlightOff();

        if (ePromptUI != null)
            ePromptUI.SetActive(false);
    }
}