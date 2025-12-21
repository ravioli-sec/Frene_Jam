using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
