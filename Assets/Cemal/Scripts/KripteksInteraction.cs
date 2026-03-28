using UnityEngine;

public class KripteksInteraction : MonoBehaviour
{
    public float interactDistance = 4f;
    public GameObject kripteksPanel;
    public GameObject kripteksCorner;
    public GameObject pressEIcon;
    public LayerMask interactMask;

    public PlayerMovement playerMovement;
    public MouseLook mouseLook;

    private Camera playerCam;
    private bool kripteksOpen = false;

    void Start()
    {
        playerCam = Camera.main;
    }

    void Update()
    {
        if (playerCam == null) return;

        if (!kripteksOpen)
        {
            Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance, interactMask))
            {
                if (hit.collider.CompareTag("Kripteks"))
                {
                    if (pressEIcon != null)
                        pressEIcon.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.F)) // sadece burası değişti
                    {
                        OpenKripteks();
                    }

                    return;
                }
            }
        }

        if (!kripteksOpen && pressEIcon != null)
            pressEIcon.SetActive(false);

        if (kripteksOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseKripteks();
        }
    }

    public void OpenKripteks()
    {
        if (kripteksPanel != null)
            kripteksPanel.SetActive(true);

        if (kripteksCorner != null)
            kripteksCorner.SetActive(false);

        if (pressEIcon != null)
            pressEIcon.SetActive(false);

        if (playerMovement != null)
            playerMovement.canMove = false;

        if (mouseLook != null)
            mouseLook.canLook = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        kripteksOpen = true;
    }

    public void CloseKripteks()
    {
        if (kripteksPanel != null)
            kripteksPanel.SetActive(false);

        if (kripteksCorner != null)
            kripteksCorner.SetActive(true);

        if (playerMovement != null)
            playerMovement.canMove = true;

        if (mouseLook != null)
            mouseLook.canLook = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        kripteksOpen = false;
    }
}