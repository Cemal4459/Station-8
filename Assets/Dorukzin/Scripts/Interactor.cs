using UnityEngine;

public class Interactor : MonoBehaviour
{
    public float interactDistance = 3f;
    public GameManager gameManager;

    private Camera cam;
    private GameObject lastHit;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            GameObject obj = hit.collider.gameObject;

            // highlight kontrol
            if (lastHit != obj)
            {
                if (lastHit != null)
                    lastHit.GetComponent<SelectableHighlight>()?.HighlightOff();

                obj.GetComponent<SelectableHighlight>()?.HighlightOn();
                lastHit = obj;
            }

            // E tuþu ile etkileþim
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (obj.CompareTag("NPC"))
                {
                    NPCController npc = obj.GetComponent<NPCController>();

                    if (npc.isCorrect)
                        gameManager.Success();
                    else
                        gameManager.GameOver();
                }
            }
        }
        else
        {
            if (lastHit != null)
            {
                lastHit.GetComponent<SelectableHighlight>()?.HighlightOff();
                lastHit = null;
            }
        }
    }
}