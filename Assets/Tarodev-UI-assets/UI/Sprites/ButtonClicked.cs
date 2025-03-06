using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClicked : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
