using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Scene_Game");
    }
    public void LoadInstructions()
    {
        SceneManager.LoadScene("Scene_Instructions");
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Scene_MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
