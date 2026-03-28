using UnityEngine;

public class PlayerInteraction1 : MonoBehaviour
{
    public float interactDistance = 6f;
    public GameObject bottomActionPanel;
    public LayerMask interactMask;

    private bool menuOpen = false;
    private Camera playerCam;

    void Start()
    {
        playerCam = Camera.main;

        if (playerCam == null)
            Debug.LogError("Main Camera bulunamadi!");

        if (bottomActionPanel == null)
            Debug.LogError("Bottom Action Panel atanmamis!");
    }

    void Update()
    {
        if (playerCam == null) return;

        if (!menuOpen)
        {
            Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance, interactMask))
            {
                Debug.Log("Carpilan obje: " + hit.collider.name);

                if (hit.collider.CompareTag("NPC"))
                {
                    Debug.Log("NPC goruldu");

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.Log("E basildi, menu aciliyor");
                        OpenMenu();
                    }
                }
            }
        }

        if (menuOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseMenu();
        }
    }

    void OpenMenu()
    {
        if (bottomActionPanel == null) return;

        bottomActionPanel.SetActive(true);
        menuOpen = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void CloseMenu()
    {
        if (bottomActionPanel == null) return;

        bottomActionPanel.SetActive(false);
        menuOpen = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}