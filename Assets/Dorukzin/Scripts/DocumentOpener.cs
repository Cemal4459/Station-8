using UnityEngine;

public class DocumentOpener : MonoBehaviour
{
    public GameObject documentUI;

    public void OpenDocument()
    {
        documentUI.SetActive(true);
    }

    public void CloseDocument()
    {
        documentUI.SetActive(false);
    }
}