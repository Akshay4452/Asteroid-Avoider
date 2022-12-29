using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameOverHandler gameOverHandler;
    AudioSource audioSource;
    public AudioClip gameOver;
    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Crash()
    {
        gameOverHandler.EndGame();
        gameObject.SetActive(false); 
        PlaySound(gameOver);
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
