using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private ScoreHandler scoreHandler;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private AsteroidSpawner asteroidSpawner;
    [SerializeField] private GameObject pauseButton;
    public void EndGame()
    {
        asteroidSpawner.enabled = false;
        gameOverDisplay.SetActive(true);

        int finalScore = scoreHandler.EndTimer();
        gameOverText.text = $"Your Score: {finalScore}";

        pauseButton.SetActive(false);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Scene_Game");
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("Scene_MainMenu");
    }
}
