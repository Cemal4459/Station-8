using UnityEngine;

public class BlackTransitionTest : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup.alpha = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (canvasGroup.alpha == 0)
                canvasGroup.alpha = 1;
            else
                canvasGroup.alpha = 0;
        }
    }
}