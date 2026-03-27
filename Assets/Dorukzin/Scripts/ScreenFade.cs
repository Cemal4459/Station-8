using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFade : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 2f;

    public void FadeToBlack()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        if (fadeImage == null)
        {
            Debug.LogError("fadeImage atanmadý.");
            yield break;
        }

        float time = 0f;
        Color color = fadeImage.color;

        while (time < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, time / fadeDuration);
            fadeImage.color = new Color(color.r, color.g, color.b, alpha);

            time += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = new Color(color.r, color.g, color.b, 1f);
    }
}