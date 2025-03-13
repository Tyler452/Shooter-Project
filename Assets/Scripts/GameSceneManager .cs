using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager  : MonoBehaviour
{
    public void LoadMainGame()
    {
        SceneManager.LoadScene("Space Invaders");
    }

    public static void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Credits")
        {
            Invoke("LoadMainMenu", 5f); // Automatically return to Main Menu after 5 seconds
        }
    }
    
}