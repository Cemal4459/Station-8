using UnityEngine;

public class TestOpenPanel : MonoBehaviour
{
    public GameObject hintPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E basildi");
            hintPanel.SetActive(true);
        }
    }
}