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
    DontDestroyMusic bg_music;
    public void EndGame()
    {
        asteroidSpawner.enabled = false;
        gameOverDisplay.SetActive(true);

        int finalScore = scoreHandler.EndTimer();
        gameOverText.text = $"Your Score: {finalScore}";
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(2);
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
        // bg_music.GetComponent<AudioSource>().Play();
    }

    public void ResumeGame()
    {

    }
}
