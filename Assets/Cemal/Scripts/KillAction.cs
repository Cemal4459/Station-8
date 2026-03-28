using UnityEngine;

public class KillAction : MonoBehaviour
{
    public Camera playerCam;
    public float interactDistance = 6f;
    public LayerMask interactMask;
    public GameUIManager gameUIManager;

    public void KillCurrentNPC()
    {
        Debug.Log("Kill butonuna basildi");

        if (playerCam == null)
        {
            Debug.LogError("PlayerCam bos!");
            return;
        }

        if (gameUIManager == null)
        {
            Debug.LogError("GameUIManager bos!");
            return;
        }

        Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactMask))
        {
            Debug.Log("Carpilan obje: " + hit.collider.name);

            if (hit.collider.CompareTag("NPC"))
            {
                Debug.Log("NPC vuruldu");

                NPCStatus npcStatus = hit.collider.GetComponent<NPCStatus>();

                if (npcStatus == null)
                {
                    Debug.LogError("NPCStatus yok!");
                    return;
                }

                if (npcStatus.isInfected)
                {
                    Debug.Log("SUCCESS aciliyor");
                    gameUIManager.ShowSuccess();
                }
                else
                {
                    Debug.Log("GAME OVER aciliyor");
                    gameUIManager.ShowGameOver();
                }
            }
            else
            {
                Debug.Log("Carpilan obje NPC degil");
            }
        }
        else
        {
            Debug.Log("Raycast hicbir seye carpmadi");
        }
    }
}