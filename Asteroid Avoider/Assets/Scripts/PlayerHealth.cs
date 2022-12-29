using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameOverHandler gameOverHandler;
    AudioSource audioSource;
    public void Crash()
    {
        gameOverHandler.EndGame();
        gameObject.SetActive(false); 
    } 
}
