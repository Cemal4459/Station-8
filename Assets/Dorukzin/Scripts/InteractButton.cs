using UnityEngine;

public class InteractButton : MonoBehaviour
{
    public GameObject panel;
    public float interactDistance = 3f;

    private Camera playerCamera;

    void Start()
    {
        playerCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    panel.SetActive(true);
                }
            }
        }
    }
}