using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseHandler : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuDisplay; // Add Canvas of PauseMenuHandler into Inspector
    [SerializeField] private GameObject PauseButton; // Disable Pause button when in Pause Menu
    // When the game is paused, set timescale = 0 and display Pause Game scene
    public void PauseGame()
    {
        Time.timeScale = 0; // Pauses the game
        PauseMenuDisplay.SetActive(true);
        PauseButton.SetActive(false);
    }
    public void ResumeGame()
    {
        PauseMenuDisplay.SetActive(false);
        Time.timeScale = 1;
        PauseButton.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
