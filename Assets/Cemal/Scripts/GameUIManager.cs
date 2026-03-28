using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    public GameObject bottomActionPanel;
    public GameObject successPanel;
    public GameObject gameOverPanel;

    public PlayerMovement playerMovement;
    public MouseLook mouseLook;

    public void ShowSuccess()
    {
        bottomActionPanel.SetActive(false);
        successPanel.SetActive(true);

        if (playerMovement != null)
            playerMovement.canMove = false;

        if (mouseLook != null)
            mouseLook.canLook = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ShowGameOver()
    {
        bottomActionPanel.SetActive(false);
        gameOverPanel.SetActive(true);

        if (playerMovement != null)
            playerMovement.canMove = false;

        if (mouseLook != null)
            mouseLook.canLook = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ContinueGame()
    {
        successPanel.SetActive(false);

        if (playerMovement != null)
            playerMovement.canMove = true;

        if (mouseLook != null)
            mouseLook.canLook = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Debug.Log("Continue tiklandi");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}