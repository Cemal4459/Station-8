using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    public GameObject bottomActionPanel;
    public GameObject successPanel;
    public GameObject gameOverPanel;

    public void ShowSuccess()
    {
        bottomActionPanel.SetActive(false);
        successPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ShowGameOver()
    {
        bottomActionPanel.SetActive(false);
        gameOverPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ContinueGame()
    {
        successPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Debug.Log("Continue tiklandi");
    }

    public void ExitGame()
    {
        Debug.Log("Exit tiklandi");
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quit tiklandi");
        Application.Quit();
    }
}