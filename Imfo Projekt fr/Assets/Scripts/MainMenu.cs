using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1"); // Name of your actual scene
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
