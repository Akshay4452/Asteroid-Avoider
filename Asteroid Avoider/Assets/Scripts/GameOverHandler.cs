using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void ResumeGame()
    {
        
    }
}
