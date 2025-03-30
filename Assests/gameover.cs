using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("Round1"); // Load lại màn chơi chính
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene"); // Quay về Main Menu (nếu có)
    }
}
