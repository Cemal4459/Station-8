using UnityEngine;
using TMPro;
using System.Collections;

public class CryptesPanelUI : MonoBehaviour
{
    public GameObject hintPanel;
    public CanvasGroup darkBackground;
    public RectTransform paperRect;
    public CanvasGroup paperCanvas;
    public TMP_Text clueText;
    public TMP_Text titleText;
    public GameObject closeButton;

    public float openDuration = 0.35f;
    public float typeSpeed = 0.03f;

    private Coroutine typingRoutine;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenPanel("• High fever\n• Red eyes\n• Aggressive behavior\n• Dry cough");
        }
    }

    public void OpenPanel(string clue)
    {
        hintPanel.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(OpenRoutine(clue));
    }

    public void ClosePanel()
    {
        StopAllCoroutines();
        hintPanel.SetActive(false);
    }

    IEnumerator OpenRoutine(string clue)
    {
        closeButton.SetActive(false);

        darkBackground.alpha = 0f;
        paperCanvas.alpha = 0f;
        paperRect.localScale = new Vector3(0.7f, 0.7f, 1f);
        paperRect.anchoredPosition = new Vector2(0, -40f);

        titleText.text = "CLUES";
        clueText.text = "";

        float time = 0f;

        while (time < openDuration)
        {
            time += Time.deltaTime;
            float t = Mathf.Clamp01(time / openDuration);

            darkBackground.alpha = Mathf.Lerp(0f, 0.75f, t);
            paperCanvas.alpha = Mathf.Lerp(0f, 1f, t);
            paperRect.localScale = Vector3.Lerp(new Vector3(0.7f, 0.7f, 1f), Vector3.one, t);
            paperRect.anchoredPosition = Vector2.Lerp(new Vector2(0, -40f), Vector2.zero, t);

            yield return null;
        }

        typingRoutine = StartCoroutine(TypeWriter(clue));
    }

    IEnumerator TypeWriter(string text)
    {
        clueText.text = "";

        for (int i = 0; i <= text.Length; i++)
        {
            clueText.text = text.Substring(0, i);
            yield return new WaitForSeconds(typeSpeed);
        }

        closeButton.SetActive(true);
    }
}