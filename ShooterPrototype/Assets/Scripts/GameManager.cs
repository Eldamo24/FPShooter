using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPaused;
    [SerializeField] private GameObject pausePanel;

    public void PauseGame()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }
    }
}
