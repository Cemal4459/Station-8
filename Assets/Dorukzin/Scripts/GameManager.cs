using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject successPanel;
    public GameObject gameOverPanel;

    public void Success()
    {
        successPanel.SetActive(true);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}