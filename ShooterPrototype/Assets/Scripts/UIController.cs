using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject mainMenuPanel;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name != "MainMenu")
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void PauseGame()
    {
        gameManager.PauseGame();
    }

    public void ExitGame()
    {
        Debug.Log("Saliste del juego");
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void CreditsMenu()
    {
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void BackMenu()
    {
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
